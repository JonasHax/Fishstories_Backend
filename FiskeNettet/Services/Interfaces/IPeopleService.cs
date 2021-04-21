using FiskeNettet.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiskeNettet.Services.Interfaces
{
    public interface IPeopleService
    {
        List<People> Get();

        People Get(int age);

        void Create(People person);

        void Delete(int id);
    }
}