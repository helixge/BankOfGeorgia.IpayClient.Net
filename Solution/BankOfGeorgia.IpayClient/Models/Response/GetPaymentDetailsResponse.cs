using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public class GetPaymentDetailsResponse : ServiceResponse
    {
        [JsonProperty("status")]
        public PaymentStatus? Status { get; set; }

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
        public PaymentMethod? PaymentMethod { get; set; }

        [JsonProperty("card_type")]
        public CardType? CardType { get; set; }

        //Card Payment
        [JsonProperty("pan")]
        public string Pan { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        //Pre-auth Payment
        /// <summary>
        /// პრეავტორიზაციის სტატუსი. ბრუნდება მხოლოდ მაშინ, თუ ორდერის გენერაციის დროს, capture_method არის MANUAL და ორდერის სტატუსი არის success
        /// </summary>
        [JsonProperty("pre_auth_status")]
        public PreAuthStatus? PreAuthStatus { get; set; }
    }
}
