using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public class IpayOrderItem
    {
        /// <summary>
        /// Amount in GEL
        /// </summary>
        [JsonConverter(typeof(SerializeDecimaAsStringJsonConverter))]
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Product description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Product quantity
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Product unique identifier in the store
        /// </summary>
        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        public IpayOrderItem()
        {

        }

        public IpayOrderItem(decimal amount, string description, int quantity, string productId)
            : this()
        {
            Amount = amount;
            Description = description;
            Quantity = quantity;
            ProductId = productId;
        }
    }
}
