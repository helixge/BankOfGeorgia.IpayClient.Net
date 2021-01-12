using BankOfGeorgia.IpayClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.Configuration
{
    public static class IConfigurationExtentions
    {
        public static BankOfGeorgiaIpayClientOptions GetTbcBankEcommerceOptions(this IConfiguration configuration, string key)
        {
            var configurationSection = configuration
                .GetSection(key);

            var options = configurationSection
                .Get<BankOfGeorgiaIpayClientOptions>();

            if (options == null)
                throw new BankOfGeorgiaIpayClientConfigurationException($"Bank of Georgia iPay configuration not found with key: {key}");

            return options;
        }
    }
}
