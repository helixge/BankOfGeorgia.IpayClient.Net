using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGeorgia.IpayClient
{
    public class CompletePreAuthPaymentRequest
    {
        [JsonProperty("auth_type")]
        public string AuthType { get; set; }

        [JsonProperty("amount")]
        public decimal? Amount { get; set; }
    }
}
