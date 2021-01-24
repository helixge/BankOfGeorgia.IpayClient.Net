using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public class OrderRequestPurchaseUnit
    {
        /// <summary>
        /// Purchase unit amount entry
        /// </summary>
        [JsonProperty("amount")]
        public OrderRequestPurchaseUnitAmount Amount { get; set; }

        public OrderRequestPurchaseUnit()
        {

        }

        public OrderRequestPurchaseUnit(string currency, decimal value)
            : this()
        {
            Amount = new OrderRequestPurchaseUnitAmount(currency, value);
        }
    }
}