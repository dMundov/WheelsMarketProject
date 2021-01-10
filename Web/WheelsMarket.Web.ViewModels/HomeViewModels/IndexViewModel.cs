namespace WheelsMarket.Web.ViewModels.HomeViewModels
{
    using System.Collections.Generic;

    public class IndexViewModel  
    {
        public short BoltsNumber { get; set; }

        public int InterBoltDistance { get; set; }

        public double Width { get; set; }

        public int Diameter { get; set; }

        public double Offset { get; set; }

        public double CenterBore { get; set; }

        public IEnumerable<IndexAdViewModel> LastTenAds { get; set; }

        public IEnumerable<IndexAdViewModel> TopFiveAdsByViews { get; set; }

    }
    
}


