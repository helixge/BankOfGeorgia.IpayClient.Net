using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGeorgia.IpayClient
{
    public class CompletePreAuthPaymentResponse : BaseResponse
    {
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
