using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankOfGeorgia.IpayClient.Tests.Serialization
{
    public class StringDecimalConversionHelperTests
    {
        // ConvertDecimalToString
        [Fact]
        public void ConvertDecimalToString_WhenNoDecimalPoints_DoesNotAppend0()
        {
            // Arrange
            decimal input = 10.0m;

            // Act
            string result = StringDecimalConversionHelper.ConvertDecimalToString(input);

            // Assert
            result.Should().Be("10");
        }

        //TODO:
        public void ConvertDecimalToString_WhenDecimalPoints_ContainsOnlyOneDot()
        {

        }

        public void ConvertDecimalToString_WhenGreaterThanThousand_DoesNotContainSpaces()
        {

        }

        // ConvertStringToDecimal

        public void ConvertStringToDecimal_WhenContainsThousandsSeparatorSpace_Converts()
        {

        }

        public void ConvertStringToDecimal_WhenContainsDecimalSepratorComma_Converts()
        {

        }

        public void ConvertStringToDecimal_WhenContainsDecimalSepratorDot_Converts()
        {

        }
    }
}
