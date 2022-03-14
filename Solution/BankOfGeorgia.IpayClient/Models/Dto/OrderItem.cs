namespace BankOfGeorgia.IpayClient
{
    public class OrderItem
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
        public string ProductId { get; set; }
    }
}
