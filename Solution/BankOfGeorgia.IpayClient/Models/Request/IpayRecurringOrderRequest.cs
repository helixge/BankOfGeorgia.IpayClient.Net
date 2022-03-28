using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public class IpayRecurringOrderRequest
    {
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("amount")]
        public Amount Amount { get; set; }

        [JsonProperty("shop_order_id")]
        public string ShopOrderId { get; set; }

        [JsonProperty("purchase_description")]
        public string PurchaseDescription { get; set; }
    }
}
