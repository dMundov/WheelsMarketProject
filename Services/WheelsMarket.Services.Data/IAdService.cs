using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WheelsMarket.Data.Models.Enums;

namespace WheelsMarket.Services.Data
{
    public interface IAdService
    {
        Task<string> CreateAdAsync(short boltsNumber, int interBoltDistance, double width, int diameter, short offset, double centerBore, string mainPicture, RimType rimType);

        T GetById<T>(string id);

    }
}
