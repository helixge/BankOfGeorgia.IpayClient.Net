using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankOfGeorgia.IpayClient.Tests.Integrations
{
    public class IServiceCollectionExtentionsTests
    {
        [Fact]
        public void AddBankOfGeorgiaIpayWithOptions_RegistersRequiredServices()
        {
            // Arrange
            var options = new BankOfGeorgiaIpayClientOptions()
            {
                ClientId = Guid.NewGuid().ToString(),
                SecretKey = Guid.NewGuid().ToString()
            };
            IServiceCollection services = new ServiceCollection();

            // Act
            services.AddBankOfGeorgiaIpay(options);

            // Assert
            var serviceProvider = services.BuildServiceProvider();
            var serviceProviderScope = serviceProvider.CreateScope();
            serviceProviderScope.ServiceProvider.GetService<IBankOfGeorgiaIpayClient>().Should().NotBeNull();
            serviceProviderScope.ServiceProvider.GetService<BankOfGeorgiaIpayClient>().Should().NotBeNull();
            serviceProviderScope.ServiceProvider.GetService<BankOfGeorgiaIpayClientOptions>().Should().NotBeNull();
            serviceProviderScope.ServiceProvider.GetService<IMappingService>().Should().NotBeNull();
            serviceProviderScope.ServiceProvider.GetService<MappingService>().Should().NotBeNull();
            serviceProviderScope.ServiceProvider.GetService<HttpClient>().Should().NotBeNull();
        }

        public void AddBankOfGeorgiaIpayWithConfiguration_RegistersRequiredServices()
        {
            //TODO: test theat the following service are resolvable:
            // - IBankOfGeorgiaIpayClient
            // - BankOfGeorgiaIpayClient
            // - BankOfGeorgiaIpayClientOptions
            // - IMappingService
            // - MappingService
            // - HttpClient for BankOfGeorgiaIpayClient

            // Arrange
            string key = Guid.NewGuid().ToString("N");
            var configurationBuilder = new ConfigurationBuilder();
            var configurationSource = new TestConfigurationSource(key);
            configurationBuilder.Add(configurationSource);
            IConfiguration configuration = configurationBuilder.Build();

            // Act

            // Assert
        }
    }
}
