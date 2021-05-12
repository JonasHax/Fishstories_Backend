using FiskeNettet.Models;
using System.Collections.Generic;

namespace FiskeNettet.Repositories.Interfaces
{
    public interface IFishingSpotRepository
    {
        List<FishingSpotDTO> Get();

        FishingSpotDTO Get(string id);

        void Create(FishingSpotDTO spot);

        void Delete(string id);
    }
}