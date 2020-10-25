using System;
using System.ComponentModel.DataAnnotations;
using WheelsMarket.Data.Models;
using WheelsMarket.Data.Models.Enums;
using WheelsMarket.Services.Mapping;
using WheelsMarket.Web.ViewModels.HomeViewModels;

namespace WheelsMarket.Web.ViewModels.AdViewModels
{
    public class AdViewModel : IMapFrom<Ad>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public short BoltsNumber { get; set; }

        public int InterBoltDistance { get; set; }

        public double Width { get; set; }

        public int Diameter { get; set; }

        public double Offset { get; set; }

        public double CenterBore { get; set; }

        public string BoltPattern { get; set; }

        public RimType RimType { get; set; }

        public string MainPicture { get; set; }
    }
}
