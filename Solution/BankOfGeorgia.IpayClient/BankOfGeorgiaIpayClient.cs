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

        /// <summary>
        /// Auto injectable client
        /// </summary>
        /// <param name="options"></param>
        /// <param name="httpClient"></param>
        /// <param name="logger"></param>
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
            Dictionary<string, string> payload = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" }
            };

            AuthenticateResponse result = await MakeHttpRequest<AuthenticateResponse>(
                url: GetFullUrl("/oauth2/token"),
                useJwtAuth: false,
                method: HttpMethod.Post,
                urlEncodedPostPayload: payload,
                processRequestMessage: ProcessTokenRequestMessage
            ).ConfigureAwait(false);

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
                url: GetFullUrl($"/checkout/orders"),
                useJwtAuth: true,
                method: HttpMethod.Post,
                payload: order
            );
        }

        /// <summary>
        /// Make recurring request
        /// Endpoint: /checkout/payment/subscription
        /// </summary>
        /// <returns></returns>
        public Task<MakeRecurringOrderResponse> MakeRecurringOrderAsync(IpayRecurringOrder order)
        {
            return MakeHttpRequest<MakeRecurringOrderResponse>(
                url: GetFullUrl($"/checkout/payment/subscription"),
                useJwtAuth: true,
                method: HttpMethod.Post,
                payload: order
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
                url: GetFullUrl($"/checkout/payment/pre-auth/complete/{orderId}"),
                useJwtAuth: true,
                method: HttpMethod.Get,
                urlEncodedPostPayload: null,
                processRequestMessage: null
            );
        }

        /// <summary>
        /// Make reversal/unblock request
        /// Endpoint: /checkout/refund
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse> RefundAsync(string orderId, decimal? amount = null)
        {
            var payload = new Dictionary<string, string>
            {
                { "order_id", orderId },
                { "amount", amount?.ToString() }
            };

            return MakeHttpRequest<ServiceResponse>(
                url: GetFullUrl("/checkout/refund"),
                useJwtAuth: true,
                method: HttpMethod.Post,
                urlEncodedPostPayload: payload,
                processRequestMessage: null
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
                url: GetFullUrl($"/checkout/payment/{orderId}"),
                useJwtAuth: true,
                method: HttpMethod.Get,
                urlEncodedPostPayload: null,
                processRequestMessage: null
                );
        }

        private Task<TResult> MakeHttpRequest<TResult>(
            string url,
            bool useJwtAuth,
            HttpMethod method,
            object payload)
            where TResult : ServiceResponse, new()
        {
            var requestMessage = new HttpRequestMessage(method, url);

            if (payload != null)
            {
                string serializedPayload = JsonConvert.SerializeObject(payload);
                requestMessage.Content = new StringContent(serializedPayload, Encoding.UTF8, "application/json");
            }

            return MakeHttpRequest<TResult>(useJwtAuth, requestMessage, processRequestMessage: null);

        }

        private Task<TResult> MakeHttpRequest<TResult>(
            string url,
            bool useJwtAuth,
            HttpMethod method,
            IEnumerable<KeyValuePair<string, string>> urlEncodedPostPayload = null,
            Action<HttpRequestMessage> processRequestMessage = null)
            where TResult : ServiceResponse, new()
        {
            var requestMessage = new HttpRequestMessage(method, url);

            if (urlEncodedPostPayload != null)
            {
                IEnumerable<KeyValuePair<string, string>> keyValuePairs = urlEncodedPostPayload
                    .Where(i => i.Value != null);

                requestMessage.Content = new FormUrlEncodedContent(keyValuePairs);
            }

            return MakeHttpRequest<TResult>(useJwtAuth, requestMessage, processRequestMessage);
        }

        private async Task<TResult> MakeHttpRequest<TResult>(
            bool useJwtAuth,
            HttpRequestMessage requestMessage,
            Action<HttpRequestMessage> processRequestMessage = null)
            where TResult : ServiceResponse, new()
        {
            try
            {
                if (useJwtAuth)
                {
                    await AuthenticateIfRequired().ConfigureAwait(false);
                    requestMessage.Headers.Add("Authorization", "Bearer " + _accessToken);
                }

                processRequestMessage?.Invoke(requestMessage);

                using HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);

                string responseContent = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                TResult result = JsonConvert.DeserializeObject<TResult>(responseContent);
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
            {
                await AuthenticateAsync().ConfigureAwait(false);
            }

            if (!JwtHelper.IsTokenValid(_accessToken))
            {
                await AuthenticateAsync().ConfigureAwait(false);
            }
        }

        private string GetFullUrl(string endpoint)
        {
            return $"https://ipay.ge/opay/api/v1{endpoint}";
        }

        private void ProcessTokenRequestMessage(HttpRequestMessage message)
        {
            string authenticationString = $"{_options.ClientId}:{_options.SecretKey}";
            byte[] authenticationStringBytes = Encoding.ASCII.GetBytes(authenticationString);
            string base64EncodedAuthenticationString = Convert.ToBase64String(authenticationStringBytes);

            message.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);
        }
    }
}
