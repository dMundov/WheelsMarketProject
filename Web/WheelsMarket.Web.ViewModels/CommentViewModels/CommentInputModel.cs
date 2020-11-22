
namespace WheelsMarket.Web.ViewModels.Comment
{
    using WheelsMarket.Services.Mapping;
    using WheelsMarket.Data.Models;

    public class CommentInputModel : IMapTo<Comment>
    {
        public string AdId { get; set; }

        public string Content { get; set; }

        public string UserEmail { get; set; }

    }
}
