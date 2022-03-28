using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public class PurchaseUnit
    {
        [JsonProperty("amount")]
        public Amount Amount { get; set; }

        [JsonProperty("payments")]
        public PurchaseUnitPayments[] Payments { get; set; }

        [JsonProperty("shop_order_id")]
        public string ShopOrderId { get; set; }

        [JsonProperty("payee")]
        public PurchaseUnitPayee Payee { get; set; }
    }
}