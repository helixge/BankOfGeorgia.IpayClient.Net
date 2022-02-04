using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public class OrderDetailsErrorHistory
    {
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty("actionTime")]
        public string ActionTime { get; set; }
    }
}
