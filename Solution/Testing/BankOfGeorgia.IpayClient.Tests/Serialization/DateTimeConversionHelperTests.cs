using FluentAssertions;
using System;
using Xunit;

namespace BankOfGeorgia.IpayClient.Tests.Serialization
{
    public class DateTimeConversionHelperTests
    {
        [Fact]
        public void ConvertIpayStringToDateTimeOffset_ValidValue_Succeeds()
try
{

}
finally
{

}        {
            // Arrange
            string sourceValue = "Wed Jan 12 17:45:42 GET 2022";

        // Act
        DateTimeOffset actual = DateTimeConversionHelper.ConvertIpayStringToDateTimeOffset(sourceValue);

        // Assert
        DateTimeOffset expected = new DateTimeOffset(2022, 1, 12, 17, 45, 42, TimeSpan.FromHours(4));
        actual.Should().Be(expected);
    }
}
}
