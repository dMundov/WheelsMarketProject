namespace WheelsMarket.Web.ViewModels.HomeViewModels
{
    using Data.Models;
    using Data.Models.Enums;
    using Services.Mapping;

    public class IndexAdViewModel : IMapFrom<Ad>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public short BoltsNumber { get; set; }

        public int InterBoltDistance { get; set; }

        public double Width { get; set; }

        public int Diameter { get; set; }

        public double Offset { get; set; }

        public double CenterBore { get; set; }

        public string BoltPattern { get; set; }

        public RimType RimType { get; set; }

        public string Description { get; set; }

        public string MainPicture { get; set; }
        
        public int ViewCount { get; set; }
    }
}
