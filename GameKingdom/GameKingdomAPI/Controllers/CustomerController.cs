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
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService customerService;

        public CustomerController(CustomerService service)
        {
            this.customerService = service;
        }

        [HttpGet("get")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetAllCustomers()
        {
            try
            {
                return Ok(customerService.GetAllCustomers());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/{name}/{password}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult SignInCustomer(string name, string password)
        {
            try
            {
                return Ok(customerService.SignInCustomer(name,password));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddCustomer(Customer newCustomer)
        {
            try
            {
                customerService.AddCustomer(newCustomer);
                return CreatedAtAction("AddCustomer", newCustomer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
