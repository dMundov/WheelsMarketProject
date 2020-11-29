namespace WheelsMarket.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using WheelsMarket.Data.Common.Repositories;
    using WheelsMarket.Data.Models;
    using WheelsMarket.Services.Mapping;
    using WheelsMarket.Web.ViewModels.Comment;
    
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
                .Where(x => x.AdId == id);

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
