using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public abstract class CallbackResponse
    {
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("payment_hash")]
        public string PaymentHash { get; set; }

        [JsonProperty("ipay_payment_id")]
        public string IpayPaymentId { get; set; }

        [JsonProperty("status_description")]
        public string StatusDescription { get; set; }

        [JsonProperty("shop_order_id")]
        public string ShopOrderId { get; set; }

        [JsonProperty("payment_method")]
        public PaymentMethod PaymentMethod { get; set; }

        [JsonProperty("card_type")]
        public CardType CardType { get; set; }
    }

    public class PaymentCallbackResult : CallbackResponse
    {
        [JsonProperty("status")]
        public PaymentStatus Status { get; set; }

        [JsonProperty("pan")]
        public string Pan { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("pre_auth_status")]
        public PreAuthStatus PreAuthStatus { get; set; }
    }

    public class RefundCallbackResult : CallbackResponse
    {

    }
}
