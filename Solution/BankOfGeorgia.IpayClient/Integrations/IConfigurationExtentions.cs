using BankOfGeorgia.IpayClient;

namespace Microsoft.Extensions.Configuration
{
    public static class IConfigurationExtentions
    {
        public static BankOfGeorgiaIpayClientOptions GetBankOfGeorgiaIpayClientOptions(this IConfiguration configuration, string key)
        {
            var configurationSection = configuration
                .GetSection(key);

            var options = configurationSection
                .Get<BankOfGeorgiaIpayClientOptions>();

            if (options == null)
                throw new IpayClientConfigurationException($"Bank of Georgia iPay configuration not found with key: {key}");

            return options;
        }
    }
}
