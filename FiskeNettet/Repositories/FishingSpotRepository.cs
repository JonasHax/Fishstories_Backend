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

        public void Delete(string name)
        {
            _spotz.DeleteOne(p => p.Id == ObjectId.Parse(name) );
        }

        public List<FishingSpot> Get()
        {
            return _spotz.Find<FishingSpot>(p => true).ToList();
        }

        public FishingSpot Get(string name)
        {
            return _spotz.Find(p => p.Name == name).First();
        }
    }
}
