using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace BankOfGeorgia.IpayClient
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatusDescription
    {
        [EnumMember(Value = "REJECTED")]
        Rejected,

        [EnumMember(Value = "PERFORMED")]
        Performed
    }
}
