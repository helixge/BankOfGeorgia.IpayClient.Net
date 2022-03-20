using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public class IpayOrderRequestPurchaseUnit
    {
        /// <summary>
        /// Purchase unit amount entry
        /// </summary>
        [JsonProperty("amount")]
        public OrderRequestPurchaseUnitAmount Amount { get; set; }

        public IpayOrderRequestPurchaseUnit()
        {

        }

        public IpayOrderRequestPurchaseUnit(string currency, string value)
            : this()
        {
            Amount = new OrderRequestPurchaseUnitAmount(currency, value);
        }
    }
}