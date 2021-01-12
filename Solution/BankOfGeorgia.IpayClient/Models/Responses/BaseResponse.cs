using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGeorgia.IpayClient
{
    public class BaseResponse
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Details { get; set; }
        public string InformationLink { get; set; }
    }
}
