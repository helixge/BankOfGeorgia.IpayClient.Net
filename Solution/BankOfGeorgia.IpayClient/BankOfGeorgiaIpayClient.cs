using System;
using System.Threading.Tasks;

namespace BankOfGeorgia.IpayClient
{
    public class BankOfGeorgiaIpayClient
    {
        private readonly BankOfGeorgiaIpayClientOptions _options;
        private string jwtToken = null;

        public BankOfGeorgiaIpayClient(
            BankOfGeorgiaIpayClientOptions options
            )
        {
            _options = options;
        }

        /// <summary>
        /// Authenticate API with user credentials
        /// Endpoint: /oauth2/token
        /// </summary>
        /// <returns></returns>
        public Task AuthenticateAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Make order request
        /// Endpoint: /checkout/orders
        /// </summary>
        /// <returns></returns>
        public Task MakeOrderAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Complete pre-auth payment
        /// Endpoint: /checkout/payment/pre-auth/complete/{order_id}
        /// </summary>
        /// <returns></returns>
        public Task CompletePreAuthPaymentAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Make reversal/unblock request
        /// Endpoint: /checkout/refund
        /// </summary>
        /// <returns></returns>
        public Task UnblockRequestAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Check order details
        /// Endpoint: /checkout/orders/{order_id}
        /// </summary>
        /// <returns></returns>
        public Task GetOrderDetailsAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Check order status
        /// Endpoint: /checkout/orders/status/{order_id}
        /// </summary>
        /// <returns></returns>
        public Task GetOrderStatusAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// /checkout/payment/{order_id}
        /// Endpoint: /checkout/payment/{order_id}
        /// </summary>
        /// <returns></returns>
        public Task GetPaymentDetailsAsync()
        {
            throw new NotImplementedException();
        }

        private async Task AuthenticateIfRequired()
        {
            if (jwtToken == null)
                await AuthenticateAsync();


        }
    }
}
