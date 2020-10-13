using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WheelsMarket.Data.Models.Enums;

namespace WheelsMarket.Services.Data
{
    public interface IAdService
    {
        Task<string> CreateAdAsync(short boltsNumber, int interBoltDistance, double width, int diameter, double offset, double centerBore, string mainPicture, RimType rimType, string userId);

        T GetById<T>(string id);

        IEnumerable<T> GetLast10Ads<T>();

    }
}
