using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameKingdomDB;
using GameKingdomDB.Models;
using GameKingdomLib;
using Microsoft.AspNetCore.Cors;

namespace GameKingdomAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly LocationService locationService;
        public LocationController(LocationService service)
        {
            this.locationService = service;
        }

        [HttpGet("get/id/{id}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetLocationById(int id)
        {
            try
            {
                return Ok(locationService.GetLocationById(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetAllLocations()
        {
            try
            {
                return Ok(locationService.GetAllLocations());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("add/location")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddLocation(Location newLocation)
        {
            try
            {
                locationService.AddLocation(newLocation);
                return CreatedAtAction("AddLocation", newLocation);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
