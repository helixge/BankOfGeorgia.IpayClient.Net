using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public class IpayOrderItem
    {
        /// <summary>
        /// Amount
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; }

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

        public IpayOrderItem(string amount, string description, int quantity, string productId)
            : this()
        {
            Amount = amount;
            Description = description;
            Quantity = quantity;
            ProductId = productId;
        }
    }
}
