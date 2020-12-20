using System;
using System.Globalization;

namespace WheelsMarket.Services.Data
{
    using Mapping;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Web.ViewModels.CommentViewModels;
    using WheelsMarket.Data.Common.Repositories;
    using WheelsMarket.Data.Models;

    public class CommentService : ICommentService
    {

        // ReSharper disable once InconsistentNaming
        private readonly IDeletableEntityRepository<Comment> commentRepository;

        public CommentService(IDeletableEntityRepository<Comment> commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public IEnumerable<T> CommentsForCurrentAd<T>(string id)
        {
            IQueryable<Comment> commentsList = this.commentRepository.All()
                .Where(x => x.AdId == id);
            return commentsList
                .To<T>()
                .ToArray();
        }

        public async Task<CommentOutPutViewModel> CreateNewComment(CommentInputModel data)
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

            CommentOutPutViewModel commentToPush = new CommentOutPutViewModel()
            {
                AdId = newComment.AdId,
                UserName = newComment.UserName,
                Body = newComment.Body,
                CreatedOn = newComment.CreatedOn.ToLocalTime().ToString("g",
                    DateTimeFormatInfo.InvariantInfo)
            };
            return commentToPush;
        }
    }

}
