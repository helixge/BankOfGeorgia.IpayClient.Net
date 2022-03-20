# Bank of Georgia iPay Card Payments Gateway Client (.NET Library)

[![Version](https://helix.ge/helix-bankofgeorgia-ipayclient-nuget.svg?3-0-0)](https://www.nuget.org/packages/Helix.BankOfGeorgia.IpayClient)

[Helix.BankOfGeorgia.IpayClient](https://www.nuget.org/packages/Helix.BankOfGeorgia.IpayClient) is a .NET client library for using Bank of Georgia iPay Visa, Master Card and Americal Express payments gateway.

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
  ]
  
   //...other options
}
```

2. Call ```AddBankOfGeorgiaIpay``` in ```ConfigureServices``` method of ```Startup.cs``` and specify the configuration parameter name containing the options array (for this example we called the entry ```iPay```):
````csharp
services.AddBankOfGeorgiaIpay(
  Configuration.GetBankOfGeorgiaIpayClientOptions("iPay")
);
````

> Make sure you have access to ```Configuration```. If you are missing configuration, you can inject it in your `Startup`:
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

3. Inject ```IBankOfGeorgiaIpayClient```:
````csharp
public class HomeController : Controller
{
    private readonly IBankOfGeorgiaIpayClient _iPayClient;

    public HomeController(
        IBankOfGeorgiaIpayClient iPayClient
        )
    {
        _iPayClient = iPayClient;
    }

    //...other methods
}
````