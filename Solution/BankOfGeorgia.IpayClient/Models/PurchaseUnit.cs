namespace BankOfGeorgia.IpayClient
{
    public class OrderRequestPurchaseUnit
    {
        public PurchaseUnitAmount Amount { get; set; }
    }

    public class PurchaseUnit : OrderRequestPurchaseUnit
    {
        public PurchaseUnitPayments Payments { get; set; }
        public string ShopOrderId { get; set; }
    }
}