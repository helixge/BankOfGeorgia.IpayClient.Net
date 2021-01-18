namespace BankOfGeorgia.IpayClient
{
    public class GetPaymentDetailsResponse : ServiceResponse
    {
        public PaymentStatus Status { get; set; }
        public string Pan { get; set; }
        public string OrderId { get; set; }
        //public PreAuthStatus PreAuthStatus { get; set; }
        public string PaymentHash { get; set; }
        public string IpayPaymentId { get; set; }
        public StatusDescription StatusDescription { get; set; }
        public string ShopOrderId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public CardType CardType { get; set; }
        public string TransactionId { get; set; }
    }
}
