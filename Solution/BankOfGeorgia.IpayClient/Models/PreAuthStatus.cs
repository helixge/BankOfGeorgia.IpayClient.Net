using System.Runtime.Serialization;

namespace BankOfGeorgia.IpayClient
{
    public enum PreAuthStatus
    {
        None = 0,

        /// <summary>
        /// პრეავტორიზაცია დამოწმებულია და თანხა გადარიცხულია მერჩანტთან
        /// </summary>
        [EnumMember(Value = "success")]
        Success = 10,

        /// <summary>
        /// მიმდინარეობს პრეავტორიზაცია. თანხა დაბლოკილია და შესაძლებელია დამოწმება და განბლოკვა
        /// </summary>
        [EnumMember(Value = "in_progress")]
        InProgress = 20,


        /// <summary>
        /// პრეავტორიზაცია განბლოკილია. თანხა დაბრუნებულია მომხმარებლის ანგარიშზე და ჩანს ხელმისაწვდომ თანხებში
        /// </summary>
        [EnumMember(Value = "success_unblocked")]
        SuccessUnblocked = 30
    }
}
