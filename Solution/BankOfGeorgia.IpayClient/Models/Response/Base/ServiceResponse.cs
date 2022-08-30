using System;

namespace BankOfGeorgia.IpayClient
{
    public class ServiceResponse
    {
        public bool IsError { get; set; }
        public int HttpStatusCode { get; set; }
        public string RawResponse { get; set; }
        public Exception Exception { get; set; }
        public string RequestURL { get; set; }
        public string RequestMethod { get; set; }
        public string RawRequestPayload { get; set; }
    }
}
