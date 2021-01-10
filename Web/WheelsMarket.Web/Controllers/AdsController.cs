
using System;
using System.Collections;
using System.Collections.Generic;
using WheelsMarket.Web.ViewModels.HomeViewModels;
using WheelsMarket.Web.ViewModels.SearchInputModels;

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

    public class AdsController : Controller
    {
        private readonly Cloudinary cloudinary;
        private readonly IAdService adService;
        private readonly UserManager<ApplicationUser> userManager;



        public AdsController(IAdService adService, UserManager<ApplicationUser> userManager, Cloudinary cloudinary)
        {
            this.adService = adService;
            this.userManager = userManager;
            this.cloudinary = cloudinary;
        }


        public IActionResult Ad(string id)
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
            IFormFile file;

            try
            {
                file = HttpContext.Request.Form.Files[0];
            }
            catch
            {
                file = null;
            }

            string folder = $"AdsImages/user:{user.Id}";

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
                , input.Price
                , input.Description
                , user.Id);
            this.TempData["InfoMessage"] = "Ad has created!";
            return this.RedirectToAction(nameof(this.Ad), new { id = adId });

        }

        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await this.adService.DeleteAdAsync(id);
                return this.RedirectToAction("AdsList", "Profile");
            }
            catch
            {
                return BadRequest();
            }
        }

        public IActionResult QuickSearch(QuickSearchInputModel searchInputModel)
        {
            QuickSearchListModel resultFromSearch = new QuickSearchListModel
            {
                SearchResult = adService.SearchAds<IndexAdViewModel>(searchInputModel)
            };

            return this.View(resultFromSearch);
        }
    }
}
