

using System;
using WheelsMarket.Data.Models;
using WheelsMarket.Services.Mapping;

namespace WheelsMarket.Web.ViewModels.AdViewModels
{
    public class AdViewModel: IMapFrom<Ad>, IMapTo<Ad>
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }
    }
}
