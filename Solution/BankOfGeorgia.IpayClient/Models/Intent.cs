using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace BankOfGeorgia.IpayClient
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Intent
    {
        /// <summary>
        /// Provides several payment options for users, on the same page. Payment can be performed by card and with BOG digital credentials ( username &amp; password )
        /// </summary>
        [EnumMember(Value = "CAPTURE")]
        Capture,

        /// <summary>
        /// Allows users to pay ONLY with entering card details
        /// </summary>
        [EnumMember(Value = "AUTHORIZE")]
        Authorize,

        /// <summary>
        ///  Users can pay with only installment option. For this user should enter BOG credentials, username / password and go through installment payment process. LOAN minimum amount is 50 GEL and maximum amount is 4900 GEL
        /// </summary>
        [EnumMember(Value = "LOAN")]
        Loan
    }
}
