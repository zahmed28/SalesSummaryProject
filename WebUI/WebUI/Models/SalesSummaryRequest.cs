namespace WebUI.Models
{
    public class SalesSummaryRequest
    {
        public string SortBy { get; set; } = "Country";
        public string SortOrder { get; set; } = "asc";
        public string Country { get; set; } = string.Empty;        

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
