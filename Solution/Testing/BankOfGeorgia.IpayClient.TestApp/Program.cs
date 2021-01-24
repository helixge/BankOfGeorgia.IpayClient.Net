using JWT.Algorithms;
using JWT.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfGeorgia.IpayClient.TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            TestJsonExpirationValidation();

            await TestTransactionProcessing();
        }

        private static async Task TestTransactionProcessing()
        {
            using (var scope = CreateServiceProvider().CreateScope())
            {
                BankOfGeorgiaIpayClient client = scope.ServiceProvider
                    .GetRequiredService<BankOfGeorgiaIpayClient>();

                await client.AuthenticateAsync();
                //var automaticCaptureOrderResult = await client.MakeOrderAsync(new IpayOrder()
                //{
                //    CaptureMethod = CaptureMethod.Automatic,
                //    Intent = Intent.Authorize,
                //    Items = new[]
                //    {
                //        new IpayOrderItem(amount: 1.7m, description: "First product", quantity: 1, productId: "P001"),
                //        new IpayOrderItem(amount: 2.5m, description: "Second product", quantity: 3, productId: "P002")
                //    },
                //    RedirectUrl = "https://mystore.ge/api/ipayreturn",
                //    ShopOrderId = "Order-001",
                //    ShowShopOrderIdOnExtract = true,
                //    PurchaseUnits = new[]
                //    {
                //        new OrderRequestPurchaseUnit(currency: Currency.GEL, value: 1.7m),
                //        new OrderRequestPurchaseUnit(currency: Currency.GEL, value: 2.5m)
                //    }
                //});
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

            return services.BuildServiceProvider();
        }

        private static void TestJsonExpirationValidation()
        {
            var jwtToken = "eyJraWQiOiIxMDA2IiwiY3R5IjoiYXBwbGljYXRpb25cL2pzb24iLCJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJQdWJsaWMgcGF5bWVudCBBUEkgVjEiLCJhdWQiOiJpUGF5IERlbW8iLCJpc3MiOiJodHRwczpcL1wvaXBheS5nZSIsImV4cCI6MTYwOTg2MDk4Mn0.ZBYmIz-tV_VktDFgKf5WsM-NsM8GDmpjn3fMHjYYyS8";
            var json = JwtHelper.IsTokenValid(jwtToken);
        }
    }
}
