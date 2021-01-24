using Newtonsoft.Json;
using System;

namespace BankOfGeorgia.IpayClient
{
    internal class SerializeDecimaAsStringJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(decimal);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var stringVal = StringDecimalConversionHelper.ConvertDecimalToString((decimal)value);
            writer.WriteValue(stringVal);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var decimalVal = StringDecimalConversionHelper.ConvertStringToDecimal(existingValue.ToString());
            return decimalVal;
        }
    }
}
