using FluentAssertions;
using JWT.Algorithms;
using JWT.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankOfGeorgia.IpayClient.Tests.Authentication
{
    public class JwtHelperTests
    {
        [Fact]
        public void IsTokenValid_WhenExpIsLessThanMinutePassed_ReturnsTrue()
        {
            // Arrange
            List<string> tokens = new List<string>();
            for (int second = 0; second < 50; second++)
            {
                DateTimeOffset exp = DateTimeOffset.Now.AddSeconds(-second);
                string token = CreateToken(exp);
                tokens.Add(token);
            }

            // Act
            List<bool> results = new List<bool>();
            foreach (string token in tokens)
            {
                bool isValid = JwtHelper.IsTokenValid(token);
                results.Add(isValid);
            }

            // Arrange
            results.Should().AllBeEquivalentTo(true);
        }

        [Fact]
        public void IsTokenValid_WhenExpIsMoreThanMinutePassed_ReturnsFalse()
        {
            // Arrange
            List<string> tokens = new List<string>();
            for (int second = 55; second < 70; second++)
            {
                DateTimeOffset exp = DateTimeOffset.Now.AddSeconds(-second);
                string token = CreateToken(exp);
                tokens.Add(token);
            }

            // Act
            List<bool> results = new List<bool>();
            foreach (string token in tokens)
            {
                bool isValid = JwtHelper.IsTokenValid(token);
                results.Add(isValid);
            }

            // Arrange
            results.Should().AllBeEquivalentTo(false);
        }

        private string CreateToken(DateTimeOffset exp)
        {
            return JwtBuilder.Create()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret("secret")
                .AddClaim("exp", exp.ToUnixTimeSeconds())
                .Encode();
        }
    }
}
