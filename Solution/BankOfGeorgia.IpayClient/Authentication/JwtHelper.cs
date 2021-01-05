using JWT.Algorithms;
using JWT.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGeorgia.IpayClient
{
    public static class JwtHelper
    {
        public static bool IsTokenValid(string jwtToken)
        {
            var json = new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .DoNotVerifySignature()
                .Decode<JwtPayload>(jwtToken)
                ;

            var epochNow = DateTimeOffset.Now.ToUnixTimeSeconds();
            var diff = json.exp - epochNow;

            return diff > 5;
        }
    }
}
