using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace BankOfGeorgia.IpayClient
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CaptureMethod
    {
        //AUTOMATIC
        [EnumMember(Value = "AUTOMATIC")]
        Automatic,

        //MANUAL
        /// <summary>
        /// Amount is placed on hold and removed from available balance immediately.After that, you will need to complete pre-authorization by calling pre-auth/complete or unblock amount by calling refund. If you do not call one of these methods, the amount is automatically unlocked after 30 days.
        /// </summary>
        [EnumMember(Value = "MANUAL")]
        Manual
    }
}
