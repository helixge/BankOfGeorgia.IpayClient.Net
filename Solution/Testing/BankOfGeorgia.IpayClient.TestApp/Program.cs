using JWT.Algorithms;
using JWT.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BankOfGeorgia.IpayClient.TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //TestJsonExpirationValidation();

            await TestInjectionScopeAuthToken();
            //await TestTransactionProcessing();
        }

        private static async Task TestInjectionScopeAuthToken()
        {
            using var serviceProvider = CreateServiceProvider();
            using var scope1 = serviceProvider.CreateScope();
            BankOfGeorgiaIpayClient client1 = scope1.ServiceProvider
                .GetRequiredService<BankOfGeorgiaIpayClient>();

            using var scope2 = serviceProvider.CreateScope();
            BankOfGeorgiaIpayClient client2 = scope2.ServiceProvider
                .GetRequiredService<BankOfGeorgiaIpayClient>();

            await client1.AuthenticateAsync();
            Thread.Sleep(2000);
            await client2.AuthenticateAsync();

            if (client1.AccessToken == client2.AccessToken)
                throw new Exception("Clients share access token");
        }

        private static async Task TestTransactionProcessing()
        {
            using (var scope = CreateServiceProvider().CreateScope())
            {
                BankOfGeorgiaIpayClient client = scope.ServiceProvider
                    .GetRequiredService<BankOfGeorgiaIpayClient>();

                //await client.AuthenticateAsync();
                var automaticCaptureOrderResult = await client.MakeOrderAsync(new IpayOrder()
                {
                    CaptureMethod = CaptureMethod.Automatic,
                    Intent = Intent.Authorize,
                    Items = new[]
                    {
                        new IpayOrderItem(amount: 1.7m, description: "First product", quantity: 1, productId: "P001"),
                        new IpayOrderItem(amount: 2.5m, description: "Second product", quantity: 3, productId: "P002")
                    },
                    RedirectUrl = "https://mystore.ge/api/ipayreturn",
                    ShopOrderId = Guid.NewGuid().ToString("N"),
                    ShowShopOrderIdOnExtract = true,
                    PurchaseUnits = new[]
                    {
                        new OrderRequestPurchaseUnit(currency: Currency.GEL, value: 1.7m),
                        new OrderRequestPurchaseUnit(currency: Currency.GEL, value: 2.5m)
                    }
                });
                var automaticCaptureOrderResultRedirectUrl = automaticCaptureOrderResult.GetRedirectUrl();
            }
        }

        private static ServiceProvider CreateServiceProvider()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();
            var options = config.GetBankOfGeorgiaIpayClientOptions("iPay");

            var services = new ServiceCollection();
            services
                .AddLogging(loggerBuilder =>
                {
                    loggerBuilder.ClearProviders();
                    loggerBuilder.AddConsole();
                })
                .AddBankOfGeorgiaIpay(options)
                ;

            return services
                .BuildServiceProvider();
        }

        private static void TestJsonExpirationValidation()
        {
            var jwtToken = "eyJraWQiOiIxMDA2IiwiY3R5IjoiYXBwbGljYXRpb25cL2pzb24iLCJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJQdWJsaWMgcGF5bWVudCBBUEkgVjEiLCJhdWQiOiJpUGF5IERlbW8iLCJpc3MiOiJodHRwczpcL1wvaXBheS5nZSIsImV4cCI6MTYwOTg2MDk4Mn0.ZBYmIz-tV_VktDFgKf5WsM-NsM8GDmpjn3fMHjYYyS8";
            var json = JwtHelper.IsTokenValid(jwtToken);
        }
    }
}
