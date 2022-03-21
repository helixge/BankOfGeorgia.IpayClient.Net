using AutoFixture;
using FluentAssertions;

namespace BankOfGeorgia.IpayClient.Tests.Services
{
    public class MappingServiceTests
    {
        public void CreateIpayOrderRequest_MapsAppValues()
        {
            // Arrange
            var fixture = new Fixture();
            var orderRequest = fixture.Create<OrderRequest>();
            var service = new MappingService();

            // Act
            IpayOrderRequest mappedRequest = service.CreateIpayOrderRequest(orderRequest);

            // Assert
            mappedRequest.CaptureMethod.Should().Be(orderRequest.CaptureMethod);
            // TODO: assert all properties
        }
    }
}
