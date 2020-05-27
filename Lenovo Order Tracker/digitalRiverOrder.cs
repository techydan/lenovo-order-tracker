using System.Xml.Serialization;

namespace Lenovo_Order_Tracker
{
    	[XmlRoot(ElementName="document")]
	public class Document {
		[XmlElement(ElementName="event")]
		public string Event { get; set; }
		[XmlElement(ElementName="poDate")]
		public string PoDate { get; set; }
		[XmlElement(ElementName="created")]
		public string Created { get; set; }
		[XmlElement(ElementName="program")]
		public string Program { get; set; }
		[XmlElement(ElementName="event_set")]
		public string Event_set { get; set; }
		[XmlElement(ElementName="productID")]
		public string ProductID { get; set; }
		[XmlElement(ElementName="event_type")]
		public string Event_type { get; set; }
		[XmlElement(ElementName="history_ids")]
		public string History_ids { get; set; }
		[XmlElement(ElementName="firmShipDate")]
		public string FirmShipDate { get; set; }
		[XmlElement(ElementName="last_modified")]
		public string Last_modified { get; set; }
		[XmlElement(ElementName="orderQuantity")]
		public string OrderQuantity { get; set; }
		[XmlElement(ElementName="detail_id")]
		public string Detail_id { get; set; }
		[XmlElement(ElementName="lineItemStatus")]
		public string LineItemStatus { get; set; }
		[XmlElement(ElementName="firmArrivalDate")]
		public string FirmArrivalDate { get; set; }
		[XmlElement(ElementName="orderItemStatus")]
		public string OrderItemStatus { get; set; }
		[XmlElement(ElementName="shippedQuantity")]
		public string ShippedQuantity { get; set; }
		[XmlElement(ElementName="directOrIndirect")]
		public string DirectOrIndirect { get; set; }
		[XmlElement(ElementName="orderReceiptDate")]
		public string OrderReceiptDate { get; set; }
		[XmlElement(ElementName="orderReleaseDate")]
		public string OrderReleaseDate { get; set; }
		[XmlElement(ElementName="salesOrderNumber")]
		public string SalesOrderNumber { get; set; }
		[XmlElement(ElementName="transaction_date")]
		public string Transaction_date { get; set; }
		[XmlElement(ElementName="unique_event_key")]
		public string Unique_event_key { get; set; }
		[XmlElement(ElementName="estimatedShipDate")]
		public string EstimatedShipDate { get; set; }
		[XmlElement(ElementName="requestedshipdate")]
		public string Requestedshipdate { get; set; }
		[XmlElement(ElementName="shipToCountryName")]
		public string ShipToCountryName { get; set; }
		[XmlElement(ElementName="productDescription")]
		public string ProductDescription { get; set; }
		[XmlElement(ElementName="soldToCustomerName")]
		public string SoldToCustomerName { get; set; }
		[XmlElement(ElementName="salesOrderLineNumber")]
		public string SalesOrderLineNumber { get; set; }
		[XmlElement(ElementName="soldToCustomerNumber")]
		public string SoldToCustomerNumber { get; set; }
		[XmlElement(ElementName="estimatedDeliveryDate")]
		public string EstimatedDeliveryDate { get; set; }
		[XmlElement(ElementName="customerPurchaseOrderNumber")]
		public string CustomerPurchaseOrderNumber { get; set; }
	}

	[XmlRoot(ElementName="documents")]
	public class Documents {
		[XmlElement(ElementName="status")]
		public string Status { get; set; }
		[XmlElement(ElementName="document")]
		public Document Document { get; set; }
	}
}