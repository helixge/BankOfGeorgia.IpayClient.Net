using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public class PurchaseUnitAmount
    {
        [JsonProperty("currency_code")]
        public string Currency { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}