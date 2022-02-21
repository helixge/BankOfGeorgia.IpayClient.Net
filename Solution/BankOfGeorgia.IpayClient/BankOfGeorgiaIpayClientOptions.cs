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
