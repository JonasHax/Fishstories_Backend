using FiskeNettet.Models;
using System.Collections.Generic;

namespace FiskeNettet.Services.Interfaces
{
    public interface IFishingSpotService
    {
        List<FishingSpotDTO> Get();

        FishingSpotDTO Get(string id);

        void Create(FishingSpotDTO spot);

        void Delete(string id);
    }
}