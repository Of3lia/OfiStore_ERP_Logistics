using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ERP_Logistics.Data.Repositories;
using ERP_Logistics.Migrations;
using ERP_Logistics.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP_Logistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderProductsController : GenericController<OrderProduct, OrderProductRepository>
    {
        public readonly OrderProductRepository repository;
        public OrderProductsController(OrderProductRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Route("PostProductInOrder")]
        public async Task<IActionResult> PostProductInOrder([FromBody] OrderProduct orderProduct)
        {
            string userid = User.Claims.Where(c => c.Type == "userid").FirstOrDefault().Value;

            await repository.PostProductInOrder(orderProduct, userid);
            return CreatedAtAction("Get", new { id = orderProduct.Id }, orderProduct);
        }

        [HttpPost]
        [Route("RemoveProduct")]
        public async Task<ActionResult<OrderProduct>> RemoveProduct(OrderProduct orderProduct)
        {
            var product = await repository.RemoveProduct(orderProduct.Id.ToString());

            if (orderProduct == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
