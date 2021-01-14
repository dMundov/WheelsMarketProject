using System.ComponentModel.DataAnnotations;
using WheelsMarket.Data.Models.Enums;

namespace WheelsMarket.Web.ViewModels.ProfileViewModels
{
    using Data.Models;
    using Services.Mapping;

    public class ProfileViewModel : IMapFrom<ApplicationUser>
    {
        
        public string UserName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public GenderType Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string ProfilePicturePath { get; set; }
    }
}
