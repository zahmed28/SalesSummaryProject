using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.TypeConversion;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SalesSummaryInternalService.Helpers
{
    public class SafeDecimalConverter : DecimalConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text)) return 0m;

            // Remove currency symbols, whitespace, and commas
            var cleaned = Regex.Replace(text, @"[^\d.-]", "");
            return decimal.TryParse(cleaned, NumberStyles.Any, CultureInfo.InvariantCulture, out var result)
                ? result
                : 0m;
        }
    }
}
