using System;
using System.Collections.Generic;
using System.Text;

namespace BankOfGeorgia.IpayClient
{
    public static class StringDecimalConversionHelper
    {
        public static string ConvertDecimalToString(decimal value)
        {
            return value
                .ToString("#.00")
                .Replace(",", ".")
                .Replace(" ", String.Empty);
        }

        public static decimal ConvertStringToDecimal(string value)
        {
            var cleanValue = value
                ?.Replace(",", ".")
                ?.Replace(" ", String.Empty);

            return Decimal.Parse(cleanValue);
        }
    }
}
