namespace WheelsMarket.Web.ViewModels.CommentViewModels
{
    using System;
    using Services.Mapping;
    using Data.Models;

    public class CommentOutPutViewModel : IMapFrom<Comment>
    {
        public string AdId { get; set; }

        public string UserName { get; set; }

        public string Body { get; set; }

        public string CreatedOn { get; set; }


    }
}
