using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Xml.Serialization;
using Microsoft.Extensions.Configuration;
using PushoverClient;

namespace Lenovo_Order_Tracker
{
    class Program
    {
        private static int ConfigCheckTimeInMinutes => 30;
        private static string ConfigPushoverAppKey => Configuration["PushoverAppKey"];
        private static string ConfigPushoverUserKey => Configuration["PushoverUserKey"];
        private static string ConfigLenovoXmlUrl => Configuration["LenovoXmlUrl"];
        private static IConfiguration Configuration { get; set; }
        private static string CurrentShipDate { get; set; }
        private static string CurrentDeliveryDate { get; set; }

        static void Main(string[] args)
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Join(System.IO.Directory.GetCurrentDirectory(), "appsettings.json"), false, true)
                .Build();

            var waitTime = TimeSpan.FromMinutes(ConfigCheckTimeInMinutes);
            do
            {
                CheckOrderStatus();
                Thread.Sleep(waitTime);
            } while (true);
        }

        private static void CheckOrderStatus()
        {
            var webClient = new WebClient();
            var xmlString = webClient.DownloadString(ConfigLenovoXmlUrl);

            var xmlSerializer = new XmlSerializer(typeof(Documents));
            using var reader = new StringReader(xmlString);
            var doc = (Documents) xmlSerializer.Deserialize(reader);

            if (doc.Document.EstimatedShipDate == CurrentShipDate &&
                doc.Document.EstimatedDeliveryDate == CurrentDeliveryDate)
            {
                return;
            }

            CurrentShipDate = doc.Document.EstimatedShipDate;
            CurrentDeliveryDate = doc.Document.EstimatedDeliveryDate;

            Console.WriteLine($"New Shipping Date: {doc.Document.EstimatedShipDate}");
            Console.WriteLine($"New Delivery Date: {doc.Document.EstimatedDeliveryDate}");

            if (string.IsNullOrWhiteSpace(ConfigPushoverAppKey) ||
                string.IsNullOrWhiteSpace(ConfigPushoverUserKey)) return;

            try
            {
                new Pushover(ConfigPushoverAppKey).Push("Laptop Order Updated",
                    $"New Shipping Date: {doc.Document.EstimatedShipDate}\r\n" +
                    $"New Delivery Date: {doc.Document.EstimatedDeliveryDate}",
                    ConfigPushoverUserKey);
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't send Pushover Notification");
                Console.WriteLine(e.Message);
            }
        }
    }
}