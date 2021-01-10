
namespace WheelsMarket.Web.Controllers
{
    using Microsoft.Extensions.Caching.Distributed;
    using Microsoft.Extensions.Logging;
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;

    using WheelsMarket.Services.Data;
    using ViewModels.HomeViewModels;
    using ViewModels;

    public class HomeController : BaseController
    {
        private readonly IAdService adService;
        private readonly ILogger<HomeController> logger;
        private readonly IDistributedCache distributedCache;

        public HomeController(
            IAdService adService,
            ILogger<HomeController> logger,
            IDistributedCache distributedCache)
        {
            this.adService = adService;
            this.logger = logger;
            this.distributedCache = distributedCache;
        }

        public IActionResult Index()
        {
            IndexViewModel viewModel = new IndexViewModel
            {
                LastTenAds = 
                    this.adService.GetLatest10Ads<IndexAdViewModel>(),
                TopFiveAdsByViews=
                    this.adService.TopFiveAdsByViews<IndexAdViewModel>()
            };
            return this.View(viewModel);

        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
