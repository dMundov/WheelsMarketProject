
namespace WheelsMarket.Web.Controllers
{
    using CloudinaryDotNet;

    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;


    using Services;
    using Data.Models;
    using WheelsMarket.Services.Data;
    using ViewModels.AdViewModels;

    public class AdController : Controller
    {
        private readonly Cloudinary cloudinary;
        private readonly IAdService adService;
        private readonly UserManager<ApplicationUser> userManager;



        public AdController(IAdService adService, UserManager<ApplicationUser> userManager, Cloudinary cloudinary)
        {
            this.adService = adService;
            this.userManager = userManager;
            this.cloudinary = cloudinary;
        }


        public IActionResult ById(string id)
        {

            AdViewModel adViewModel = this.adService.GetById<AdViewModel>(id);
            if (adViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(adViewModel);
        }


        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateAdInputModel input)
        {
            ApplicationUser user = await this.userManager.GetUserAsync(this.User);


            IFormFile file = HttpContext.Request.Form.Files[0];
            string folder = $"AdsImages/{user.Id}";

            if (file != null)
            {
                input.MainPicture = await CloudinaryService.UploadAsync(this.cloudinary, file, folder, user.Id);
            }
            else
            {
                input.MainPicture = @"\" + @"images" + @"\" + "-default_image.png";
            }
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            string adId = await this.adService.CreateAdAsync(
                  input.BoltsNumber
                , input.InterBoltDistance
                , input.Width
                , input.Diameter
                , input.Offset
                , input.CenterBore
                , input.MainPicture
                , input.RimType
                , user.Id);
            this.TempData["InfoMessage"] = "Ad has created!";
            return this.RedirectToAction(nameof(this.ById), new { id = adId });

        }

        [Authorize]
        public async Task<IActionResult> GetAllAdsByUser(string userId)
        {

            ApplicationUser user = await this.userManager.GetUserAsync(this.User);

            ListUserAdsViewModel allAdsForUser =
                new ListUserAdsViewModel
                {
                    AllAds = this.adService.GetAllAdsByUser<AdViewModel>(user.Id)
                };

            return this.View(allAdsForUser);
        }

    }
}
