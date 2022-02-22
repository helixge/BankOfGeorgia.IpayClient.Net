using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public class Amount
    {
        [JsonProperty("currency_code")]
        public string Currency { get; set; }

        [JsonProperty("value")]
        public decimal Value { get; set; }
    }
}