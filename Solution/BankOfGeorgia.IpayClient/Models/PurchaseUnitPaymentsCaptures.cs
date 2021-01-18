using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public class CheckPurchaseUnitPaymentsCaptures
    {
        [JsonProperty("id")]
        public string Id { get; set; }
     
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        
        [JsonProperty("amount")]
        public CheckPurchaseUnitAmount Amount { get; set; }
    }
}