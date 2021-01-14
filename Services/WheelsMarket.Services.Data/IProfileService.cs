using System.Threading.Tasks;
using WheelsMarket.Web.ViewModels.ProfileViewModels;

namespace WheelsMarket.Services.Data
{
    public interface IProfileService
    {
        T GetUserProfile<T>(string userId);
        //Task<T> UpdateProfileAsync<T>(ProfileInputModel inputProfileData);
    }
}
