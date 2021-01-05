using JWT.Algorithms;
using JWT.Builder;
using System;

namespace BankOfGeorgia.IpayClient.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestJsonExpirationValidation();
        }

        private static void TestJsonExpirationValidation()
        {
            var jwtToken = "eyJraWQiOiIxMDA2IiwiY3R5IjoiYXBwbGljYXRpb25cL2pzb24iLCJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJQdWJsaWMgcGF5bWVudCBBUEkgVjEiLCJhdWQiOiJpUGF5IERlbW8iLCJpc3MiOiJodHRwczpcL1wvaXBheS5nZSIsImV4cCI6MTYwOTg2MDk4Mn0.ZBYmIz-tV_VktDFgKf5WsM-NsM8GDmpjn3fMHjYYyS8";

            var json = JwtHelper.IsTokenValid(jwtToken);
        }
    }
}
