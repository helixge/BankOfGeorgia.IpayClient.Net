using System;
using System.Runtime.Serialization;

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
