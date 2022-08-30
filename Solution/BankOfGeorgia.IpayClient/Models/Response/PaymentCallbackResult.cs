using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public abstract class CallbackResponse
    {
        [JsonProperty("order_id")]
        [BindProperty(Name = "order_id")]
        public string OrderId { get; set; }

        [JsonProperty("payment_hash")]
        [BindProperty(Name = "payment_hash")]
        public string PaymentHash { get; set; }

        [JsonProperty("ipay_payment_id")]
        [BindProperty(Name = "ipay_payment_id")]
        public string IpayPaymentId { get; set; }

        [JsonProperty("status_description")]
        [BindProperty(Name = "status_description")]
        public string StatusDescription { get; set; }

        [JsonProperty("shop_order_id")]
        [BindProperty(Name = "shop_order_id")]
        public string ShopOrderId { get; set; }

        [JsonProperty("payment_method")]
        [BindProperty(Name = "payment_method")]
        public PaymentMethod PaymentMethod { get; set; }

        [JsonProperty("card_type")]
        [BindProperty(Name = "card_type")]
        public CardType CardType { get; set; }
    }

    public class PaymentCallbackResult : CallbackResponse
    {
        [JsonProperty("status")]
        [BindProperty(Name = "status")]
        public PaymentStatus Status { get; set; }

        [JsonProperty("pan")]
        [BindProperty(Name = "pan")]
        public string Pan { get; set; }

        [JsonProperty("transaction_id")]
        [BindProperty(Name = "transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("pre_auth_status")]
        [BindProperty(Name = "pre_auth_status")]
        public PreAuthStatus PreAuthStatus { get; set; }
    }

    public class RefundCallbackResult : CallbackResponse
    {

    }
}
