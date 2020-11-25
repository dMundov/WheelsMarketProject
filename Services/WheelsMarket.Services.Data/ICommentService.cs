using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WheelsMarket.Data.Models;
using WheelsMarket.Web.ViewModels.Comment;

namespace WheelsMarket.Services.Data
{
    public interface ICommentService
    {

        Task CreateNewComment(CommentInputModel data);
        
        IEnumerable<T> CommentsForCurrentAd<T> (string id);

    }
}
