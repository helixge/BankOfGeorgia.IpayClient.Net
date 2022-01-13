using System;
using System.Globalization;

namespace BankOfGeorgia.IpayClient
{
    public static class DateTimeConversionHelper
    {
        private const string _ipayDateFormat = "ddd MMM dd HH:mm:ss 'GET' yyyy";

        public static DateTimeOffset ConvertIpayStringToDateTimeOffset(string value)
        {
            return DateTime.ParseExact(value, _ipayDateFormat, CultureInfo.InvariantCulture);
        }
    }
}
