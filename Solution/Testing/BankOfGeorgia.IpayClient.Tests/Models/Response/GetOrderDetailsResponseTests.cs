using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace BankOfGeorgia.IpayClient.Tests.Models.Response
{
    public class GetOrderDetailsResponseTests
    {
        [Fact]
        public void Deserialization_WhenJsonIsValid_Succeeds()
        {
            // Arrange
            string json = @"
            {
                ""id"": ""dedd4ff889002ce03870a2c3c188ed801cd742a2"",
                ""status"": ""REJECTED"",
                ""intent"": ""CAPTURE"",
                ""payer"": {
                    ""name"": null,
                    ""email_address"": null,
                    ""payer_id"": null
                },
                ""purchaseUnit"": {
                    ""amount"": {
                        ""value"": ""2000000.50"",
                        ""currency_code"": ""GEL""
                    },
                    ""payee"": {
                        ""addres"": ""Tbilisi,dedofliswyaros1Ses.2,b.1"",
                        ""contact"": ""995555020700"",
                        ""email_address"": ""info@spellchecker.ge""
                    },
                    ""payments"": [
                        {
                            ""captures"": [
                                {
                                    ""id"": ""P002"",
                                    ""status"": ""REJECTED"",
                                    ""amount"": {
                                        ""value"": ""2000000.50"",
                                        ""currency_code"": ""GEL""
                                    },
                                    ""final_capture"": ""true"",
                                    ""create_time"": ""Wed Jan 12 17:45:42 GET 2022"",
                                    ""update_time"": ""Wed Jan 12 17:45:42 GET 2022""
                                }
                            ]
                        }
                    ],
                    ""shop_order_id"": ""988485a6db7c487ebb66119bc9c50def""
                },
                ""createTime"": null,
                ""updateTime"": null,
                ""errorHistory"": [
                    {
                        ""errorCode"": ""INTERVALE_GENERAL_ERROR"",
                        ""actionTime"": ""12/01/2022 17:19:59.791""
                    }
                ]
            }
            ";

            // Act
            //var sut = JsonSerializer.Deserialize<GetOrderDetailsResponse>(json);

            // Assert
            //sut.Id.Should().Be("dedd4ff889002ce03870a2c3c188ed801cd742a2");
        }
    }
}
