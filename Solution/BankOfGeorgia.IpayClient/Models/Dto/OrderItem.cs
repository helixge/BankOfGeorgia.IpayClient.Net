namespace BankOfGeorgia.IpayClient
{
    /// <summary>
    /// Purchase order item
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Product description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Product price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Product quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Product unique identifier in the store
        /// </summary>
        public string ProductId { get; set; }
    }
}
