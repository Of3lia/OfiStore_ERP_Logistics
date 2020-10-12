using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_Logistics.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP_Logistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AuthenticationContext _context;

        public UserController(AuthenticationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUser()
        {
            return await _context.ApplicationUsers
                .Include(x => x.Orders)
                .ToListAsync();

        }
    }
}
