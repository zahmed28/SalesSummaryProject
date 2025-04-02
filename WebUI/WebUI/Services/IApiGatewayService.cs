using WebUI.Models;

namespace WebUI.Services
{
    public interface IApiGatewayService
    {
        Task<SalesSummaryResponse> GetSalesSummaryAsync(SalesSummaryRequest query);
    }
}
