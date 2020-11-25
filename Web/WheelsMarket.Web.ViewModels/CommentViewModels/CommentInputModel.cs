namespace WheelsMarket.Web.ViewModels.Comment
{
    using WheelsMarket.Services.Mapping;
    using WheelsMarket.Data.Models;

    public class CommentInputModel : IMapFrom<Comment>
    {
        public string AdId { get; set; }

        public string UserName { get; set; }

        public string Body { get; set; }

        public string UserId { get; set; }

    }
}
