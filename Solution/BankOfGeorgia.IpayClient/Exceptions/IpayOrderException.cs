using System;
using System.Runtime.Serialization;

namespace BankOfGeorgia.IpayClient
{
    [Serializable]
    internal class IpayOrderException : Exception
    {
        public IpayOrderException()
        {
        }

        public IpayOrderException(string message) : base(message)
        {
        }

        public IpayOrderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IpayOrderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}