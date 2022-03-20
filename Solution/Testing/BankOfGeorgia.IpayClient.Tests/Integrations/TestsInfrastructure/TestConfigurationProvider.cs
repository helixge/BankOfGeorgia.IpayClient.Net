using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankOfGeorgia.IpayClient.Tests.Integrations
{
    internal class TestConfigurationProvider : IConfigurationProvider
    {
        private readonly IChangeToken _changeToken;
        private readonly string _key;

        public string ClientId { get; }
        public string SecretKey { get; }


        public TestConfigurationProvider(string key)
        {
            _changeToken = new TestChangeToken();
            _key = key;

            ClientId = Guid.NewGuid().ToString("N");
            SecretKey = Guid.NewGuid().ToString("N");
        }

        public IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string parentPath)
        {
            if (parentPath != _key)
            {
                return Enumerable.Empty<string>();
            }

            return new string[] { "ClientId", "SecretKey" };
        }

        public IChangeToken GetReloadToken()
        {
            return _changeToken;
        }

        public void Load()
        {

        }

        public void Set(string key, string value)
        {

        }

        public bool TryGet(string key, out string value)
        {
            if (key == _key)
            {
                value = "{ \"ClientId\": \"" + ClientId + "\", \"SecretKey\": \"" + SecretKey + "\" }";
                return true;
            }

            if (key == $"{_key}:ClientId")
            {
                value = ClientId;
                return true;
            }

            if (key == $"{_key}:SecretKey")
            {
                value = SecretKey;
                return true;
            }

            value = null;
            return false;
        }
    }
}
