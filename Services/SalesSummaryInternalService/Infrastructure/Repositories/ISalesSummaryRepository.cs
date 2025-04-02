using SalesSummaryInternalService.Application.Queries;
using SalesSummaryInternalService.Domain;

namespace SalesSummaryInternalService.Infrastructure.Repositories
{
    public interface ISalesSummaryRepository
    {
        Task<SaleSummaryResponse> GetAllSalesSummary(SalesSummaryQuery salesSummaryQuery);
    }
}
