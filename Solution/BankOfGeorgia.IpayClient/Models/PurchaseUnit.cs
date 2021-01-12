namespace BankOfGeorgia.IpayClient
{
    public class PurchaseUnit
    {
        public PurchaseUnitAmount Amount { get; set; }
        public PurchaseUnitPayments Payments { get; set; }
        public string ShopOrderId { get; set; }
    }
}