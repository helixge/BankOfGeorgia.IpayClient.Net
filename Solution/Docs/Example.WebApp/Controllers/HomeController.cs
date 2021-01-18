using BankOfGeorgia.IpayClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            var order = new IpayOrder()
            {

            };

            // Create Transaction
            var registerResult = await _iPayClient
                .MakeOrderAsync(order);

            // Check if error occured


            // When succeeded redirect to bank page
            var redirectUrl = "";

            return Redirect(redirectUrl);
        }
    }
}
