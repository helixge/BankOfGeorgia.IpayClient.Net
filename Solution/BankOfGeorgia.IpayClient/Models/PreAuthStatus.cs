using System.Runtime.Serialization;

namespace BankOfGeorgia.IpayClient
{
    public enum PreAuthStatus
    {
        None,

        [EnumMember(Value = "success")]
        Success,

        [EnumMember(Value = "in_progress")]
        InProgress,

        [EnumMember(Value = "success_unblocked")]
        SuccessUnblocked
    }
}
