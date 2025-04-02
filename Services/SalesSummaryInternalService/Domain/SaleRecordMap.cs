using CsvHelper.Configuration;
using SalesSummaryInternalService.Helpers;

namespace SalesSummaryInternalService.Domain
{
    public class SaleRecordMap : ClassMap<SaleRecord>
    {
        public SaleRecordMap()
        {
            Map(m => m.Segment).Name("Segment");
            Map(m => m.Country).Name("Country");
            Map(m => m.Product).Name(" Product ");
            Map(m => m.DiscountBand).Name(" Discount Band ");
            Map(m => m.UnitsSold).Name("Units Sold").TypeConverter<SafeDecimalConverter>(); 
            Map(m => m.ManufacturingPrice).Name("Manufacturing Price").TypeConverter<SafeDecimalConverter>();
            Map(m => m.SalePrice).Name("Sale Price");
            Map(m => m.Date).Name("Date");
        }

    }
}
