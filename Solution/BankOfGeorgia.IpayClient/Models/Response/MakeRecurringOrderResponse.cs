using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public class MakeRecurringOrderResponse : ServiceResponse
    {
        [JsonProperty("status")]
        public PaymentStatus Status { get; set; }

        [JsonProperty("payment_hash")]
        public string PaymentHash { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }
    }
}
