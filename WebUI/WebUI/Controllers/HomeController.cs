using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.Models;
using WebUI.Services;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiGatewayService _apiGatewayService;
        public HomeController(ILogger<HomeController> logger, IApiGatewayService apiGatewayService)
        {
            _logger = logger;
            _apiGatewayService = apiGatewayService;
        }

        public async Task<IActionResult> IndexAsync([FromQuery] SalesSummaryRequest request)
        {
            try
            {
                var response = await _apiGatewayService.GetSalesSummaryAsync(request);

                ViewBag.Country = request.Country;               
                ViewBag.SortBy = request.SortBy;
                ViewBag.SortOrder = request.SortOrder;

                return View(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while calling the ApiGateWay GetSalesSummaryAsync().");
                throw; 
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
