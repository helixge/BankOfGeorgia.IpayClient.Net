using JWT.Algorithms;
using JWT.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfGeorgia.IpayClient.TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            TestJsonExpirationValidation();

            await TestTransactionProcessing();
        }

        private static async Task TestTransactionProcessing()
        {
            BankOfGeorgiaIpayClient client = CreateClient();

            await client.AuthenticateAsync();
        }

        private static BankOfGeorgiaIpayClient CreateClient()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();
            var options = config.GetBankOfGeorgiaIpayClientOptions("iPay");
            var client = new BankOfGeorgiaIpayClient(options);
            return client;
        }

        private static void TestJsonExpirationValidation()
        {
            var jwtToken = "eyJraWQiOiIxMDA2IiwiY3R5IjoiYXBwbGljYXRpb25cL2pzb24iLCJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJQdWJsaWMgcGF5bWVudCBBUEkgVjEiLCJhdWQiOiJpUGF5IERlbW8iLCJpc3MiOiJodHRwczpcL1wvaXBheS5nZSIsImV4cCI6MTYwOTg2MDk4Mn0.ZBYmIz-tV_VktDFgKf5WsM-NsM8GDmpjn3fMHjYYyS8";
            var json = JwtHelper.IsTokenValid(jwtToken);
        }
    }
}
