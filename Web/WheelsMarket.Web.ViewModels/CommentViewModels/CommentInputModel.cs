namespace WheelsMarket.Web.ViewModels.CommentViewModels
{
    using Services.Mapping;
    using Data.Models;

    public class CommentInputModel : IMapFrom<Comment>
    {
        public string Id { get; set; }

        public string Body { get; set; }
       
        public string AdId { get; set; }

        public string UserName { get; set; }

        public string UserId { get; set; }

    }
}
