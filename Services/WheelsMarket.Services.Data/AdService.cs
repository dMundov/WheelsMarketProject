using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WheelsMarket.Data.Common.Repositories;
using WheelsMarket.Data.Models;
using WheelsMarket.Data.Models.Enums;
using WheelsMarket.Services.Mapping;

namespace WheelsMarket.Services.Data
{
    public class AdService : IAdService
    {

        private readonly IDeletableEntityRepository<Ad> adRepository;

        public AdService(IDeletableEntityRepository<Ad> adRepository)
        {
            this.adRepository = adRepository;
        }

        public async Task<string> CreateAdAsync(short boltsNumber, int interBoltDistance, double width, int diameter, double offset, double centerBore, string mainPicture, RimType rimType, string userId)
        {
            Ad ad = new Ad
            {
                Title = "Джанти " + boltsNumber + "x" + interBoltDistance,
                BoltPattern = boltsNumber + "x" + interBoltDistance,
                BoltsNumber = boltsNumber,
                InterBoltDistance = interBoltDistance,
                Diameter = diameter,
                Offset = offset,
                CenterBore = centerBore,
                Width = width,
                MainPicture = mainPicture,
                RimType = rimType,
                UserId = userId
            };

            await this.adRepository.AddAsync(ad);
            await this.adRepository.SaveChangesAsync();
            return ad.Id;
        }

        public T GetById<T>(string id)
        {
            var ad = this.adRepository.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();
            return ad;
        }


        public IEnumerable<T> GetLast10Ads<T>()
        {
            var query = this.adRepository.All()
                .OrderByDescending(x=>x.CreatedOn)
                .Take(10);
            
            return query.To<T>()
                .ToList(); ;
        }
    }
}
