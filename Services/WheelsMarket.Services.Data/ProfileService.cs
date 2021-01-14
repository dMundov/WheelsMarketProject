

using System.Threading.Tasks;
using WheelsMarket.Web.ViewModels.ProfileViewModels;

namespace WheelsMarket.Services.Data
{
    using System.Linq;

    using Mapping;

    using WheelsMarket.Data.Common.Repositories;
    using WheelsMarket.Data.Models;

    public class ProfileService : IProfileService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public ProfileService(IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.userRepository = userRepository;
        }

        public T GetUserProfile<T>(string userId)
        {
            var user = this.userRepository.All()
                .Where(x => x.Id == userId)
                .To<T>()
                .FirstOrDefault();

            return user;
        }

        //public async Task<T> UpdateProfileAsync<T>(ProfileInputModel inputProfileData)
        //{
            

        //}
    }
}
