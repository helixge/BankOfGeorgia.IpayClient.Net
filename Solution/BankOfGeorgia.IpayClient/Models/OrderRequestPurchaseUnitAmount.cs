using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public class OrderRequestPurchaseUnitAmount
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}