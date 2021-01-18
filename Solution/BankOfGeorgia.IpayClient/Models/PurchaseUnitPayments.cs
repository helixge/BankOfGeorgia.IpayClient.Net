using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public class CheckPurchaseUnitPayments
    {
        [JsonProperty("captures")]
        public CheckPurchaseUnitPaymentsCaptures Captures { get; set; }
    }
}