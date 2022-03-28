using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public class AuthenticateResponse : ServiceResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("app_id")]
        public string AppId { get; set; }

        /// <summary>
        /// Epoch milliseconds
        /// </summary>
        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }
    }
}
