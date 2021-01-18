namespace BankOfGeorgia.IpayClient
{
    public enum Intent
    {
        /// <summary>
        /// Provides several payment options for users, on the same page. Payment can be performed by card and with BOG digital credentials ( username & password )
        /// </summary>
        Capture,

        /// <summary>
        /// Allows users to pay only with entering card details
        /// </summary>
        Authorize,

        /// <summary>
        ///  Users can pay with only installment option. For this user should enter BOG credentials, username / password and go through installment payment process. LOAN minimum amount is 50 GEL and maximum amount is 4900 GEL
        /// </summary>
        Loan
    }
}
