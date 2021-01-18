using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGeorgia.IpayClient
{
    public class CompletePreAuthPaymentResponse : ServiceResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
