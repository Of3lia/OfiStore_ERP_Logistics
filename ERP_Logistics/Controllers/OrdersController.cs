using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERP_Logistics.Models;
using ERP_Logistics.Data.Repositories;

namespace ERP_Logistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : GenericController<Order, OrderRepository>
    {
        public readonly OrderRepository repository;

        public OrdersController(OrderRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("GetOrderByClient")]
        public async Task<IList<Order>> GetOrderByClient()
        {
            string userid = User.Claims.First(c => c.Type == "userid").Value;
            return await repository.GetOrderByClient(userid);
        }

        [HttpGet]
        [Route("GetOrderByEmployee")]
        public async Task<Order> GetOrderByEmployee()
        {
            string userid = User.Claims.First(c => c.Type == "userid").Value;

            var result = await repository.GetOrderByEmployee(userid);
            return result;
        }
        [HttpGet]
        [Route("GetOrdersByAdmin")]
        public async Task<List<Order>> GetOrdersByAdmin()
        {
            var result = await repository.GetOrdersByAdmin();
            return result;
        }

        [HttpGet]
        [Route("GetOrderHistorialEmployee")]
        public async Task<IList<Order>> GetOrderHistorialEmployee()
        {
            string userid = User.Claims.First(c => c.Type == "userid").Value;

            return await repository.GetOrderHistorialEmployee(userid);
        }

        [HttpGet]
        [Route("AssignOrderToEmployee")]
        public async Task<ActionResult<Order>> AssignOrderToEmployee()
        {
            string userid = User.Claims.First(c => c.Type == "userid").Value;

            var result = await repository.AssignOrderToEmployee(userid);

            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPut]
        [Route("ChangeOrderState")]
        public async Task<IActionResult> ChangeOrderState([FromBody] Order order)
        {
            var result = await repository.ChangeOrderState(order);
            return Ok(result);
        }
    }
}
