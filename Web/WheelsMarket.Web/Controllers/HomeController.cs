
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WheelsMarket.Data.Models;

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
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IDistributedCache distributedCache;

        public HomeController(
            IAdService adService,
            ILogger<HomeController> logger,
            IDistributedCache distributedCache, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.adService = adService;
            this.logger = logger;
            this.distributedCache = distributedCache;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            ApplicationUser user = await this.userManager.GetUserAsync(this.User);

            if (signInManager.IsSignedIn(this.User))
            {
                IndexViewModel viewModel = new IndexViewModel
                {
                    LastTenAds =
                        this.adService.GetLatest10Ads<IndexAdViewModel>(),
                    TopFiveAdsByViews =
                        this.adService.TopFiveAdsByViews<IndexAdViewModel>(),
                    ProfilePicPath = user.ProfilePicturePath
                };
                return this.View(viewModel);
            }
            else
            {
                IndexViewModel viewModel = new IndexViewModel
                {
                    LastTenAds =
                        this.adService.GetLatest10Ads<IndexAdViewModel>(),
                    TopFiveAdsByViews =
                        this.adService.TopFiveAdsByViews<IndexAdViewModel>(),
                };
                return this.View(viewModel);
            }
        }



        public IActionResult WheelSize()
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
