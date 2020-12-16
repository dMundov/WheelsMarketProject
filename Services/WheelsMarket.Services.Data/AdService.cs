
namespace WheelsMarket.Services.Data
{

    using Mapping;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WheelsMarket.Data.Common.Repositories;
    using WheelsMarket.Data.Models;
    using WheelsMarket.Data.Models.Enums;


    public class AdService : IAdService
    {

        // ReSharper disable once InconsistentNaming
        private readonly IDeletableEntityRepository<Ad> adRepository;

        public AdService(IDeletableEntityRepository<Ad> adRepository)
        {
            this.adRepository = adRepository;
        }

        public async Task<string> CreateAdAsync(short boltsNumber, int interBoltDistance, double width, int diameter, double offset, double centerBore, string mainPicture, RimType rimType,decimal price, string description, string userId)
        {
            Ad ad = new Ad
            {
                Title = "Джанти " + boltsNumber + "x" + interBoltDistance+ ", "+ centerBore,
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
                Price=price,
                Description = description
            };

            await this.adRepository.AddAsync(ad);
            await this.adRepository.SaveChangesAsync();
            return ad.Id;
        }

        public T GetById<T>(string id)
        {
            T ad = this.adRepository.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();
            return ad;
        }


        public IEnumerable<T> GetLast10Ads<T>()
        {
            IQueryable<Ad> query = this.adRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .Take(10);

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

    }
}
