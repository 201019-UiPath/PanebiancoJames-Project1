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
    public class OrdersController : ControllerBase
    {
        private readonly OrderService orderService;
        public OrdersController(OrderService service)
        {
            this.orderService = service;
        }

        [HttpGet("get/user/{id}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetAllOrdersByCustomerId(int id)
        {
            try
            {
                return Ok(orderService.GetAllOrdersByCustomerId(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/location/{id}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetAllOrdersByLocationId(int id)
        {
            try
            {
                return Ok(orderService.GetAllOrdersByLocationId(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/userdateasc/{id}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetAllOrdersDateAsc(int id)
        {
            try
            {
                return Ok(orderService.GetAllOrdersDateAsc(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/userdatedesc/{id}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetAllOrdersDateDesc(int id)
        {
            try
            {
                return Ok(orderService.GetAllOrdersDateDesc(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/userpriceasc/{id}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetAllOrdersPriceAsc(int id)
        {
            try
            {
                return Ok(orderService.GetAllOrdersPriceAsc(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/userrpicedesc/{id}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetAllOrdersPriceDesc(int id)
        {
            try
            {
                return Ok(orderService.GetAllOrdersPriceDesc(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/locationdateasc/{id}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetAllLocationOrdersDateAsc(int id)
        {
            try
            {
                return Ok(orderService.GetAllLocationOrdersDateAsc(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/locationdatedesc/{id}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetAllLocationOrdersDateDesc(int id)
        {
            try
            {
                return Ok(orderService.GetAllOrdersDateDesc(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/locationpriceasc/{id}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetAllLocationOrdersPriceAsc(int id)
        {
            try
            {
                return Ok(orderService.GetAllLocationOrdersPriceAsc(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/locationpricedesc/{id}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetAllLocationOrdersPriceDesc(int id)
        {
            try
            {
                return Ok(orderService.GetAllLocationOrdersPriceDesc(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("add/order")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddOrder(Orders newOrder)
        {
            try
            {
                orderService.AddOrder(newOrder);
                return CreatedAtAction("AddOrder", newOrder);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
