namespace WebUI.Models
{    
    public class SaleRecord
    {
        public string Segment { get; set; }
        public string Country { get; set; }
        public string Product { get; set; }

        public string DiscountBand { get; set; }

        public decimal UnitsSold { get; set; }

        public decimal ManufacturingPrice { get; set; }
        public string SalePrice { get; set; }
        public DateTime Date { get; set; }

    }

    public class SalesSummaryResponse
    {
        public List<SaleRecord> SaleRecordList { get; set; }
        public string ErrorMessage { get; set; }
        public int TotalRecords { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
