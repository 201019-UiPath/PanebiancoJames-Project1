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
    public class ManagerController : ControllerBase
    {
        private readonly ManagerService managerService;

        public ManagerController(ManagerService service)
        {
            this.managerService = service;
        }

        [HttpGet("get")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetAllManagers()
        {
            try
            {
                return Ok(managerService.GetAllManagers());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/{name}/{password}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult SignInManager(string name, string password)
        {
            try
            {
                return Ok(managerService.SignInManager(name, password));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
