using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public class PurchaseUnitPayments
    {
        [JsonProperty("captures")]
        public PurchaseUnitPaymentsCapture[] Captures { get; set; }
    }
}