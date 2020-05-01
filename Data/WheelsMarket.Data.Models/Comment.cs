using WheelsMarket.Data.Common.Models;

namespace WheelsMarket.Data.Models
{
    public class Comment : BaseDeletableModel<int>
    {

        public int AdId { get; set; }

        public virtual Ad Ad { get; set; }

        public int? ParentId { get; set; }

        public virtual Comment Parent { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}