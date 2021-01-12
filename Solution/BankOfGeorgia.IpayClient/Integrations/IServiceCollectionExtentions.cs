using BankOfGeorgia.IpayClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtentions
    {
        public static IServiceCollection AddBankOfGeorgiaIpay(this IServiceCollection services, IConfiguration configuration, string settingsKey)
        {
            var configurationSection = configuration
                .GetSection(settingsKey);

            var options = configurationSection
                .Get<BankOfGeorgiaIpayClientOptions>();

            return AddBankOfGeorgiaIpay(services, options);
        }

        public static IServiceCollection AddBankOfGeorgiaIpay(this IServiceCollection services, BankOfGeorgiaIpayClientOptions options)
        {
            services
                .AddTransient<BankOfGeorgiaIpayClient, BankOfGeorgiaIpayClient>();

            services
                .AddTransient<BankOfGeorgiaIpayClientOptions>(serviceProvider => options);

            return services;
        }
    }
}
