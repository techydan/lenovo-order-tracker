# Lenovo Order Tracker

 :warning: **I am not responsible for any issues caused on your order.**  
 :warning: **If your order is cancelled or anything, I am not at fault.**  
 :warning: **If you don't trust this program, don't run it.**  
 :warning: **if you want to check the source code before running it, it's in this repo.**  

This is a simple .net core console app which periodically:
- Gets your order information from Lenovo
- Checks the shipping / delivery date
- If it's changed since it last checked (Set to every 30 minutes)
  - Writes to the console the new dates
  - Sends a Pushover notification to your phone

- [Lenovo Order Tracker](#lenovo-order-tracker)
  - [:tada: Get Started](#-get-started)
    - [:page_facing_up: Configuration](#-configuration)
      - [:loudspeaker: Pushover](#-pushover)
        - [:key: Create an App Key](#-create-an-app-key)
        - [:raised_hand: User Key](#-user-key)
      - [:computer: Lenovo Order URL](#-lenovo-order-url)
  - [:running: Run](#-run)

## :tada: Get Started

Firstly, either clone this repo or download a precompiled version from the [Releases Page](TODO). You'll need to change a couple of settings in the `appsettings.json` file.

### :page_facing_up: Configuration
You'll need to change the following entries in `appsettings.json` to link your order to your phone.

| Config Entry    | Description                                                                 | Example                                                       |
| --------------- | --------------------------------------------------------------------------- | ------------------------------------------------------------- |
| PushoverAppKey  | The API Key generated when creating an application on the Pushover Website. | aBcDeFg123456                                                 |
| PushoverUserKey | Your user Key, found on the Pushover Website when logged in.                | qWeRtY0987                                                    |
| LenovoXmlUrl    | The order XML url                                                           | `https://checkout.lenovo.com/store?Action=DisplayOVPData&...` |

#### :loudspeaker: Pushover

This app is best if you have a [Pushover](https://pushover.net/) Account, which requires you to purchase the Pushover App for your mobile.

_If you don't have (or don't want to purchase Pushover), it'll still log to the console when the dates change. (Just keep the Pushover config as `""`)_

Once you've got Pushover, you need two bits of information:
- An app key (see below how to generate one, used to send notifications)
- Your user key (which you can find [here](https://pushover.net/), once logged in, used to receive notifications)

##### :key: Create an App Key

You need to create an App Key to send notifications on Pushover. Go to the [Pushover website](https://pushover.net/) and at the bottom, you'll see the section "Your Applications   (Create an Application/API Token)". Click "Create an Application", and fill in at least the following:
- Name (Required) E.g. Lenovo
- Agree to the ToS
- Click "Create Application"

Once you've got an application, you'll have an "API Token/Key", which you need to put in the config entry `PushoverAppKey`

#####  :raised_hand: User Key

Now that you've created your app key, you need your user key. You can get this from the [Pushover website](https://pushover.net), once logged in, it's your user key under the heading "Your User Key" on the right hand side. Copy this into the config entry `PushoverUserKey`.

####  :computer: Lenovo Order URL

Basically, the order form is powered by an xml file. For this program to work, you need to get the link to the URL.

In Google Chrome (Or another browser on a PC): 
- Open your order tracker
- Right click on the screen and click "Inspect"
- In the new window which shows:
  - Click on the "Network" tab
  - Refresh the page
  - You'll see a list of files which are then loaded in that page.
  - In the filter box, type "`store?`" and you should see one row which type is `xhr`
  - Right click that row -> Copy -> Copy link address
  - Place that url in the config `LenovoXmlUrl`

##  :running: Run

**The app needs to be running to check for updates. Keep the application minimised.**

This runs on .NET Core, which means it can run on Windows, macOS and Linux.

If you're using Windows, there's a prebuilt exe you can find out the release page.