using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGeorgia.IpayClient
{
    public class AuthenticateResponse : BaseResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string app_id { get; set; }
        /// <summary>
        /// Epoch milliseconds
        /// </summary>
        public long expires_in { get; set; }
    }
}
