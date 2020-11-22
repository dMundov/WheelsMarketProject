using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Threading.Tasks;
using WheelsMarket.Data.Common.Repositories;
using WheelsMarket.Data.Models;
using WheelsMarket.Services.Mapping;

namespace WheelsMarket.Services.Data
{
    public class CommentService : ICommentService
    {

        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public IEnumerable<T> CommentsForCurrentAd<T>(string id)
        {
            IQueryable<Comment> commentsList = this.commentsRepository.All()
                .Where(x => x.AdId == id);

            return commentsList
                .To<T>()
                .ToArray(); ;
        }

        public async Task CreateNewComment(Comment data)
        { 
            await commentsRepository.AddAsync(data);
            await commentsRepository.SaveChangesAsync();
        }
    }

}
