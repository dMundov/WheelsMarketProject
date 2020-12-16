namespace WheelsMarket.Web.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using ViewModels.AdViewModels;
    using WheelsMarket.Services.Data;
    using ViewModels.ProfileViewModels;

    public class ProfileController : Controller
    {
        
        private readonly IAdService adService;
        private readonly UserManager<ApplicationUser> userManager;

        public ProfileController(IAdService adService, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.adService = adService;

        }

        [Authorize]
        public async Task<IActionResult> AdsList(string userId)
        {

            ApplicationUser user = await this.userManager.GetUserAsync(this.User);

            UserAdsList allAdsForUser =
                new UserAdsList()
                {
                    AllAds = this.adService.GetAllAdsByUser<AdViewModel>(user.Id)
                };

            return this.View(allAdsForUser);
        }
    }
}
