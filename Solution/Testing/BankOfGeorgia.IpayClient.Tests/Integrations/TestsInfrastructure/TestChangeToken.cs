using Microsoft.Extensions.Primitives;
using System;

namespace BankOfGeorgia.IpayClient.Tests.Integrations
{
    internal class TestChangeToken : IChangeToken
    {
        public bool HasChanged => false;

        public bool ActiveChangeCallbacks => false;

        public IDisposable RegisterChangeCallback(Action<object> callback, object state)
        {
            return null;
        }
    }
}
