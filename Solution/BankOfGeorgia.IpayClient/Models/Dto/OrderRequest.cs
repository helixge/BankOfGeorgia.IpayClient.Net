using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGeorgia.IpayClient
{
    /// <summary>
    /// Purchase order request
    /// This is a DTO class that simplifies underlying iPay API request model
    /// </summary>
    public class OrderRequest
    {
        /// <summary>
        /// Intent is responsible for the payment method of the interface of the page that the user sees after the iPay transition.
        /// CAPTURE - provides several payment options for users, on the same page. Payment can be performed by card and with BOG digital credentials ( username &amp; password ).
        /// AUTHORIZE - Allows users to pay only with entering card details.
        /// </summary>
        public Intent Intent { get; set; }

        /// <summary>
        /// Localization on which ipay.ge payment page will be displayed. Defaulted to "ka" if not provided or invalid.
        /// Available values: "ka", "en-US"
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// Unique order ID in the shop
        /// </summary>
        public string ShopOrderId { get; set; }

        /// <summary>
        /// URL of the page to which the payer will be redirected after a successful or failure payment. Does not contain any data.
        /// </summary>
        public string RedirectUrl { get; set; }

        /// <summary>
        /// If the value is true, shop_order_id will appear in the extract.
        /// </summary>
        public bool ShowShopOrderIdOnExtract { get; set; }

        /// <summary>
        /// If value is MANUAL, amount is placed on hold and removed from available balance immediately.After that, you will need to complete pre-authorization by calling pre-auth/complete or unblock amount by calling refund. If you do not call one of these methods, the amount is automatically unlocked after 30 days.
        /// </summary>
        public CaptureMethod CaptureMethod { get; set; }

        /// <summary>
        /// Purchase unit currency
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Products
        /// </summary>
        public IEnumerable<OrderItem> Items { get; set; }
    }
}
