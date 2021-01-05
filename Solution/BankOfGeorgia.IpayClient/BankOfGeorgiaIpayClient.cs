using JWT.Algorithms;
using JWT.Builder;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BankOfGeorgia.IpayClient
{
    public class BankOfGeorgiaIpayClient
    {
        private readonly BankOfGeorgiaIpayClientOptions _options;
        private string _jwtToken = null;

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

        private async Task<TResult> MakeHttpRequest<TResult>(string url, bool useAuth, bool useHttpPost, object postPayload = null)
        {
            using var httpClient = new HttpClient();

            if (useAuth)
            {
                await AuthenticateIfRequired();
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + _jwtToken);
            }

            HttpResponseMessage httpResponseMessage;
            if (useHttpPost)
            {
                var serializedPostPayload = JsonConvert.SerializeObject(postPayload);
                using var stringContent = new StringContent(serializedPostPayload, Encoding.UTF8, "application/json");
                httpResponseMessage = await httpClient.PostAsync(url, stringContent);
            }
            else
            {
                httpResponseMessage = await httpClient.GetAsync(url);
            }

            var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
            try
            {
                httpResponseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception($"HTTP request failed with the following response content: responseContent", ex);
            }

            return JsonConvert.DeserializeObject<TResult>(responseContent);
        }

        private async Task AuthenticateIfRequired()
        {
            if (_jwtToken == null)
                await AuthenticateAsync();

            if (!JwtHelper.IsTokenValid(_jwtToken))
                await AuthenticateAsync();
        }
    }
}
