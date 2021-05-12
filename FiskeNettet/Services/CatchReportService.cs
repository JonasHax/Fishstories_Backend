using FiskeNettet.Entities.Models;
using FiskeNettet.Repositories.Interfaces;
using FiskeNettet.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiskeNettet.Services
{
    public class CatchReportService : ICatchReportService
    {
        private readonly IMongoRepository<CatchReportDTO> _catchReportRepository;

        public CatchReportService(IMongoRepository<CatchReportDTO> catchReportRepository)
        {
            _catchReportRepository = catchReportRepository;
        }

        public void Create(CatchReportDTO report)
        {
            _catchReportRepository.Create(report);
        }

        public void DeleteById(string id)
        {
            _catchReportRepository.DeleteById(id);
        }

        public List<CatchReportDTO> Get()
        {
            return _catchReportRepository.Get();
        }

        public CatchReportDTO Get(string id)
        {
            return _catchReportRepository.Get(id);
        }
    }
}