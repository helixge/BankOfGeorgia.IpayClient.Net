using JWT.Algorithms;
using JWT.Builder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BankOfGeorgia.IpayClient
{
    public class BankOfGeorgiaIpayClient
    {
        //https://developer.ipay.ge/v1/

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
        public async Task AuthenticateAsync()
        {
            var authenticationString = $"{_options.ClientId}:{_options.SecretKey}";
            var base64EncodedAuthenticationString = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(authenticationString));

            var result = await MakeHttpRequest<AuthenticateResponse>(
                GetFullUrl("/oauth2/token"),
                false,
                HttpMethod.Post,
                new Dictionary<string, string>
                {
                    { "grant_type", "client_credentials" }
                },
                client => client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString)
                );

            _jwtToken = result.access_token;
        }

        /// <summary>
        /// Make order request
        /// Endpoint: /checkout/orders
        /// </summary>
        /// <returns></returns>
        public Task<MakeOrderResponse> MakeOrderAsync(IpayOrder order)
        {
            return MakeHttpRequest<MakeOrderResponse>(
                GetFullUrl($"/checkout/orders"),
                true,
                HttpMethod.Post,
                order,
                null
                );
        }

        /// <summary>
        /// Complete pre-auth payment
        /// Endpoint: /checkout/payment/pre-auth/complete/{order_id}
        /// </summary>
        /// <returns></returns>
        public Task<CompletePreAuthPaymentResponse> CompletePreAuthPaymentAsync(string orderId)
        {
            return MakeHttpRequest<CompletePreAuthPaymentResponse>(
                GetFullUrl($"/checkout/payment/pre-auth/complete/{orderId}"),
                true,
                HttpMethod.Get,
                null,
                null
                );
        }

        /// <summary>
        /// Make reversal/unblock request
        /// Endpoint: /checkout/refund
        /// </summary>
        /// <returns></returns>
        public Task RefundAsync(string orderId, decimal? amount = null)
        {
            return MakeHttpRequest<object>(
                GetFullUrl("/checkout/refund"),
                true,
                HttpMethod.Post,
                new Dictionary<string, string>
                {
                    { "order_id", orderId },
                    { "amount", amount?.ToString() }
                },
                null
                );
        }

        /// <summary>
        /// Check order details
        /// Endpoint: /checkout/orders/{order_id}
        /// </summary>
        /// <returns></returns>
        public Task<GetOrderDetailsResponse> GetOrderDetailsAsync(string orderId)
        {
            return MakeHttpRequest<GetOrderDetailsResponse>(
                GetFullUrl($"/checkout/orders/{orderId}"),
                true,
                HttpMethod.Get,
                null,
                null
                );
        }

        /// <summary>
        /// Check order status
        /// Endpoint: /checkout/orders/status/{order_id}
        /// </summary>
        /// <returns></returns>
        public Task GetOrderStatusAsync(string orderId)
        {
            return MakeHttpRequest<GetOrderDetailsResponse>(
                GetFullUrl($"/checkout/status/{orderId}"),
                true,
                HttpMethod.Get,
                null,
                null
                );
        }

        /// <summary>
        /// /checkout/payment/{order_id}
        /// Endpoint: /checkout/payment/{order_id}
        /// </summary>
        /// <returns></returns>
        public Task<GetPaymentDetailsResponse> GetPaymentDetailsAsync(string orderId)
        {
            return MakeHttpRequest<GetPaymentDetailsResponse>(
                GetFullUrl($"/checkout/payment/{orderId}"),
                true,
                HttpMethod.Get,
                null,
                null
                );
        }

        private Task<TResult> MakeHttpRequest<TResult>(string url, bool useJwtAuth, HttpMethod method, object jsonPostPayload = null, Action<HttpClient> processClient = null)
        {
            using var requestMessage = new HttpRequestMessage(method, url);
            if (jsonPostPayload != null)
            {
                var serializedPayload = JsonConvert.SerializeObject(jsonPostPayload);
                requestMessage.Content = new StringContent(serializedPayload, Encoding.UTF8, "application/json");
            };

            return MakeHttpRequest<TResult>(useJwtAuth, method, requestMessage, processClient);
        }

        private Task<TResult> MakeHttpRequest<TResult>(string url, bool useJwtAuth, HttpMethod method, IEnumerable<KeyValuePair<string, string>> urlEncodedPostPayload = null, Action<HttpClient> processClient = null)
        {
            using var requestMessage = new HttpRequestMessage(method, url);
            if (urlEncodedPostPayload != null)
            {
                requestMessage.Content = new FormUrlEncodedContent(
                    urlEncodedPostPayload
                        .Where(i => i.Value != null)
                    );
            };

            return MakeHttpRequest<TResult>(useJwtAuth, method, requestMessage, processClient);
        }

        private async Task<TResult> MakeHttpRequest<TResult>(bool useJwtAuth, HttpMethod method, HttpRequestMessage requestMessage, Action<HttpClient> processClient = null)
        {
            using var httpClient = new HttpClient();

            if (useJwtAuth)
            {
                await AuthenticateIfRequired();
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + _jwtToken);
            }

            processClient?.Invoke(httpClient);

            using var httpResponseMessage = await httpClient.SendAsync(requestMessage);

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

        private string GetFullUrl(string endpoint)
        {
            return $"https://ipay.ge/opay/api/v1{endpoint}";
        }
    }
}
