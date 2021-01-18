using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGeorgia.IpayClient
{
    public class CompletePreAuthPaymentResponse : ServiceResponse
    {
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
