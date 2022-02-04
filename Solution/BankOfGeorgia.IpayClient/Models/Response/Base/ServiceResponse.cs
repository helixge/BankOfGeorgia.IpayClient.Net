using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGeorgia.IpayClient
{
    public class ServiceResponse
    {


        public bool IsError { get; set; }
        public int HttpStatusCode { get; set; }
        public string RawResponse { get; set; }
        public Exception Exception { get; set; }
    }
}
