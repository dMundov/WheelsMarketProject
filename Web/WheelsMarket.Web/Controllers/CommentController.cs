using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PusherServer;
using WheelsMarket.Data.Models;
using WheelsMarket.Services.Data;
using WheelsMarket.Web.ViewModels.Comment;
using WheelsMarket.Web.ViewModels.CommentViewModels;

namespace WheelsMarket.Web.Controllers
{
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

            CommentInputModel data = new CommentInputModel
            {
                Body = inputCommentData.Body,
                AdId = inputCommentData.AdId,
                UserName = user.UserName,
                UserId = user.Id
            };
            
            await commentService.CreateNewComment(data);
            
            var options = new PusherOptions
            {
                Cluster = "eu"
            };

            var pusher = new Pusher("1101607", "7a46d9d6bd9b69256af2", "b924c7fd725b0e698991", options);
            ITriggerResult result = await pusher.TriggerAsync("asp_channel", "asp_event", data);
            return Content("ok");
        }

    }
}

