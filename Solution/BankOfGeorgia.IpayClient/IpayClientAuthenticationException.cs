using System;
using System.Runtime.Serialization;

namespace BankOfGeorgia.IpayClient
{
    [Serializable]
    internal class IpayClientAuthenticationException : Exception
    {
        public AuthenticateResponse Result { get; }

        public IpayClientAuthenticationException()
        {
        }

        public IpayClientAuthenticationException(AuthenticateResponse result)
        {
            this.Result = result;
        }

        public IpayClientAuthenticationException(string message) : base(message)
        {
        }

        public IpayClientAuthenticationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IpayClientAuthenticationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}