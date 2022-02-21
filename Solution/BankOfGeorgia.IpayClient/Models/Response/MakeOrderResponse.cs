using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Get redirect URL to navigate the client to after succesfully registering transaction
        /// </summary>
        /// <returns></returns>
        /// <exception cref="IpayOrderException">Thrown when Links is null or redirect link not found</exception>
        public string GetRedirectUrl()
        {
            if (Links == null)
            {
                throw new IpayOrderException("Links value is null");
            }

            var redirectLink = Links
                .FirstOrDefault(l => l.Method == "REDIRECT")
                ?.Href;

            if (redirectLink == null)
            {
                throw new IpayOrderException("Links value is null");
            }

            return redirectLink;
        }
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
