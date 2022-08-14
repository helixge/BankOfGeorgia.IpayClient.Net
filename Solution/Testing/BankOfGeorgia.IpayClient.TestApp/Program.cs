using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BankOfGeorgia.IpayClient.TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var provider = CreateServiceProvider();
            using var scope = provider.CreateScope();

            BankOfGeorgiaIpayClient client = scope.ServiceProvider
                  .GetRequiredService<BankOfGeorgiaIpayClient>();

            OrderItem[] orderItems = new[]
            {
                new OrderItem() { Price = 1.7m, Description = "First product", Quantity = 1, ProductId = "P001" },
                new OrderItem() { Price = 2.5m, Description =  "Second product", Quantity =  3, ProductId = "P002" }
            };

            //Make order with automatic capture
            {
                MakeOrderResponse orderResult = await MakeOrder(client, CaptureMethod.Automatic, orderItems);
                OpenUrlInBworser(orderResult.GetRedirectUrl());

                GetPaymentDetailsResponse paymentDetails = await GetPaymentDetailsAsync(client, orderResult.OrderId);
            }

            //Make order with manual capture and complete preauthorization
            {
                MakeOrderResponse orderResult = await MakeOrder(client, CaptureMethod.Manual, orderItems);
                OpenUrlInBworser(orderResult.GetRedirectUrl());

                var completePreAuthPaymentRequest = new CompletePreAuthPaymentRequest()
                {
                    AuthType = AuthType.Partial,
                    Amount = 1m
                };
                ServiceResponse completePreAuthPaymentResult = await client.CompletePreAuthPaymentAsync(orderResult.OrderId, completePreAuthPaymentRequest);
            }

            //Make recurring order
            {
                MakeOrderResponse orderResult = await MakeOrder(client, CaptureMethod.Automatic, orderItems);
                OpenUrlInBworser(orderResult.GetRedirectUrl());

                ServiceResponse refundResult = await client.RefundAsync(orderResult.OrderId);

                MakeRecurringOrderResponse reccurringResult = await client.MakeRecurringOrderAsync(new IpayRecurringOrderRequest()
                {
                    OrderId = orderResult.OrderId,
                    Amount = new Amount()
                    {
                        Currency = IPayCurrency.GEL,
                        Value = 1.7m
                    },
                    ShopOrderId = Guid.NewGuid().ToString("N"),
                    PurchaseDescription = "Recurring order"
                });

                GetPaymentDetailsResponse recurringOrderDetails = await client.GetPaymentDetailsAsync(reccurringResult.OrderId);
            }

            //Get payment details
            {
                MakeOrderResponse orderResult = await MakeOrder(client, CaptureMethod.Automatic, orderItems);
                OpenUrlInBworser(orderResult.GetRedirectUrl());

                GetPaymentDetailsResponse paymentDetails = await client.GetPaymentDetailsAsync(orderResult.OrderId);
            }

            //Refund
            {
                MakeOrderResponse orderResult = await MakeOrder(client, CaptureMethod.Automatic, orderItems);
                OpenUrlInBworser(orderResult.GetRedirectUrl());

                GetPaymentDetailsResponse paymentDetails = await GetPaymentDetailsAsync(client, orderResult.OrderId);

                ServiceResponse refungResult = await MakeRefundAsyunc(client, orderResult.OrderId);
            }
        }

        public static async Task<MakeOrderResponse> MakeOrder(BankOfGeorgiaIpayClient client, CaptureMethod captureMethod, OrderItem[] orderItems)
        {
            OrderRequest order = new OrderRequest()
            {
                CaptureMethod = captureMethod,
                Intent = Intent.Authorize,
                Locale = Locale.KA,
                ShopOrderId = Guid.NewGuid().ToString("N"),
                RedirectUrl = "https://example.ge/api/ipayreturn",
                Currency = IPayCurrency.GEL,
                ShowShopOrderIdOnExtract = true,
                Items = orderItems
            };

            MakeOrderResponse orderResult = await client.MakeOrderAsync(order);

            return orderResult;
        }

        public static async Task<GetPaymentDetailsResponse> GetPaymentDetailsAsync(BankOfGeorgiaIpayClient client, string orderId)
        {
            GetPaymentDetailsResponse orderDetails = await client.GetPaymentDetailsAsync(orderId);
            return orderDetails;
        }

        public static async Task<ServiceResponse> MakeRefundAsyunc(BankOfGeorgiaIpayClient client, string orderId)
        {
            ServiceResponse refundDetails = await client.RefundAsync(orderId);
            return refundDetails;
        }


        private static ServiceProvider CreateServiceProvider()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
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
    }
}
