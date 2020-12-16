namespace WheelsMarket.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WheelsMarket.Data.Models.Enums;

    public interface IAdService
    {
        Task<string> CreateAdAsync(short boltsNumber, int interBoltDistance, double width, int diameter, double offset, double centerBore, string mainPicture, RimType rimType,decimal price, string userId);

        T GetById<T>(string id);

        IEnumerable<T> GetLast10Ads<T>();

        IEnumerable<T> GetAllAdsByUser<T>(string userId);
    }
}
