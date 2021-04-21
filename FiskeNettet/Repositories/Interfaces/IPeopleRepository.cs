using FiskeNettet.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiskeNettet.Repositories.Interfaces
{
    public interface IPeopleRepository
    {
        List<People> Get();

        People Get(int age);

        void Create(People person);

        void Delete(int id);
    }
}