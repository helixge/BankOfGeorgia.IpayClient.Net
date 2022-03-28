using BankOfGeorgia.IpayClient;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// ASP.NET Core service collection extentions for service configuration
    /// </summary>
    public static class IServiceCollectionExtentions
    {
        /// <summary>
        /// Add services required for iPay
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="settingsKey"></param>
        /// <returns></returns>
        public static IServiceCollection AddBankOfGeorgiaIpay(this IServiceCollection services, IConfiguration configuration, string settingsKey)
        {
            var configurationSection = configuration
                .GetSection(settingsKey);

            var options = configurationSection
                .Get<BankOfGeorgiaIpayClientOptions>();

            return AddBankOfGeorgiaIpay(services, options);
        }

        /// <summary>
        /// Add services required for iPay
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IServiceCollection AddBankOfGeorgiaIpay(this IServiceCollection services, BankOfGeorgiaIpayClientOptions options)
        {
            services
                .AddScoped<IBankOfGeorgiaIpayClient, BankOfGeorgiaIpayClient>();

            services
                .AddScoped<BankOfGeorgiaIpayClientOptions>(serviceProvider => options);

            services
               .AddSingleton<IMappingService, MappingService>()
               .AddSingleton<MappingService>();

            services
                .AddHttpClient<BankOfGeorgiaIpayClient, BankOfGeorgiaIpayClient>();

            return services;
        }
    }
}
