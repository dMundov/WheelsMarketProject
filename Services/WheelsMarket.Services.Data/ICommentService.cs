namespace WheelsMarket.Services.Data
{
    using System.Collections.Generic;

    using System.Threading.Tasks;
    using WheelsMarket.Web.ViewModels.Comment;

    public interface ICommentService
    {

        Task CreateNewComment(CommentInputModel data);
        
        IEnumerable<T> CommentsForCurrentAd<T> (string id);

    }
}
