using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WheelsMarket.Data.Common.Repositories;
using WheelsMarket.Data.Models;
using WheelsMarket.Services.Mapping;
using WheelsMarket.Web.ViewModels.Comment;
using WheelsMarket.Web.ViewModels.CommentViewModels;

namespace WheelsMarket.Services.Data
{
    public class CommentService : ICommentService
    {

        private readonly IDeletableEntityRepository<Comment> commentRepository;

        public CommentService(IDeletableEntityRepository<Comment> commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public IEnumerable<T> CommentsForCurrentAd<T>(string id)
        {
            IQueryable<Comment> commentsList = this.commentRepository.All()
                .Where(x => x.AdId == id)
                .OrderByDescending(x => x.CreatedOn);

            return commentsList
                .To<T>()
                .ToArray();
        }

        public async Task CreateNewComment(CommentInputModel data)
        {
            Comment newComment = new Comment
            {
                UserName = data.UserName,
                Body = data.Body,
                AdId = data.AdId,
                UserId = data.UserId
                
            };
            await commentRepository.AddAsync(newComment);
            await commentRepository.SaveChangesAsync();
        }
    }

}
