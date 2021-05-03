using FiskeNettet.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiskeNettet.Services.Interfaces
{
    public interface ICatchReportService
    {
        List<CatchReport> Get();

        CatchReport Get(string id);

        void Create(CatchReport report);

        //void Delete(string id);
    }
}