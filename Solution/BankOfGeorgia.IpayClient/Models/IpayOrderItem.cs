using Newtonsoft.Json;
using System;

namespace BankOfGeorgia.IpayClient
{
    public class IpayOrderItem
    {
        /// <summary>
        /// Amount in GEL
        /// </summary>
        [JsonConverter(typeof(SerializeDecimaAsStringJsonConverter))]
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Product description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Product quantity
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Product unique identifier in the store
        /// </summary>
        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        public IpayOrderItem()
        {

        }

        public IpayOrderItem(decimal amount, string description, int quantity, string productId)
            : this()
        {
            Amount = amount;
            Description = description;
            Quantity = quantity;
            ProductId = productId;
        }
    }

    internal class SerializeDecimaAsStringJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(decimal);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //JsonSerializer innerSerializer = new JsonSerializer();
            //innerSerializer.ContractResolver = exclusionResolver;
            //// (copy other settings from the outer serializer if needed)

            //var o = JObject.FromObject(value, innerSerializer);

            //// ...do your custom stuff here...

            //o.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
