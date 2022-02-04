using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public class OrderDetailsPayer
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email_address")]
        public string EmailAdress { get; set; }

        [JsonProperty("payer_id")]
        public string PayerId { get; set; }
    }
}
