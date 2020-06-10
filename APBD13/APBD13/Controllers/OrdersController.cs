using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD13.Models;
using APBD13.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD13.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private IConfectioneryDbService _service;
        public OrdersController(IConfectioneryDbService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_service.GetOrders());
        }

        [HttpGet("{name}")]
       
        public IActionResult GetOrdersByName(string name)
        {
            return Ok(_service.GetOrders(name));
        }

        [HttpPost("{id}")]
        public IActionResult AddOrder(AddOrderRequest request, int id)
        {
            var errorCode = _service.AddOrder(request, id);
            switch (errorCode)
            {
                case -1:
                    return NotFound("Confectionery not found!");
                case -2:
                    return NotFound("Customer not found!");
                case -3:
                    return BadRequest("Wrong request format!");

            }
            return Ok("Added!");
        }
        
    }
}