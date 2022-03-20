using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfGeorgia.IpayClient.Tests.Integrations
{
    public class IServiceCollectionExtentionsTests
    {
        public void AddBankOfGeorgiaIpayWithOptions_RegistersRequiredServices()
        {
            //TODO: test theat the following service are resolvable:
            // - IBankOfGeorgiaIpayClient
            // - BankOfGeorgiaIpayClient
            // - BankOfGeorgiaIpayClientOptions
            // - IMappingService
            // - MappingService
            // - HttpClient for BankOfGeorgiaIpayClient

            // Arrange

            // Act

            // Assert
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
