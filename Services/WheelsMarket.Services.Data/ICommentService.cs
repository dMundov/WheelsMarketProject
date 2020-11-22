using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WheelsMarket.Data.Models;

namespace WheelsMarket.Services.Data
{
    public interface ICommentService
    {

        Task CreateNewComment(Comment data);
        
        IEnumerable<T> CommentsForCurrentAd<T> (string id);

    }
}
