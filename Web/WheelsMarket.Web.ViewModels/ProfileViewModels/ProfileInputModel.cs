using WheelsMarket.Data.Models;
using WheelsMarket.Data.Models.Enums;
using WheelsMarket.Services.Mapping;

namespace WheelsMarket.Web.ViewModels.ProfileViewModels
{
    using System.ComponentModel.DataAnnotations; 

    public class ProfileInputModel:IMapTo<ApplicationUser>
    {
        [Required]
        public string Id { get; set; }
        
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public GenderType Gender { get; set; }

        public string PhoneNumber { get; set; }
        
        [Required]
        public string ProfilePicPath { get; set; }


    }
}
