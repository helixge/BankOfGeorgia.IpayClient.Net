namespace BankOfGeorgia.IpayClient
{
    public class PurchaseUnitPaymentsCaptures
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public PurchaseUnitAmount Amount { get; set; }
    }
}