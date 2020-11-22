using System.ComponentModel.DataAnnotations;
using WheelsMarket.Data.Common.Models;

namespace WheelsMarket.Data.Models
{
    public class Comment : BaseDeletableModel<int>
    {

        [Required]
        public string Body { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string AdId { get; set; }

        public virtual Ad Ad { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}