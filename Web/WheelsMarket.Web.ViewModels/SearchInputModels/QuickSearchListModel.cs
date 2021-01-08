using System.Collections.Generic;
using WheelsMarket.Data.Models;
using WheelsMarket.Services.Mapping;
using WheelsMarket.Web.ViewModels.HomeViewModels;

namespace WheelsMarket.Web.ViewModels.SearchInputModels
{
    public class QuickSearchListModel
    {
        public IEnumerable<IndexAdViewModel> SearchResult { get; set; }
    }
}
