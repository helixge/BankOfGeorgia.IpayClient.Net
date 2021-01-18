using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGeorgia.IpayClient
{
    public class IpayOrder
    {
        [JsonProperty("intent")]
        public Intent Intent { get; set; }

        [JsonProperty("items")]
        public IEnumerable<OrderItem> Items { get; set; }

        /// <summary>
        /// Localization on which ipay.ge payment page will be displayed. Defaulted to ka if not provided or invalid.
        /// Available values: "ka" "en-US"
        /// </summary>
        [JsonProperty("locale")]
        public string Locale { get; set; }

        public string shop_order_id { get; set; }

        /// <summary>
        /// URL of the page to which the payer will be redirected after a successful or failure payment. Does not contain any data.
        /// </summary>
        public string redirect_url { get; set; }

        /// <summary>
        /// If the value is true, shop_order_id will appear in the extract.
        /// </summary>
        public bool show_shop_order_id_on_extract { get; set; }

        /// <summary>
        /// Used in case the offer is valid for installment plan.
        /// </summary>
        public string loan_code { get; set; }

        /// <summary>
        /// Used for recurring payment. For a recurring payment, you need the transaction_id of a successful customer payment.
        /// </summary>
        public string card_transaction_id { get; set; }

        /// <summary>
        /// If value is MANUAL, amount is placed on hold and removed from available balance immediately.After that, you will need to complete pre-authorization by calling pre-auth/complete or unblock amount by calling refund. If you do not call one of these methods, the amount is automatically unlocked after 30 days.
        /// </summary>
        public CaptureMethod capture_method { get; set; }

        public IEnumerable<OrderRequestPurchaseUnit> OrderRequestPurchaseUnit { get; set; }
    }
}
