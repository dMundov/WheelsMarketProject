using WheelsMarket.Web.ViewModels.AdViewModels;
using WheelsMarket.Web.ViewModels.HomeViewModels;
using WheelsMarket.Web.ViewModels.SearchInputModels;

namespace WheelsMarket.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WheelsMarket.Data.Models.Enums;

    public interface IAdService
    {
        Task<string> CreateAdAsync(short boltsNumber, int interBoltDistance, double width, int diameter, double offset, double centerBore, string mainPicture, RimType rimType,decimal price,string description, string userId);

        T GetById<T>(string id);

        IEnumerable<T> GetLast10Ads<T>();

        IEnumerable<T> GetAllAdsByUser<T>(string userId);

        IEnumerable<T> SearchAds<T>(QuickSearchInputModel quickSearchInputModel);
    }
}
