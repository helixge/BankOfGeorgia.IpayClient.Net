using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public class OrderRequestPurchaseUnit
    {
        [JsonProperty("amount")]
        public OrderRequestPurchaseUnitAmount Amount { get; set; }
    }
}