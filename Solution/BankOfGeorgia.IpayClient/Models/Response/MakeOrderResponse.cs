using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGeorgia.IpayClient
{
    public class MakeOrderResponse : ServiceResponse
    {
        public string Status { get; set; }
        public string PaymentHash { get; set; }
        public List<Link> Links { get; set; }
        public string OrderId { get; set; }
    }

    public class Link
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }
    }
}
