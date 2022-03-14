using BankOfGeorgia.IpayClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
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
            IpayOrderItem[] products = new[]
            {
                new IpayOrderItem(amount: 200.0m, description: "First product", quantity: 1, productId: "P001"),
                new IpayOrderItem(amount: 100000.5m, description: "Second product", quantity: 3, productId: "P002")
            };

            //Create Order
            var order = new IpayOrderRequest()
            {
                Intent = Intent.Authorize,
                Items = products,
                Locale = "ka",
                ShopOrderId = Guid.NewGuid().ToString("N"),
                RedirectUrl = "https://localhost:44397/IpayCallback/Payment",
                ShowShopOrderIdOnExtract = true,
                CaptureMethod = CaptureMethod.Automatic,
                PurchaseUnits = new[]
                {
                        //new OrderRequestPurchaseUnit(currency: Currency.GEL, value: 1.5m),
                        new IpayOrderRequestPurchaseUnit(currency: Currency.GEL, value: products.Sum(p=>p.Amount * p.Quantity))
                }
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
