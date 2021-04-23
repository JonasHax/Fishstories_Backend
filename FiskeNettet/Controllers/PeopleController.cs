using System.Collections.Generic;
using FiskeNettet.Models;
using FiskeNettet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiskeNettet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet("{age}")]
        public ActionResult<People> Get(int age)
        {
            return Ok(_peopleService.Get(age));
        }

        [HttpGet]
        public ActionResult<List<People>> Get()
        {
            return _peopleService.Get();
        }

        [HttpPost]
        public ActionResult Create(People person)
        {
            _peopleService.Create(person);
            return Ok(person);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _peopleService.Delete(id);
            //return Ok();
            return NoContent();
        }
    }
}