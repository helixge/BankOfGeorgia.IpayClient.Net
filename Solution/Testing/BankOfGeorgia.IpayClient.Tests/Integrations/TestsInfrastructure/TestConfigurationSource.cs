using Microsoft.Extensions.Configuration;

namespace BankOfGeorgia.IpayClient.Tests.Integrations
{
    internal class TestConfigurationSource : IConfigurationSource
    {
        private readonly TestConfigurationProvider _configurationProvider;

        public string ClientId => _configurationProvider.ClientId;
        public string SecretKey => _configurationProvider.SecretKey;

        public TestConfigurationSource(string key)
        {
            _configurationProvider = new TestConfigurationProvider(key);
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return _configurationProvider;
        }
    }
}
