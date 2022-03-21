using JWT.Algorithms;
using JWT.Builder;
using System;

namespace BankOfGeorgia.IpayClient
{
    public static class JwtHelper
    {
        /// <summary>
        /// iPay sets token exp date to creation time instead of expiration time,
        /// so the token is effectively expired.
        /// iPay Tokens expire in 60 seconds.
        /// This method manually adds 60 seconds to the token exp time for expiry calculation and token validation.
        /// The token is considered expired 5 seconds before the actual expiration to compensate for any delays 
        /// </summary>
        /// <param name="jwtToken"></param>
        /// <returns></returns>
        public static bool IsTokenValid(string jwtToken)
        {
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
