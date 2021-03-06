﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGeorgia.IpayClient
{
    public class IpayOrder
    {
        /// <summary>
        /// Intent is responsible for the payment method of the interface of the page that the user sees after the iPay transition.
        /// CAPTURE - provides several payment options for users, on the same page. Payment can be performed by card and with BOG digital credentials ( username &amp; password ).
        /// AUTHORIZE - Allows users to pay only with entering card details.
        /// LOAN - users can pay with only installment option. For this user should enter BOG credentials, username / password and go through installment payment process. LOAN minimum amount is 50 GEL and maximum amount is 4900 GEL
        /// </summary>
        [JsonProperty("intent")]
        public Intent Intent { get; set; }

        /// <summary>
        /// Products
        /// </summary>
        [JsonProperty("items")]
        public IEnumerable<IpayOrderItem> Items { get; set; }

        /// <summary>
        /// Localization on which ipay.ge payment page will be displayed. Defaulted to "ka" if not provided or invalid.
        /// Available values: "ka", "en-US"
        /// </summary>
        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("shop_order_id")]
        public string ShopOrderId { get; set; }

        /// <summary>
        /// URL of the page to which the payer will be redirected after a successful or failure payment. Does not contain any data.
        /// </summary>
        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }

        /// <summary>
        /// If the value is true, shop_order_id will appear in the extract.
        /// </summary>
        [JsonProperty("show_shop_order_id_on_extract")]
        public bool ShowShopOrderIdOnExtract { get; set; }

        /// <summary>
        /// Used in case the offer is valid for installment plan.
        /// </summary>
        [JsonProperty("loan_code")]
        public string LoanCode { get; set; }

        /// <summary>
        /// Used for recurring payment. For a recurring payment, you need the transaction_id of a successful customer payment.
        /// </summary>
        [JsonProperty("card_transaction_id")]
        public string CardTransactionId { get; set; }

        /// <summary>
        /// If value is MANUAL, amount is placed on hold and removed from available balance immediately.After that, you will need to complete pre-authorization by calling pre-auth/complete or unblock amount by calling refund. If you do not call one of these methods, the amount is automatically unlocked after 30 days.
        /// </summary>
        [JsonProperty("capture_method")]
        public CaptureMethod CaptureMethod { get; set; }

        [JsonProperty("purchase_units")]
        public IEnumerable<OrderRequestPurchaseUnit> PurchaseUnits { get; set; }
    }
}
