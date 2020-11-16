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
    public class InventoryController : ControllerBase
    {

        private readonly InventoryService inventoryService;
        public InventoryController(InventoryService service)
        {
            this.inventoryService = service;
        }

        [HttpGet("get/id/{id}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetInventoryById(int id)
        {
            try
            {
                return Ok(inventoryService.GetInventoryById(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/locationid/{id}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetInventoryByLocationId(int id)
        {
            try
            {
                return Ok(inventoryService.GetInventoryByLocationId(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("add/inventory")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddToInventory(Inventory newInventoryItem)
        {
            try
            {
                inventoryService.AddToInventory(newInventoryItem);
                return CreatedAtAction("AddToInventory", newInventoryItem);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
