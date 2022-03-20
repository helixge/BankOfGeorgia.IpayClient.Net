using BankOfGeorgia.IpayClient;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Example.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly BankOfGeorgiaIpayClient _iPayClient;

        public HomeController(
            BankOfGeorgiaIpayClient IpayClient
            )
        {
            _iPayClient = IpayClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Pay()
        {
            //Create Order
            var order = new OrderRequest()
            {
                Intent = Intent.Authorize,
                Currency = IPayCurrency.GEL,
                Items = new[]
                {
                    new OrderItem() { Price= 75.12m, Description = "First product", Quantity = 1, ProductId = "P-001" },
                    new OrderItem() { Price= 127.51m, Description = "Second product", Quantity = 3, ProductId = "P-002" },
                    new OrderItem() { Price= 35.00m, Description = "Shipping", Quantity = 1, ProductId = "SHIPPING" }
                },
                Locale = "ka",
                ShopOrderId = Guid.NewGuid().ToString("N"),
                RedirectUrl = "https://localhost:44397/IpayCallback/Payment",
                ShowShopOrderIdOnExtract = true,
                CaptureMethod = CaptureMethod.Automatic,
            };

            // Create Transaction
            var registerResult = await _iPayClient
                .MakeOrderAsync(order);

            // Check if error occured


            // When succeeded redirect to bank page
            var redirectUrl = registerResult.GetRedirectUrl();

            return Redirect(redirectUrl);
        }
    }
}
