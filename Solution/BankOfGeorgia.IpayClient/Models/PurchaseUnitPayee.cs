using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public class PurchaseUnitPayee
    {
        [JsonProperty("addres")]
        public string Addres { get; set; }

        [JsonProperty("contact")]
        public string Contact { get; set; }

        [JsonProperty("email_address")]
        public string Email { get; set; }
    }
}