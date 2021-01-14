using CloudinaryDotNet;

namespace WheelsMarket.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

   
    using Data.Models;
    using Services;
    using ViewModels.AdViewModels;
    using WheelsMarket.Services.Data;
    using ViewModels.ProfileViewModels;

    public class ProfileController : Controller
    {

        private readonly IAdService adService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProfileService profileService;
        private readonly Cloudinary cloudinary;

        public ProfileController(IAdService adService, UserManager<ApplicationUser> userManager, IProfileService profileService, Cloudinary cloudinary)
        {
            this.userManager = userManager;
            this.adService = adService;
            this.profileService = profileService;
            this.cloudinary = cloudinary;

        }

        [Authorize]
        public IActionResult MyProfile(string userId)
        {
            ProfileViewModel userProfile = this.profileService.GetUserProfile<ProfileViewModel>(userId);
            if (userProfile == null)
            {
                return this.NotFound();
            }
            return this.View(userProfile);
        }

        public async Task<IActionResult> UpdateProfile(ProfileInputModel profileInputModel)
        {
            ApplicationUser user = await this.userManager.GetUserAsync(this.User);
            IFormFile file;

            try
            {
                file = HttpContext.Request.Form.Files[0];
            }
            catch
            {
                file = null;
            }

            string folder = $"UserProfileImages/user:{user.Id}";

            if (file != null)
            {
                profileInputModel.ProfilePicPath = await CloudinaryService.UploadAsync(this.cloudinary, file, folder, user.Id);
            }
            else
            {
                profileInputModel.ProfilePicPath = @"\" + @"images" + @"\" + "-default__user_image.png";
            }
            if (!this.ModelState.IsValid)
            {
                return this.View(profileInputModel);
            }



            return this.View();
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
