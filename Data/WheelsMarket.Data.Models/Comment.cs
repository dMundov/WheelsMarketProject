using WheelsMarket.Data.Common.Models;

namespace WheelsMarket.Data.Models
{
    public class Comment : BaseDeletableModel<int>
    {


        public string Body { get; set; }

        public string UserName { get; set; }

        public string AdId { get; set; }

        public virtual Ad Ad { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}