using FiskeNettet.Entities.DatabaseSettings;
using FiskeNettet.Models;
using FiskeNettet.Repositories.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace FiskeNettet.Repositories
{
    public class FishingSpotRepository : IFishingSpotRepository
    {
        private readonly IMongoCollection<FishingSpotDTO> _spotz;

        public FishingSpotRepository(IFishingSpotDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _spotz = database.GetCollection<FishingSpotDTO>(settings.FishingSpotCollectionName);
        }

        public void Create(FishingSpotDTO spot)
        {
            _spotz.InsertOne(spot);
        }

        public void Delete(string spotId)
        {
            _spotz.DeleteOne(p => p.Id == ObjectId.Parse(spotId));
        }

        public List<FishingSpotDTO> Get()
        {
            return _spotz.Find<FishingSpotDTO>(p => true).ToList();
        }

        public FishingSpotDTO Get(string spotId)
        {
            return _spotz.Find(spot => spot.Id == ObjectId.Parse(spotId)).First();
        }
    }
}