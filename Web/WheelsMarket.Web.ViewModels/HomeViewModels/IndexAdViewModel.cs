namespace WheelsMarket.Web.ViewModels.HomeViewModels
{
    using WheelsMarket.Data.Models;
    using WheelsMarket.Data.Models.Enums;
    using WheelsMarket.Services.Mapping;

    public class IndexAdViewModel : IMapFrom<Ad>
    {
        public string Title { get; set; }

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
