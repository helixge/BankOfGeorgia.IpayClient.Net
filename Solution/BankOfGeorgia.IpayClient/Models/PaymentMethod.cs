using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace BankOfGeorgia.IpayClient
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentMethod
    {
        [EnumMember(Value = "GC_CARD")]
        GcCard,

        [EnumMember(Value = "BOG_CARD")]
        BogCard,

        [EnumMember(Value = "BOG_LOYALTY")]
        BogLoyalty,

        [EnumMember(Value = "BOG_LOAN")]
        BogLoan,

        [EnumMember(Value = "UNKNOWN")]
        Unknown
    }
}
