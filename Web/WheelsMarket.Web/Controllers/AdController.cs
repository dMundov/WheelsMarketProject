using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WheelsMarket.Data.Models;
using WheelsMarket.Services.Data;
using WheelsMarket.Web.ViewModels.AdViewModels;

namespace WheelsMarket.Web.Controllers
{
    public class AdController : Controller
    {
        private readonly IAdService adService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public AdController(IAdService adService, UserManager<ApplicationUser> userManager)
        {
            this.adService = adService;
            this.userManager = userManager;
        }

        
        public IActionResult ById(string id)
        {
            var postViewModel = this.adService.GetById<Ad>(id);
            if (postViewModel == null)
            {
                return this.NotFound();
            }

            return this.View();
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
            var user = await this.userManager.GetUserAsync(this.User);
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var adId = await this.adService.CreateAdAsync(input.BoltsNumber,input.InterBoltDistance,input.Width,input.Diameter,input.Offset,input.CenterBore,input.MainPicture,input.RimType);
            this.TempData["InfoMessage"] = "Ad has created!";
            return this.RedirectToAction(nameof(this.ById), new { id = adId });
        }



    }
}
