using FiskeNettet.Models;
using FiskeNettet.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiskeNettet.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly IMongoCollection<People> _peepz;

        public PeopleRepository(IPeopleStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _peepz = database.GetCollection<People>(settings.PeopleCollectionName);
        }

        public void Create(People person)
        {
            _peepz.InsertOne(person);
        }

        public void Delete(int id)
        {
            var nigga = _peepz.Find(p => p.Age == id);
            _peepz.DeleteOne(p => p.Age == id);
            //var nigga = _peepz.Find(p => p.Id.Equals(id));
            //_peepz.DeleteOne(p => p.Id.Equals(id));
        }

        public List<People> Get()
        {
            return _peepz.Find<People>(p => true).ToList();
        }

        public People Get(int age)
        {
            return _peepz.Find(p => p.Age == age).First();
        }
    }
}