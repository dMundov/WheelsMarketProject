﻿namespace WheelsMarket.Web.ViewModels.AdViewModels
{
    using System.ComponentModel.DataAnnotations;
    
    using Data.Models;
    using Data.Models.Enums;
    using Services.Mapping;

    public class CreateAdInputModel : IMapTo<Ad>
    {

        [Required]
        public short BoltsNumber { get; set; }

        [Required]
        public int InterBoltDistance { get; set; }

        [Required]
        public double Width { get; set; }

        [Required]
        public int Diameter { get; set; }

        [Required]
        public double Offset { get; set; }

        [Required]
        public double CenterBore { get; set; }

        [Required]
        public RimType RimType { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string MainPicture { get; set; }

    }
}
