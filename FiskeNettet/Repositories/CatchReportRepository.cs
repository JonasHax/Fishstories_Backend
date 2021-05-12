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
        private readonly IMongoCollection<CatchReportDTO> _reports;

        public CatchReportRepository(ICatchReportsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _reports = database.GetCollection<CatchReportDTO>(settings.CatchReportsCollectionName);
        }

        public void Create(CatchReportDTO report)
        {
            _reports.InsertOne(report);
        }

        public List<CatchReportDTO> Get()
        {
            return _reports.Find<CatchReportDTO>(p => true).ToList();
        }

        public CatchReportDTO Get(string reportId)
        {
            return _reports.Find(report => report.Id == ObjectId.Parse(reportId)).First();
        }
    }
}