
namespace WheelsMarket.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
   
    using WheelsMarket.Data.Common.Models;
    using Enums;

    public class Ad : BaseDeletableModel<string>
    {
        public Ad()
        {
            this.Id = Guid.NewGuid().ToString();
            IsApproved = false;
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
        public decimal Price { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        
        public bool IsApproved { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

    }
}
