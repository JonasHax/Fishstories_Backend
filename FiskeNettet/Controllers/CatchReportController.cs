using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiskeNettet.Entities.Models;
using FiskeNettet.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FiskeNettet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatchReportController : ControllerBase
    {
        private readonly ICatchReportService _catchReportService;

        public CatchReportController(ICatchReportService catchReportService)
        {
            _catchReportService = catchReportService;
        }

        [HttpGet("{id}")]
        public ActionResult<CatchReportDTO> Get(string id)
        {
            return Ok(_catchReportService.Get(id));
        }

        [HttpGet]
        public ActionResult<List<CatchReportDTO>> Get()
        {
            return _catchReportService.Get();
        }

        [HttpPost]
        public ActionResult Create(CatchReportDTO report)
        {
            _catchReportService.Create(report);
            return Ok(report);
        }
    }
}