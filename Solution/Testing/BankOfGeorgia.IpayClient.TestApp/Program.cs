using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BankOfGeorgia.IpayClient.TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await TestInjectionScopeAuthToken();
            MakeOrderResponse makeOrderResult = await TestTransactionProcessing();
            string automaticCaptureOrderResultRedirectUrl = makeOrderResult.GetRedirectUrl();
            Console.WriteLine(automaticCaptureOrderResultRedirectUrl);
            Console.ReadKey();
            GetPaymentDetailsResponse paymentDetailsResponse = await TestTransactionStatusCheck(makeOrderResult.OrderId);
        }

        private static async Task<MakeOrderResponse> TestTransactionProcessing()
        {
            using var provider = CreateServiceProvider();
            using var scope = provider.CreateScope();

            BankOfGeorgiaIpayClient client = scope.ServiceProvider
                .GetRequiredService<BankOfGeorgiaIpayClient>();

            MakeOrderResponse automaticCaptureOrderResult = await client.MakeOrderAsync(new IpayOrder()
            {
                CaptureMethod = CaptureMethod.Automatic,
                Intent = Intent.Authorize,
                Items = new[]
                {
                        new IpayOrderItem(amount: 1.7m, description: "First product", quantity: 1, productId: "P001"),
                        new IpayOrderItem(amount: 2.5m, description: "Second product", quantity: 3, productId: "P002")
                    },
                RedirectUrl = "https://example.ge/api/ipayreturn",
                ShopOrderId = Guid.NewGuid().ToString("N"),
                ShowShopOrderIdOnExtract = true,
                PurchaseUnits = new[]
                {
                        new OrderRequestPurchaseUnit(currency: Currency.GEL, value: 1.7m),
                        new OrderRequestPurchaseUnit(currency: Currency.GEL, value: 2.5m)
                    }
            });

            return automaticCaptureOrderResult;
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
            {
                throw new Exception("Clients share access token");
            }
        }

        private static async Task<GetPaymentDetailsResponse> TestTransactionStatusCheck(string orderId)
        {
            using var provider = CreateServiceProvider();
            using var scope = provider.CreateScope();

            BankOfGeorgiaIpayClient client = scope.ServiceProvider
                .GetRequiredService<BankOfGeorgiaIpayClient>();

            GetPaymentDetailsResponse paymentDetails = await client.GetPaymentDetailsAsync(orderId);
            return paymentDetails;
        }
    }
}
