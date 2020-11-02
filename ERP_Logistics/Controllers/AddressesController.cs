using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_Logistics.Data.Repositories;
using ERP_Logistics.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP_Logistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressesController : GenericController<Address, AddressRepository>
    {
        public AddressesController(AddressRepository repository) : base(repository)
        {

        }
    }
}
