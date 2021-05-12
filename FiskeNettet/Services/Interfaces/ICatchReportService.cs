using FiskeNettet.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiskeNettet.Services.Interfaces
{
    public interface ICatchReportService
    {
        List<CatchReportDTO> Get();

        CatchReportDTO Get(string id);

        void Create(CatchReportDTO report);

        //void Delete(string id);
    }
}