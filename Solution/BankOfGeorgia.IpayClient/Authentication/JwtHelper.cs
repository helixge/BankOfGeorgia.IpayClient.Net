using JWT.Algorithms;
using JWT.Builder;
using System;

namespace BankOfGeorgia.IpayClient
{
    public static class JwtHelper
    {
        public static bool IsTokenValid(string jwtToken)
        {
            // iPay sets token exp date to creation time instead of expiration time.
            // This method manually adds 60 seconds to the token exp time for expiry calculation and token validation
            // 60 seconds is the default token lifespan

            JwtPayload json = new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .DoNotVerifySignature()
                .Decode<JwtPayload>(jwtToken);

            var epochNow = DateTimeOffset.Now.ToUnixTimeSeconds();
            var diff = json.exp + 60 - epochNow;

            return diff > 5;
        }
    }
}
