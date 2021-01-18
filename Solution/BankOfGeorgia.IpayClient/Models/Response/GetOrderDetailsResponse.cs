using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGeorgia.IpayClient
{
    public class GetOrderDetailsResponse : ServiceResponse
    {
        public string OrderId { get; set; }
        public Intent Intent { get; set; }
        public IEnumerable<CheckPurchaseUnit> PurchaseUnits { get; set; }
    }
}
