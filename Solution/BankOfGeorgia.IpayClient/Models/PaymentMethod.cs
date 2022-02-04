using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace BankOfGeorgia.IpayClient
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentMethod
    {
        None = 0,

        /// <summary>
        /// გადახდა შესრულებულია ბარათით
        /// </summary>
        [EnumMember(Value = "GC_CARD")]
        GcCard = 10,

        /// <summary>
        /// გადახდა შესრულებულია ავტორიზაციით
        /// </summary>
        [EnumMember(Value = "BOG_CARD")]
        BogCard = 20,

        /// <summary>
        /// გადახდა შესრულებულია PLUS ან MR ქულებით
        /// </summary>
        [EnumMember(Value = "BOG_LOYALTY")]
        BogLoyalty = 30,

        /// <summary>
        /// განვადებით ყიდვა
        /// </summary>
        [EnumMember(Value = "BOG_LOAN")]
        BogLoan = 40,

        /// <summary>
        /// ბრუნდება იმ შემთხვევაში, თუ ორდერის სტატუსი არის error ან in_progress
        /// </summary>
        [EnumMember(Value = "UNKNOWN")]
        Unknown = 50
    }
}
