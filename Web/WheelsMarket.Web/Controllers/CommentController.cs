using System.Globalization;

namespace WheelsMarket.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PusherServer;
    using Data.Models;
    using WheelsMarket.Services.Data;
    using ViewModels.CommentViewModels;


    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly UserManager<ApplicationUser> userManager;

        public CommentController(ICommentService commentService, UserManager<ApplicationUser> userManager)
        {
            this.commentService = commentService;
            this.userManager = userManager;
        }

        public ActionResult GetAllComments(string id)
        {
            var comments = commentService.CommentsForCurrentAd<CommentOutPutViewModel>(id);

            return Json(comments);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddComment([FromBody]CommentInputModel inputCommentData)
        {
            ApplicationUser user = await this.userManager.GetUserAsync(this.User);

            CommentInputModel commentData = new CommentInputModel
            {
                Body = inputCommentData.Body,
                AdId = inputCommentData.AdId,
                UserName = user.UserName,
                UserId = user.Id
            };
            
            CommentOutPutViewModel commentToPush = await commentService.CreateNewComment(commentData);
            
            var options = new PusherOptions
            {
                Cluster = "eu"
            };

            var pusher = new Pusher("1115013", "66ba1be85188c9d95935", "8e7bb1ac169466d0f4b9", options);
            ITriggerResult result = await pusher.TriggerAsync("asp_channel", "asp_event", commentToPush);
            return  Content("CommentAddSuccessfully");
        }

    }
}

