using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BankOfGeorgia.IpayClient.TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //await TestInjectionScopeAuthToken();
            //MakeOrderResponse makeOrderResult = await TestTransactionProcessing();
            //string automaticCaptureOrderResultRedirectUrl = makeOrderResult.GetRedirectUrl();
            //Console.WriteLine(automaticCaptureOrderResultRedirectUrl);
            //Console.ReadKey();
            //GetPaymentDetailsResponse paymentDetailsResponse = await TestTransactionStatusCheck(makeOrderResult.OrderId);


            using var provider = CreateServiceProvider();
            using var scope = provider.CreateScope();

            BankOfGeorgiaIpayClient client = scope.ServiceProvider
               .GetRequiredService<BankOfGeorgiaIpayClient>();

            IpayOrderItem[] products = new[]
            {
                    new IpayOrderItem(amount: 1.7m, description: "First product", quantity: 1, productId: "P001"),
                    new IpayOrderItem(amount: 2.5m, description: "Second product", quantity: 3, productId: "P002")
            };

            IpayOrder order = new IpayOrder()
            {
                CaptureMethod = CaptureMethod.Automatic,
                Intent = Intent.Authorize,
                Locale = "ka",
                RedirectUrl = "https://example.ge/api/ipayreturn",
                ShopOrderId = Guid.NewGuid().ToString("N"),
                ShowShopOrderIdOnExtract = true,
                Items = products,
                PurchaseUnits = new[]
                    {
                         new OrderRequestPurchaseUnit(currency: Currency.USD, value: products.Sum(p=>p.Amount * p.Quantity))
                    }
            };

            //Register transaction
            {
                MakeOrderResponse automaticCaptureOrderResult = await client.MakeOrderAsync(order);
                OpenUrlInBworser(automaticCaptureOrderResult.GetRedirectUrl());
            }

            //Recurring order
            {
                MakeOrderResponse orderResult = await client.MakeOrderAsync(order);
                ServiceResponse refundResult = await client.RefundAsync(orderResult.OrderId);

                MakeRecurringOrderResponse reccurringResult = await client.MakeRecurringOrderAsync(new IpayRecurringOrder()
                {
                    OrderId = orderResult.OrderId,
                    Amount = new Amount()
                    {
                        Currency = Currency.GEL,
                        Value = 1.7m
                    },
                    ShopOrderId = Guid.NewGuid().ToString("N"),
                    PurchaseDescription = "Recurring order"
                });

                GetPaymentDetailsResponse recurringOrderDetails = await client.GetPaymentDetailsAsync(reccurringResult.OrderId);
            }

            //Get payment details
            {
                MakeOrderResponse automaticCaptureOrderResult = null;
                GetPaymentDetailsResponse paymentDetails = await client.GetPaymentDetailsAsync(automaticCaptureOrderResult.OrderId);
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

        private static void OpenUrlInBworser(string url)
        {
            Process.Start("cmd", $"/C start {url}");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        //private static async Task<MakeOrderResponse> TestTransactionProcessing()
        //{
        //    using var provider = CreateServiceProvider();
        //    using var scope = provider.CreateScope();

        //    BankOfGeorgiaIpayClient client = scope.ServiceProvider
        //        .GetRequiredService<BankOfGeorgiaIpayClient>();

        //    MakeOrderResponse automaticCaptureOrderResult = await client.MakeOrderAsync(new IpayOrder()
        //    {
        //        CaptureMethod = CaptureMethod.Automatic,
        //        Intent = Intent.Authorize,
        //        Items = new[]
        //        {
        //                new IpayOrderItem(amount: 1.7m, description: "First product", quantity: 1, productId: "P001"),
        //                new IpayOrderItem(amount: 2.5m, description: "Second product", quantity: 3, productId: "P002")
        //            },
        //        RedirectUrl = "https://example.ge/api/ipayreturn",
        //        ShopOrderId = Guid.NewGuid().ToString("N"),
        //        ShowShopOrderIdOnExtract = true,
        //        PurchaseUnits = new[]
        //        {
        //                new OrderRequestPurchaseUnit(currency: Currency.GEL, value: 1.7m),
        //                new OrderRequestPurchaseUnit(currency: Currency.GEL, value: 2.5m)
        //            }
        //    });
        //    return automaticCaptureOrderResult;
        //}

        //private static async Task TestInjectionScopeAuthToken()
        //{
        //    using var serviceProvider = CreateServiceProvider();
        //    using var scope1 = serviceProvider.CreateScope();
        //    BankOfGeorgiaIpayClient client1 = scope1.ServiceProvider
        //        .GetRequiredService<BankOfGeorgiaIpayClient>();

        //    using var scope2 = serviceProvider.CreateScope();
        //    BankOfGeorgiaIpayClient client2 = scope2.ServiceProvider
        //        .GetRequiredService<BankOfGeorgiaIpayClient>();

        //    await client1.AuthenticateAsync();
        //    Thread.Sleep(2000);
        //    await client2.AuthenticateAsync();

        //    if (client1.AccessToken == client2.AccessToken)
        //    {
        //        throw new Exception("Clients share access token");
        //    }
        //}

        //private static async Task<GetPaymentDetailsResponse> TestTransactionStatusCheck(string orderId)
        //{
        //    using var provider = CreateServiceProvider();
        //    using var scope = provider.CreateScope();

        //    BankOfGeorgiaIpayClient client = scope.ServiceProvider
        //        .GetRequiredService<BankOfGeorgiaIpayClient>();

        //    GetPaymentDetailsResponse paymentDetails = await client.GetPaymentDetailsAsync(orderId);
        //    return paymentDetails;
        //}
    }
}
