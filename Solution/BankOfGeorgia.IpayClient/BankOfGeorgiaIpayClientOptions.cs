namespace BankOfGeorgia.IpayClient
{
    /// <summary>
    /// Configuration options for BankOfGeorgiaIpayClient
    /// </summary>
    public class BankOfGeorgiaIpayClientOptions
    {
        /// <summary>
        /// The parameter is provided by the Bank of Georgia
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// The parameter is provided by the Bank of Georgia
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// Optional parameter to manually set the BaseUrl
        /// By default 'https://ipay.ge/opay/api/v1' endpoint will be used but
        /// you can override this parameter if you want to use the demo endpoint
        /// described here: https://github.com/BankOfGeorgia/iPay-ASP.NET-Core#ipay-demo
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Construct empty options
        /// </summary>
        public BankOfGeorgiaIpayClientOptions()
        {

        }

        /// <summary>
        /// Construct options
        /// </summary>
        /// <param name="clientId">The parameter is provided by the Bank of Georgia</param>
        /// <param name="secretKey">The parameter is provided by the Bank of Georgia</param>
        public BankOfGeorgiaIpayClientOptions(
            string clientId,
            string secretKey
            )
            : this()
        {
            ClientId = clientId;
            SecretKey = secretKey;
        }
    }
}
