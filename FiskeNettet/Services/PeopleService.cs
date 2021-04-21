using FiskeNettet.Models;
using FiskeNettet.Repositories;
using FiskeNettet.Repositories.Interfaces;
using FiskeNettet.Services.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiskeNettet.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _peopleRepository;

        public PeopleService(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        public void Create(People person)
        {
            _peopleRepository.Create(person);
        }

        public void Delete(int id)
        {
            _peopleRepository.Delete(id);
        }

        public List<People> Get()
        {
            return _peopleRepository.Get();
        }

        public People Get(int age)
        {
            return _peopleRepository.Get(age);
        }
    }
}