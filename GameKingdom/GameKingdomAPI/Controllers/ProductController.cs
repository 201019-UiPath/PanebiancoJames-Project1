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
    public class ProductController : ControllerBase
    {
        private readonly ProductService productService;
        public ProductController(ProductService service)
        {
            this.productService = service;
        }

        [HttpGet("get/id/{id}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                return Ok(productService.GetProductById(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/name/{name}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetProductByName(string name)
        {
            try
            {
                return Ok(productService.GetProductByName(name));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/prod")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetAllProducts()
        {
            try
            {
                return Ok(productService.GetAllProducts());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("add/product")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddProduct(Product newProduct)
        {
            try
            {
                productService.AddProduct(newProduct);
                return CreatedAtAction("AddProduct", newProduct);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
