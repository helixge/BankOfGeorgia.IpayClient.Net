using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace BankOfGeorgia.IpayClient
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CaptureMethod
    {
        //TODO: Update description about how to reverse transaction processed using this method
        /// <summary>
        /// Amount is charged immediately and there is no need to call pre-auth/complete method.
        /// </summary>
        [EnumMember(Value = "AUTOMATIC")]
        Automatic,

        /// <summary>
        /// Amount is placed on hold and removed from available balance immediately. After that, you will need to complete pre-authorization by calling pre-auth/complete or unblock amount by calling refund. If you do not call one of these methods, the amount is automatically unlocked after 30 days.
        /// </summary>
        [EnumMember(Value = "MANUAL")]
        Manual
    }
}
