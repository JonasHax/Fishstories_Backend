using FiskeNettet.Models;
using System.Collections.Generic;

namespace FiskeNettet.Repositories.Interfaces
{
    public interface IFishingSpotRepository
    {
        List<FishingSpot> Get();

        FishingSpot Get(string name);

        void Create(FishingSpot spot);

        void Delete(string id);
    }
}
