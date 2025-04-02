using WebUI.Models;

namespace WebUI.Services
{
    public class ApiGatewayService : IApiGatewayService
    {
        private readonly HttpClient _httpClient;

        public ApiGatewayService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<SalesSummaryResponse> GetSalesSummaryAsync(SalesSummaryRequest request)
        {
            if (request == null)
            {
                return new SalesSummaryResponse
                {
                    ErrorMessage = "Request cannot be null."
                };
            }

            var response = await _httpClient.PostAsJsonAsync("api/SalesSummary", request);

            if (response.IsSuccessStatusCode)
            {
                var salesSummaryResponse = await response.Content.ReadFromJsonAsync<SalesSummaryResponse>();
                return salesSummaryResponse ?? new SalesSummaryResponse
                {
                    ErrorMessage = "API returned no data."
                };
            }
            else
            {
                // Handle error response
                var errorResponse = new SalesSummaryResponse
                {
                    ErrorMessage = $"Error: {response.ReasonPhrase}"
                };
                return errorResponse;
            }
        }
    }
}
