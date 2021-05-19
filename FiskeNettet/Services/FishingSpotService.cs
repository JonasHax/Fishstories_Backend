using FiskeNettet.Models;
using FiskeNettet.Repositories.Interfaces;
using FiskeNettet.Services.Interfaces;
using System.Collections.Generic;

namespace FiskeNettet.Services
{
    public class FishingSpotService : IFishingSpotService
    {
        private readonly IMongoRepository<FishingSpotDTO> _FishingSpotRepository;

        public FishingSpotService(IMongoRepository<FishingSpotDTO> fishingSpotRepository)
        {
            _FishingSpotRepository = fishingSpotRepository;
        }

        public void Create(FishingSpotDTO spot)
        {
            _FishingSpotRepository.Create(spot);
        }

        public void DeleteById(string id)
        {
            _FishingSpotRepository.DeleteById(id);
        }

        public List<FishingSpotDTO> Get()
        {
            List<FishingSpotDTO> fishingSpots = _FishingSpotRepository.Get();
            foreach (FishingSpotDTO spot in fishingSpots)
            {
                spot.StringId = spot.Id.ToString();
            }
            return fishingSpots;
        }

        public FishingSpotDTO Get(string id)
        {
            return _FishingSpotRepository.Get(id);
        }
    }
}