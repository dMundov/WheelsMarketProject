﻿using WheelsMarket.Web.ViewModels.AdViewModels;
using WheelsMarket.Web.ViewModels.HomeViewModels;
using WheelsMarket.Web.ViewModels.ProfileViewModels;
using WheelsMarket.Web.ViewModels.SearchInputModels;

namespace WheelsMarket.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WheelsMarket.Data.Models.Enums;

    public interface IAdService
    {
        Task<string> CreateAdAsync(short boltsNumber, int interBoltDistance, double width, int diameter, double offset, double centerBore, string mainPicture, RimType rimType,decimal price,string description, string userId);

        Task DeleteAdAsync(string id);

        T GetById<T>(string id);

        IEnumerable<T> GetLatest10Ads<T>();
        
        IEnumerable<T> TopFiveAdsByViews<T>();

        IEnumerable<T> GetAllAdsByUser<T>(string userId);

        IEnumerable<T> SearchAds<T>(QuickSearchInputModel quickSearchInputModel);
    }
}
