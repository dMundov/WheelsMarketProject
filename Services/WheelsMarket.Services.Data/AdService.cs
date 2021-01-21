using System;
using System.Linq;
using WheelsMarket.Data.Models;
using WheelsMarket.Web.ViewModels.AdViewModels;

namespace WheelsMarket.Services.Data
{
    using Mapping;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WheelsMarket.Data.Common.Repositories;
    using WheelsMarket.Data.Models;
    using WheelsMarket.Data.Models.Enums;
    using Web.ViewModels.SearchInputModels;


    public class AdService : IAdService
    {

        // ReSharper disable once InconsistentNaming
        private readonly IDeletableEntityRepository<Ad> adRepository;

        public AdService(IDeletableEntityRepository<Ad> adRepository)
        {
            this.adRepository = adRepository;
        }

        public async Task<string> CreateAdAsync(short boltsNumber, int interBoltDistance, double width, int diameter, double offset, double centerBore, string mainPicture, RimType rimType, decimal price, string description, string userId)
        {
            Ad ad = new Ad
            {
                Title = "Джанти " + boltsNumber + "x" + interBoltDistance + ", " + centerBore,
                BoltPattern = boltsNumber + "x" + interBoltDistance,
                BoltsNumber = boltsNumber,
                InterBoltDistance = interBoltDistance,
                Diameter = diameter,
                Offset = offset,
                CenterBore = centerBore,
                Width = width,
                MainPicture = mainPicture,
                RimType = rimType,
                UserId = userId,
                Price = price,
                Description = description
            };

            await this.adRepository.AddAsync(ad);
            await this.adRepository.SaveChangesAsync();
            return ad.Id;
        }

        public async Task DeleteAdAsync(string id)
        {
            Ad adToDelete = this.adRepository
                .All()
                .FirstOrDefault(x => x.Id == id);
            if (adToDelete != null)
            {
                this.adRepository.Delete(adToDelete);
                await this.adRepository.SaveChangesAsync();
            }
        }

        public T GetById<T>(string id)
        {
            T adToReturn = this.adRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return adToReturn;
        }

        public async Task IncrementViewCounter(string id)
        {
            var ad = this.adRepository.All()
                .Single(x=>x.Id==id);

            if (ad != null)
            {
                ad.ViewCount += 1;

                this.adRepository.Update(ad);
                await this.adRepository.SaveChangesAsync();
            }
        }

        public IEnumerable<T> GetLatest10Ads<T>()
        {
            IQueryable<Ad> query = this.adRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .Take(10);

            return query.To<T>()
                .ToList();
        }
        public IEnumerable<T> TopFiveAdsByViews<T>()
        {
            IQueryable<Ad> query = this.adRepository.All()
                .OrderByDescending(x => x.ViewCount)
                .Take(5);

            return query.To<T>()
                .ToList();
        }

        public IEnumerable<T> GetAllAdsByUser<T>(string userId)
        {
            IQueryable<Ad> adsList = this.adRepository.All()
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.CreatedOn);

            return adsList.To<T>()
                  .ToList();
        }

        public IEnumerable<T> SearchAds<T>(QuickSearchInputModel quickSearchInputModel)
        {
            IQueryable<Ad> searchResult = null;

            if (quickSearchInputModel.Diameter == null
                && quickSearchInputModel.BoltsNumber == null
                && quickSearchInputModel.InterBoltDistance == null
                && quickSearchInputModel.CenterBore == null
                && quickSearchInputModel.Width == null)
            {
                searchResult = adRepository.All();
            }
            else
            {
                searchResult = adRepository
                   .All()
                   .Where(x => x.Diameter == quickSearchInputModel.Diameter)
                   .Where(x => x.BoltsNumber == quickSearchInputModel.BoltsNumber)
                   .Where(x => x.InterBoltDistance == quickSearchInputModel.InterBoltDistance)
                   .Where(x => x.Offset == quickSearchInputModel.Offset)
                   .Where(x => x.CenterBore == quickSearchInputModel.CenterBore)
                   .Where(x => x.Width == quickSearchInputModel.Width);
            }

            return searchResult.To<T>().ToList();
        }

    }

}
