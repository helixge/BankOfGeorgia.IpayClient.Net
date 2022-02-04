using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace BankOfGeorgia.IpayClient
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentStatus
    {
        None = 0,

        /// <summary>
        /// გადახდის პროცესი დასრულდა წარმატებით
        /// </summary>
        [EnumMember(Value = "success")]
        Success = 1,

        /// <summary>
        /// გადახდის პროცესი დასრულდა წარუმატებლად
        /// </summary>
        [EnumMember(Value = "error")]
        Error = 2,

        /// <summary>
        /// გადახდის პროცესი არაა დასრულებული და თუ ორდერის გენერაციიდან 1 საათში მომხმარებელი არ დაასრულებს ტრანზაქციას, ის ავტომატურად გაუქმდება და გადავა error სტატუსზე. ეს სტატუსი ენიჭება გადახდას, როდესაც მომხმარებელი გადამისამართდება ბანკის ონლაინ გადახდის ვებგვერდზე, ხოლო ცვლილება ხდება გადახდის წარმატებით ან წარუმატებლად დასრულების შემდეგ
        /// </summary>
        [EnumMember(Value = "in_progress")]
        InProgress = 3

        //[EnumMember(Value = "REJECTED")]
        //Rejected
    }
}
