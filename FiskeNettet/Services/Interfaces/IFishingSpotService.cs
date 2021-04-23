using FiskeNettet.Models;
using System.Collections.Generic;

namespace FiskeNettet.Services.Interfaces
{
    public interface IFishingSpotService
    {
        List<FishingSpot> Get();

        FishingSpot Get(string id);

        void Create(FishingSpot spot);

        void Delete(string id);
    }
}