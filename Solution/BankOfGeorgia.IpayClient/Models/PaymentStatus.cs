﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace BankOfGeorgia.IpayClient
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentStatus
    {
        [EnumMember(Value = "success")]
        Success,
        
        [EnumMember(Value = "error")]
        Error,
        
        [EnumMember(Value = "in_progress")]
        InProgress
    }
}
