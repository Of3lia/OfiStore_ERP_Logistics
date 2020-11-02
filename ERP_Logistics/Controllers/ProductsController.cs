using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_Logistics.Data.Repositories;
using ERP_Logistics.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP_Logistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : GenericController<Product, ProductRepository>
    {
        public ProductsController(ProductRepository repository) : base(repository)
        {

        }
    }
}
