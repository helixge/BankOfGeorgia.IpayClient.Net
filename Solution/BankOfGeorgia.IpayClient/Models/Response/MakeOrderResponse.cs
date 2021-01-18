using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGeorgia.IpayClient
{
    public class MakeOrderResponse : ServiceResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("payment_hash")]
        public string PaymentHash { get; set; }

        [JsonProperty("links")]
        public List<Link> Links { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }
    }

    public class Link
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("rel")]
        public string Rel { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }
    }
}
