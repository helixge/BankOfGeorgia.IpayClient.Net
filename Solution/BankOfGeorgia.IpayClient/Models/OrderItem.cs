using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public class OrderItem
    {
        /// <summary>
        /// Amount in GEL
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }
    }
}
