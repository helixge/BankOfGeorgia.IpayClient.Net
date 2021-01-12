using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGeorgia.IpayClient
{
    public class GetOrderDetailsResponse : BaseResponse
    {
        public string OrderId { get; set; }
        public Intent Intent { get; set; }
        public IEnumerable<PurchaseUnit> PurchaseUnits { get; set; }
    }
}
