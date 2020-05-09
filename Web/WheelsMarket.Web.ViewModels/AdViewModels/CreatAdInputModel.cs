using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoMapper;
using WheelsMarket.Data.Models;
using WheelsMarket.Data.Models.Enums;
using WheelsMarket.Services.Mapping;

namespace WheelsMarket.Web.ViewModels.AdViewModels
{
    public class CreateAdInputModel  : IMapTo<Ad>
    {
        
        [Required]
        public short BoltsNumber { get; set; }

        [Required]
        public int InterBoltDistance { get; set; }

        [Required]
        public double Width { get; set; }

        [Required]
        public int Diameter { get; set; }

        public short Offset { get; set; }

        [Required]
        public double CenterBore { get; set; }

        [Required]
        public string BoltPattern { get; set; }

        [Required]
        public RimType RimType { get; set; }

        [Required]
        public string MainPicture { get; set; }

    }
}
