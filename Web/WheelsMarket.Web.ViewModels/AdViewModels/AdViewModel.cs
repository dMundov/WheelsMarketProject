﻿namespace WheelsMarket.Web.ViewModels.AdViewModels
{

    using System;
    using Data.Models;
    using Data.Models.Enums;
    using Services.Mapping;

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

        public string Description { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }

        public int ViewCount { get; set; }

        public string MainPicture { get; set; }

        public string UserId { get; set; }
    }
}
