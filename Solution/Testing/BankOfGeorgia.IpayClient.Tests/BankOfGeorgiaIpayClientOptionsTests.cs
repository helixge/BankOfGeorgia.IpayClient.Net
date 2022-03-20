using FluentAssertions;
using System;
using Xunit;

namespace BankOfGeorgia.IpayClient.Tests
{
    public class BankOfGeorgiaIpayClientOptionsTests
    {
        [Fact]
        public void BankOfGeorgiaIpayClientOptions_ConstructoParamatersAreAssigned()
        {
            // Arrange
            string clientId = Guid.NewGuid().ToString();
            string secretKey = Guid.NewGuid().ToString();

            // Act
            var options = new BankOfGeorgiaIpayClientOptions(clientId, secretKey);

            // Assert
            options.ClientId.Should().Be(clientId);
            options.SecretKey.Should().Be(secretKey);
        }
    }
}
