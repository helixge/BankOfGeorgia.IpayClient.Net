using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace BankOfGeorgia.IpayClient
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CardType
    {
        [EnumMember(Value = "MC")]
        MC,

        [EnumMember(Value = "VISA")]
        Visa,

        [EnumMember(Value = "AMEX")]
        Amex,

        [EnumMember(Value = "UNKNOWN")]
        Unknown
    }
}
