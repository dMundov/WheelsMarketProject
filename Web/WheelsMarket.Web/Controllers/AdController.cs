namespace WheelsMarket.Web.Controllers
{

    using System.IO;

    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.Processing;

    using WheelsMarket.Data.Models;
    using WheelsMarket.Services.Data;
    using WheelsMarket.Web.ViewModels.AdViewModels;

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



            string webRootPath = environment.WebRootPath;
            IFormFileCollection file = HttpContext.Request.Form.Files;

            if (file.Count != 0)
            {
                string uploads = Path.Combine(webRootPath, @"images");
                string extension = Path.GetExtension(file[0].FileName);

                //resize and save uploading  image
                using var image = Image.Load(file[0].OpenReadStream());
                image.Mutate(x => x.Resize(500, 500));
                image.Save(Path.Combine(uploads, user.Id + file[0].FileName));


                input.MainPicture = @"\" + @"images" + @"\" + user.Id + file[0].FileName;
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
