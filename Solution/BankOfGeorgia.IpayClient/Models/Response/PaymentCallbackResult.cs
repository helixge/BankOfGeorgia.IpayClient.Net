using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGeorgia.IpayClient
{
    public abstract class CallbackResponse
    {
        [BindProperty(Name = "order_id")]
        public string OrderId { get; set; }

        [BindProperty(Name = "payment_hash")]
        public string PaymentHash { get; set; }

        [BindProperty(Name = "ipay_payment_id")]
        public string IpayPaymentId { get; set; }

        [BindProperty(Name = "status_description")]
        public string StatusDescription { get; set; }

        [BindProperty(Name = "shop_order_id")]
        public string ShopOrderId { get; set; }

        [BindProperty(Name = "payment_method")]
        public PaymentMethod PaymentMethod { get; set; }

        [BindProperty(Name = "card_type")]
        public CardType CardType { get; set; }
    }

    public class PaymentCallbackResult : CallbackResponse
    {
        [BindProperty(Name = "status")]
        public PaymentStatus Status { get; set; }

        [BindProperty(Name = "pan")]
        public string Pan { get; set; }

        [BindProperty(Name = "transaction_id")]
        public string TransactionId { get; set; }

        [BindProperty(Name = "pre_auth_status")]
        public PreAuthStatus PreAuthStatus { get; set; }
    }

    public class RefundCallbackResult : CallbackResponse
    {

    }
}
