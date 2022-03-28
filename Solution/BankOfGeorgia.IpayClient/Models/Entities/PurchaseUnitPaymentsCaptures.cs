using Newtonsoft.Json;
using System;

namespace BankOfGeorgia.IpayClient
{
    public class PurchaseUnitPaymentsCapture
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("final_capture")]
        public bool FinalCapture { get; set; }

        [JsonProperty("create_time")]
        public string CreateTime { get; set; }

        [JsonProperty("update_time")]
        public string UpdateTime { get; set; }

        [JsonProperty("amount")]
        public Amount Amount { get; set; }

        public DateTimeOffset GetCraeteTime()
         => DateTimeConversionHelper.ConvertIpayStringToDateTimeOffset(CreateTime);

        public DateTimeOffset GetUpdateTime()
            => DateTimeConversionHelper.ConvertIpayStringToDateTimeOffset(UpdateTime);
    }
}