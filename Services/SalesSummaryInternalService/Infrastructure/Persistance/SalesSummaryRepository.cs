using CsvHelper;
using SalesSummaryInternalService.Application.Queries;
using SalesSummaryInternalService.Domain;
using SalesSummaryInternalService.Infrastructure.Repositories;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace SalesSummaryInternalService.Infrastructure.Persistance
{
    public class SalesSummaryRepository : ISalesSummaryRepository
    {
        private readonly ILogger<SalesSummaryRepository> _logger;
        private readonly IConfiguration _configuration;
        public SalesSummaryRepository(ILogger<SalesSummaryRepository> logger, IConfiguration configuration)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger), "Logger cannot be null.");
            _configuration = configuration;
        }
        public async Task<SaleSummaryResponse> GetAllSalesSummary(SalesSummaryQuery salesSummaryQuery)
        {
            SaleSummaryResponse _saleSummaryResponse = new SaleSummaryResponse();
            string filePath = Path.Combine(Environment.CurrentDirectory, "SalesData", "data.csv");
            using var reader = new StreamReader(filePath, Encoding.GetEncoding("Windows-1252"));
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<SaleRecordMap>();
            var allRecords =  csv.GetRecords<SaleRecord>().ToList();

            if (!string.IsNullOrWhiteSpace(salesSummaryQuery.Country))
            {
                allRecords = allRecords
                    .Where(r => r.Country.Contains(salesSummaryQuery.Country, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            
            var prop = typeof(SaleRecord).GetProperty(salesSummaryQuery.SortBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (prop != null)
            {
                allRecords = salesSummaryQuery.SortOrder == "desc"
                    ? allRecords.OrderByDescending(x => prop.GetValue(x)).ToList()
                    : allRecords.OrderBy(x => prop.GetValue(x)).ToList();
            }

            var totalRecords = allRecords.Count;
            var pagedData = allRecords
                .Skip((salesSummaryQuery.Page - 1) * salesSummaryQuery.PageSize)
                .Take(salesSummaryQuery.PageSize)
                .ToList();

            return new SaleSummaryResponse 
            {
                SaleRecordList = pagedData,
                TotalRecords = totalRecords,
                Page = salesSummaryQuery.Page,
                PageSize = salesSummaryQuery.PageSize
            };            
        }
    }
}
