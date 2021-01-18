using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public class CheckPurchaseUnitAmount
    {
        [JsonProperty("currency_code")]
        public string Currency { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}