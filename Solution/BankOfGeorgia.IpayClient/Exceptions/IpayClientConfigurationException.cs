using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BankOfGeorgia.IpayClient
{
    [Serializable]
    public class IpayClientConfigurationException : Exception
    {
        public IpayClientConfigurationException()
        {
        }

        public IpayClientConfigurationException(string message) : base(message)
        {
        }

        public IpayClientConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IpayClientConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
