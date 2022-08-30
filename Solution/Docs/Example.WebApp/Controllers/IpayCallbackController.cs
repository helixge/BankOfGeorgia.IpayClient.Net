using BankOfGeorgia.IpayClient;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Example.WebApp.Controllers
{
    public class IpayCallbackController : Controller
    {
        private readonly IBankOfGeorgiaIpayClient _iPayClient;

        public IpayCallbackController(
            IBankOfGeorgiaIpayClient IpayClient
            )
        {
            _iPayClient = IpayClient;
        }

        [HttpPost]
        [HttpGet]
        public async Task<IActionResult> Payment([FromForm] PaymentCallbackResult result)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [HttpGet]
        public async Task<IActionResult> Refund([FromForm] RefundCallbackResult result)
        {
            throw new NotImplementedException();
        }
    }
}
