using Newtonsoft.Json;

namespace BankOfGeorgia.IpayClient
{
    public class OrderRequestPurchaseUnitAmount
    {
        /// <summary>
        /// Purchase unit currency
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Purchase unit value
        /// </summary>
        [JsonConverter(typeof(SerializeDecimaAsStringJsonConverter))]
        [JsonProperty("value")]
        public decimal Value { get; set; }

        public OrderRequestPurchaseUnitAmount()
        {

        }

        public OrderRequestPurchaseUnitAmount(string currency, decimal value)
            : this()
        {
            Currency = currency;
            Value = value;
        }
    }
}