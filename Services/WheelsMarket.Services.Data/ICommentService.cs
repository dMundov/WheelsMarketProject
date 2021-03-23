using WheelsMarket.Data.Models;

namespace WheelsMarket.Services.Data
{
    using System.Collections.Generic;

    using System.Threading.Tasks;
    using Web.ViewModels.CommentViewModels;

    public interface ICommentService
    {

        Task<CommentOutPutViewModel> CreateNewComment(CommentInputModel data);

        Task<CommentOutPutViewModel> Edit(CommentInputModel commentData);

        IEnumerable<T> CommentsForCurrentAd<T> (string id);

    }
}
