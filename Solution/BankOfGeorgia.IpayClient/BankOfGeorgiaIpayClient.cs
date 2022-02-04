using Microsoft.Extensions.Logging;
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
    /// <summary>
    /// Full documentation is located at: https://developer.ipay.ge/v1/
    /// </summary>
    public class BankOfGeorgiaIpayClient
    {
        private readonly BankOfGeorgiaIpayClientOptions _options;
        private readonly HttpClient _httpClient;
        private readonly ILogger<BankOfGeorgiaIpayClient> _logger;
        private string _accessToken = null;

        public string AccessToken => _accessToken;

        public BankOfGeorgiaIpayClient(
            BankOfGeorgiaIpayClientOptions options,
            HttpClient httpClient,
            ILogger<BankOfGeorgiaIpayClient> logger
            )
        {
            _options = options;
            _httpClient = httpClient;
            _logger = logger;
        }

        /// <summary>
        /// Authenticate API with user credentials
        /// Endpoint: /oauth2/token
        /// </summary>
        /// <returns></returns>
        /// <exception cref="IpayClientAuthenticationException">Thrown when auhentication fails</exception>
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
                requestMessage => requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString)
                );

            if (result.IsError)
                throw new IpayClientAuthenticationException(result);

            if (String.IsNullOrWhiteSpace(result.AccessToken))
                throw new IpayClientAuthenticationException(result);

            _accessToken = result.AccessToken;
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
        public Task<ServiceResponse> RefundAsync(string orderId, decimal? amount = null)
        {
            return MakeHttpRequest<ServiceResponse>(
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

        ///// <summary>
        ///// Check order details
        ///// Endpoint: /checkout/orders/{order_id}
        ///// </summary>
        ///// <returns></returns>
        //public Task<GetOrderDetailsResponse> GetOrderDetailsAsync(string orderId)
        //{
        //    return MakeHttpRequest<GetOrderDetailsResponse>(
        //        GetFullUrl($"/checkout/orders/{orderId}"),
        //        true,
        //        HttpMethod.Get,
        //        null,
        //        null
        //        );
        //}

        ///// <summary>
        ///// Check order status
        ///// Endpoint: /checkout/orders/status/{order_id}
        ///// </summary>
        ///// <returns></returns>
        //public Task<GetOrderStatusResponse> GetOrderStatusAsync(string orderId)
        //{
        //    return MakeHttpRequest<GetOrderStatusResponse>(
        //        GetFullUrl($"/checkout/payment/{orderId}"),
        //        true,
        //        HttpMethod.Get,
        //        null,
        //        null
        //        );
        //}

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


        private Task<TResult> MakeHttpRequest<TResult>(string url, bool useJwtAuth, HttpMethod method, object jsonPostPayload = null, Action<HttpRequestMessage> processRequestMessage = null)
            where TResult : ServiceResponse, new()
        {
            var requestMessage = new HttpRequestMessage(method, url);

            if (jsonPostPayload != null)
            {
                var serializedPayload = JsonConvert.SerializeObject(jsonPostPayload);
                requestMessage.Content = new StringContent(serializedPayload, Encoding.UTF8, "application/json");
            }

            return MakeHttpRequest<TResult>(useJwtAuth, method, requestMessage, processRequestMessage);

        }

        private Task<TResult> MakeHttpRequest<TResult>(string url, bool useJwtAuth, HttpMethod method, IEnumerable<KeyValuePair<string, string>> urlEncodedPostPayload = null, Action<HttpRequestMessage> processRequestMessage = null)
            where TResult : ServiceResponse, new()
        {
            var requestMessage = new HttpRequestMessage(method, url);

            if (urlEncodedPostPayload != null)
            {
                IEnumerable<KeyValuePair<string, string>> keyValuePairs = urlEncodedPostPayload
                    .Where(i => i.Value != null);
                
                requestMessage.Content = new FormUrlEncodedContent(keyValuePairs);
            }

            return MakeHttpRequest<TResult>(useJwtAuth, method, requestMessage, processRequestMessage);
        }

        private async Task<TResult> MakeHttpRequest<TResult>(bool useJwtAuth, HttpMethod method, HttpRequestMessage requestMessage, Action<HttpRequestMessage> processRequestMessage = null)
            where TResult : ServiceResponse, new()
        {
            try
            {
                if (useJwtAuth)
                {
                    await AuthenticateIfRequired();
                    requestMessage.Headers.Add("Authorization", "Bearer " + _accessToken);
                }

                processRequestMessage?.Invoke(requestMessage);

                using var httpResponseMessage = await _httpClient.SendAsync(requestMessage);

                var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<TResult>(responseContent);
                result.RawResponse = responseContent;
                result.HttpStatusCode = (int)httpResponseMessage.StatusCode;
                result.IsError = !httpResponseMessage.IsSuccessStatusCode;

                return result;
            }
            catch (Exception ex)
            {
                return new TResult()
                {
                    IsError = true,
                    Exception = ex
                };
            }
        }

        private async Task AuthenticateIfRequired()
        {
            if (_accessToken == null)
                await AuthenticateAsync();

            if (!JwtHelper.IsTokenValid(_accessToken))
                await AuthenticateAsync();
        }

        private string GetFullUrl(string endpoint)
        {
            return $"https://ipay.ge/opay/api/v1{endpoint}";
        }
    }
}
