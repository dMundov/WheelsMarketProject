
using System;
using System.ComponentModel.DataAnnotations;

namespace WheelsMarket.Web.ViewModels.CommentViewModels
{
    using WheelsMarket.Services.Mapping;
    using WheelsMarket.Data.Models;

    public class CommentOutPutViewModel : IMapFrom<Comment>
    {
        public string AdId { get; set; }

        public string UserName { get; set; }

        public string Body { get; set; }
        
        public DateTime CreatedOn { get; set; }


    }
}
