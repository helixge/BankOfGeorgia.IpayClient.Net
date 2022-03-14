using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace BankOfGeorgia.IpayClient
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CardType
    {
        NONE = 0,

        /// <summary>
        /// Mastercard
        /// </summary>
        [EnumMember(Value = "MC")]
        MC = 10,

        /// <summary>
        /// Visa
        /// </summary>
        [EnumMember(Value = "VISA")]
        Visa = 20,

        /// <summary>
        /// American Express
        /// </summary>
        [EnumMember(Value = "AMEX")]
        Amex = 30,

        /// <summary>
        /// თუ გადახდის ტიპი არის BOG_CARD ან GC_CARD, იწერება ბარათის ტიპი. დანარჩენ სხვა შემთხვევაში იწერება UNKNOWN
        /// </summary>
        [EnumMember(Value = "UNKNOWN")]
        Unknown = 40
    }
}
