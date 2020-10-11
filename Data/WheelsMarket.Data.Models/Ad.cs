using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using WheelsMarket.Data.Common.Models;
using WheelsMarket.Data.Models.Enums;

namespace WheelsMarket.Data.Models
{
    public class Ad : BaseDeletableModel<string>
    {
        public Ad()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public short BoltsNumber { get; set; }

        [Required]
        public int InterBoltDistance { get; set; }

        [Required]
        public double Width { get; set; }

        [Required]
        public int Diameter { get; set; }

        [Required]
        public double Offset { get; set; }

        [Required]
        public double CenterBore { get; set; }

        [Required]
        public string BoltPattern { get; set; }

        [Required]
        public RimType RimType { get; set; }

        
        public string MainPicture { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

    }
}
