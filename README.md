# Bank of Georgia iPay Card Payments Gateway Client (.NET Library)

[![Version](https://helix.ge/helix-bankofgeorgia-ipayclient-nuget.svg?1-6-0)](https://www.nuget.org/packages/Helix.BankOfGeorgia.IpayClient)

[Helix.BankOfGeorgia.IpayClient](https://www.nuget.org/packages/Helix.BankOfGeorgia.IpayClient) is a .NET client library for using Bank of Georgia iPay Visa, Master Card and Americal Express payments gateway.

Official API reference can be found here: \
https://api.bog.ge/docs/en/ipay/introduction

## How To Use
See [ASP.NET Core integration guide](#integrating-with-aspnet-core) below

### Define options
```csharp
var clientOptions = new BankOfGeorgiaIpayClientOptions()
{
    ClientId = "your-ipay-client-id",
    SecretKey = "your-ipay-client-secret",
};
```

### Create client
```csharp
var client = new BankOfGeorgiaIpayClient(clientOptions);
```


## Integrating with ASP.NET Core
To integrate the client with ASP.NET Core dependency injection pipeline, use the following steps:

1. Add an entry in your appSettings.json file and specify your iPay `ClientId` and `SecretKey`):
    ```js 
    {
       //...other options
       
       "iPay": {
          "ClientId": "your-ipay-client-id",
          "SecretKey": "your-ipay-client-secret",
       }
  
       //...other options
    }
    ```

    If you want to play with the **DEMO** mode, you can use the following configuration parameters:
    ````js
     {
       //...other options
       
       "iPay": {
          "ClientId": "1006",
          "SecretKey": "581ba5eeadd657c8ccddc74c839bd3ad",
          "BaseUrl": "https://dev.ipay.ge/opay/api/v1"
       }
  
       //...other options
    }
    ````
    :warning: **BaseUrl** is **NOT** required for production use. If you leave this parameter empty or remove it completely, the default production URL will be used: https://ipay.ge/opay/api/v1
2. Call `AddBankOfGeorgiaIpay` in `ConfigureServices` method of `Startup.cs` and specify the configuration parameter name containing the options array (for this example we called the entry `iPay`):
    ```csharp
    services.AddBankOfGeorgiaIpay(
      Configuration.GetBankOfGeorgiaIpayClientOptions("iPay")
    );
    ```

    Make sure you have access to `Configuration`. If you are missing configuration, you can inject it in your `Startup`):   
    ```csharp
    public class Startup
    {
        public IConfiguration Configuration { get; }
    
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
    ```

3. Inject `IBankOfGeorgiaIpayClient` and use in your code:    
    ```csharp
    public class HomeController : Controller
    {
        private readonly IBankOfGeorgiaIpayClient _iPayClient;
    
        public HomeController(IBankOfGeorgiaIpayClient iPayClient)
        {
            _iPayClient = iPayClient;
        }
    }
    ```

## Methods
No manual authentication is required. Access token will be requested when needed and when it expires automatically.

* **MakeOrderAsync**    
Place an one-time order
    
    > This method encapsulates a [/api/v1/checkout/orders](https://api.bog.ge/docs/en/ipay/create-order) endpoint and simplifies the request model. 


* **MakeRecurringOrderAsync**    
Place an order for a recurring payments without user's interraction. You need to create an initial order to use recurring payments, where the user will enter their credit card details for the Bank to remember. You will need an ID of an existing order to perform additional reocurring orders.\
\
If you don't want to charge the user for the first time and want the Bank to remember the card details for future use, you will still have to create an initial order for the minimum amount of 0.10 GEL and then you refund it.
    
    > This method encapsulates a [/api/v1/checkout/payment/subscription](https://api.bog.ge/docs/en/ipay/recurring-payments). 

* **MakeRecurringOrderAsync**
There are two ways the transaction can be processed, called the `capture_method`: \
`- AUTOMATIC` \
`- MANUAL` \
See this for more details https://api.bog.ge/docs/en/ipay/create-order \
If the transaction was created using `MANUAL` capture method, it needs to be confirmed by calling this method.
    
    > This method encapsulates a [/api/v1/checkout/payment/{order_id}/pre-auth/completion](https://api.bog.ge/docs/en/ipay/pre-authorization). 

* **RefundAsync**
Refund the transaction fully or partially
    
    > This method encapsulates a [/api/v1/checkout/refund](https://api.bog.ge/docs/en/ipay/refund). 
