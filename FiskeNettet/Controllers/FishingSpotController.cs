using System.Collections.Generic;
using System.Web.Http.Cors;
using FiskeNettet.Models;
using FiskeNettet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiskeNettet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FishingSpotController : ControllerBase
    {
        private readonly IFishingSpotService _fishingSpotService;

        public FishingSpotController(IFishingSpotService fishingSpotService)
        {
            _fishingSpotService = fishingSpotService;
        }

        [HttpGet("{id}")]
        public ActionResult<FishingSpotDTO> Get(string id)
        {
            return Ok(_fishingSpotService.Get(id));
        }

        [HttpGet]
        public ActionResult<List<FishingSpotDTO>> Get()
        {
            return _fishingSpotService.Get();
        }

        [HttpPost]
        public ActionResult Create(FishingSpotDTO spot)
        {
            _fishingSpotService.Create(spot);
            return Ok(spot);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            _fishingSpotService.Delete(id);
            //return Ok();
            return NoContent();
        }
    }
}