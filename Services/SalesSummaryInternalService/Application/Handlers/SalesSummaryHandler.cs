using MediatR;
using SalesSummaryInternalService.Application.Queries;
using SalesSummaryInternalService.Domain;
using SalesSummaryInternalService.Infrastructure.Repositories;

namespace SalesSummaryInternalService.Application.Handlers
{
    public class SalesSummaryHandler : IRequestHandler<SalesSummaryQuery, SaleSummaryResponse>
    {
        private readonly ISalesSummaryRepository _salesSummaryRepository;
        public SalesSummaryHandler(ISalesSummaryRepository salesSummaryRepository)
        {
            _salesSummaryRepository = salesSummaryRepository;
        }

        public async Task<SaleSummaryResponse> Handle(SalesSummaryQuery request, CancellationToken cancellationToken)
        {
            var result = await _salesSummaryRepository.GetAllSalesSummary(request);
            return result;
        }
    }
}
