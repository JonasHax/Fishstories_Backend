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
        private readonly IMongoCollection<FishingSpot> _spotz;

        public FishingSpotRepository(IFishingSpotDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _spotz = database.GetCollection<FishingSpot>(settings.FishingSpotCollectionName);
        }

        public void Create(FishingSpot spot)
        {
            _spotz.InsertOne(spot);
        }

        public void Delete(string spotId)
        {
            _spotz.DeleteOne(p => p.Id == ObjectId.Parse(spotId));
        }

        public List<FishingSpot> Get()
        {
            return _spotz.Find<FishingSpot>(p => true).ToList();
        }

        public FishingSpot Get(string spotId)
        {
            return _spotz.Find(spot => spot.Id == ObjectId.Parse(spotId)).First();
        }
    }
}