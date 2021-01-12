using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BankOfGeorgia.IpayClient
{
    [Serializable]
    public class BankOfGeorgiaIpayClientConfigurationException : Exception
    {
        public BankOfGeorgiaIpayClientConfigurationException()
        {
        }

        public BankOfGeorgiaIpayClientConfigurationException(string message) : base(message)
        {
        }

        public BankOfGeorgiaIpayClientConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BankOfGeorgiaIpayClientConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
