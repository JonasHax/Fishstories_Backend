using System.Collections.Generic;
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
        public ActionResult<FishingSpot> Get(string id)
        {
            return Ok(_fishingSpotService.Get(id));
        }

        [HttpGet]
        public ActionResult<List<FishingSpot>> Get()
        {
            return _fishingSpotService.Get();
        }

        [HttpPost]
        public ActionResult Create(FishingSpot spot)
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