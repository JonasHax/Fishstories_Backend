using FiskeNettet.Models;
using FiskeNettet.Repositories.Interfaces;
using FiskeNettet.Services.Interfaces;
using System.Collections.Generic;

namespace FiskeNettet.Services
{
    public class FishingSpotService : IFishingSpotService
    {
        private readonly IFishingSpotRepository _FishingSpotRepository;

        public FishingSpotService(IFishingSpotRepository fishingSpotRepository)
        {
            _FishingSpotRepository = fishingSpotRepository;
        }

        public void Create(FishingSpot spot)
        {
            _FishingSpotRepository.Create(spot);
        }

        public void Delete(string id)
        {
            _FishingSpotRepository.Delete(id);
        }

        public List<FishingSpot> Get()
        {
            return _FishingSpotRepository.Get();
        }

        public FishingSpot Get(string id)
        {
            return _FishingSpotRepository.Get(id);
        }
    }
}