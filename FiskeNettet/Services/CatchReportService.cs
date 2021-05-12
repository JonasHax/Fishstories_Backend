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
        private readonly ICatchReportRepository _catchReportRepository;

        public CatchReportService(ICatchReportRepository catchReportRepository)
        {
            _catchReportRepository = catchReportRepository;
        }

        public void Create(CatchReportDTO report)
        {
            _catchReportRepository.Create(report);
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