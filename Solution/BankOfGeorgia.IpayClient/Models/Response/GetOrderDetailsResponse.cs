//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BankOfGeorgia.IpayClient
//{
//    public class GetOrderDetailsResponse : ServiceResponse
//    {
//        [JsonProperty("id")]
//        public string Id { get; set; }

//        [JsonProperty("intent")]
//        public Intent Intent { get; set; }

//        [JsonProperty("payer")]
//        public OrderDetailsPayer Payer { get; set; }

//        [JsonProperty("purchaseUnit")]
//        public PurchaseUnit PurchaseUnit { get; set; }

//        [JsonProperty("createTime")]
//        public string CreateTime { get; set; }

//        [JsonProperty("updateTime")]
//        public string UpdateTime { get; set; }

//        [JsonProperty("errorHistory")]
//        public IEnumerable<OrderDetailsErrorHistory> ErrorHistory { get; set; }

//        public DateTimeOffset GetCraeteTime()
//            => DateTimeConversionHelper.ConvertIpayStringToDateTimeOffset(CreateTime);

//        public DateTimeOffset GetUpdateTime()
//            => DateTimeConversionHelper.ConvertIpayStringToDateTimeOffset(UpdateTime);
//    }
//}
