using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGeorgia.IpayClient
{
    public class BankOfGeorgiaIpayClientOptions
    {
        public string ClientId { get; set; }
        public string SecretKey { get; set; }

        public BankOfGeorgiaIpayClientOptions()
        {

        }

        public BankOfGeorgiaIpayClientOptions(
            string clientId,
            string secretKey
            )
            : this()
        {
            ClientId = clientId;
            SecretKey = secretKey;
        }
    }
}
