using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public class OrderRequestPurchaseUnitAmount
    {
        /// <summary>
        /// Purchase unit currency
        /// </summary>
        [JsonProperty("currency_code")]
        public string Currency { get; set; }

        /// <summary>
        /// Purchase unit value
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        public OrderRequestPurchaseUnitAmount()
        {

        }

        public OrderRequestPurchaseUnitAmount(string currency, string value)
            : this()
        {
            Currency = currency;
            Value = value;
        }
    }
}