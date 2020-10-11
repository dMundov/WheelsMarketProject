using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WheelsMarket.Data.Common.Models;
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
        private readonly IWebHostEnvironment environment;

        public AdController(IAdService adService, UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {
            this.adService = adService;
            this.userManager = userManager;
            this.environment = environment;

        }

        
        public IActionResult ById(string id)
        {
            var adViewModel = this.adService.GetById<AdViewModel>(id);
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
            var user = await this.userManager.GetUserAsync(this.User);
            


            string webRootPath = environment.WebRootPath;
            IFormFileCollection files = HttpContext.Request.Form.Files;

            if (files.Count != 0)
            {
                var uploads = Path.Combine(webRootPath, @"images");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStrem = new FileStream(Path.Combine(uploads, user.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStrem);
                }

                input.MainPicture = @"\" + @"images" + @"\" + user.Id + extension;
            }
            else
            {
                input.MainPicture = @"\" + @"images" + @"\" + user.Id + "-default_image.png";

            }
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var adId = await this.adService.CreateAdAsync(input.BoltsNumber,input.InterBoltDistance,input.Width,input.Diameter,input.Offset,input.CenterBore,input.MainPicture,input.RimType,user.Id);
            this.TempData["InfoMessage"] = "Ad has created!";
            return this.RedirectToAction(nameof(this.ById), new { id = adId });

        }



    }
}
