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
    public class OrderItemsController : ControllerBase
    {
        private readonly OrderItemService orderItemService;
        public OrderItemsController(OrderItemService service)
        {
            this.orderItemService = service;
        }

        [HttpGet("get/id/{id}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetOrderItemById(int id)
        {
            try
            {
                return Ok(orderItemService.GetOrderItemById(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/orderid/{id}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetOrderItemByOrderId(int id)
        {
            try
            {
                return Ok(orderItemService.GetOrderItemByOrderId(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/prodid/{id}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetOrderItemByProductId(int id)
        {
            try
            {
                return Ok(orderItemService.GetOrderItemByProductId(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        [HttpGet("get/ordprodid/{orderId}/{productId}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetOrderItemByOrderAndProductId(int orderId,int productId)
        {
            try
            {
                return Ok(orderItemService.GetOrderItemByOrderAndProductId(orderId, productId));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("add/orderitem")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddToOrderItems(OrderItems orderItems)
        {
            try
            {
                orderItemService.AddToOrderItems(orderItems);
                return CreatedAtAction("AddToOrderItems", orderItems);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
