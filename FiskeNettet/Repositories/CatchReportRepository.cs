using FiskeNettet.Entities.DatabaseSettings;
using FiskeNettet.Entities.Models;
using FiskeNettet.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiskeNettet.Repositories
{
    public class CatchReportRepository : ICatchReportRepository
    {
        private readonly IMongoCollection<CatchReport> _reports;

        public CatchReportRepository(ICatchReportsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _reports = database.GetCollection<CatchReport>(settings.CatchReportsCollectionName);
        }

        public void Create(CatchReport report)
        {
            _reports.InsertOne(report);
        }

        public List<CatchReport> Get()
        {
            return _reports.Find<CatchReport>(p => true).ToList();
        }

        public CatchReport Get(string reportId)
        {
            return _reports.Find(report => report.Id == ObjectId.Parse(reportId)).First();
        }
    }
}