using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGeorgia.IpayClient
{
    public class ServiceResponse
    {
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }

        [JsonProperty("information_link")]
        public string InformationLink { get; set; }


        public bool IsError { get; set; }
        public int HttpStatusCode { get; set; }
        public string RawResponse { get; set; }
        public Exception Exception { get; set; }
    }
}
