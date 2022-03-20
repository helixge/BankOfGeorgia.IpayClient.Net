using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankOfGeorgia.IpayClient.Tests.Integrations
{
    public class IConfigurationExtentionsTests
    {
        [Fact]
        public void GetBankOfGeorgiaIpayClientOptions_ReadsSectionNamedByKeyParamter()
        {
            // Arrange
            string key = Guid.NewGuid().ToString("N");
            var configurationBuilder = new ConfigurationBuilder();
            var configurationSource = new TestConfigurationSource(key);
            configurationBuilder.Add(configurationSource);
            IConfiguration configuration = configurationBuilder.Build();

            // Act
            BankOfGeorgiaIpayClientOptions options = configuration.GetBankOfGeorgiaIpayClientOptions(key);

            //Arrange
            options.ClientId.Should().Be(configurationSource.ClientId);
            options.SecretKey.Should().Be(configurationSource.SecretKey);
        }
    }
}
