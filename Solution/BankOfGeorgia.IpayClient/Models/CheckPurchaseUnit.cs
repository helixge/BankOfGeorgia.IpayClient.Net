using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{

    public class CheckPurchaseUnit
    {
        [JsonProperty("amount")]
        public CheckPurchaseUnitAmount Amount { get; set; }

        [JsonProperty("payments")]
        public CheckPurchaseUnitPayments Payments { get; set; }

        [JsonProperty("shop_order_id")]
        public string ShopOrderId { get; set; }
    }
}