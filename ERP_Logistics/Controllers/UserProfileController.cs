using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_Logistics.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP_Logistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private StoreContext context;
        public UserProfileController(StoreContext context)
        {
            this.context = context;
        }

        //[HttpGet]
        ////GET : /api/UserProfile
        //public async Task<ActionResult<ApplicationUser>> GetUserProfile(ApplicationUser user)
        //{
        //    //string userId = User.Claims.FirstOrDefault(c => c.Type == "UserID").Value;
        //    //var user = await _userManager.FindByIdAsync(userId);
        //    //var role = await _userManager.GetRolesAsync(user);

        //    return await context.ApplicationUsers
        //                        .Where(u => u.UserName == user.UserName)
        //                        .Include(a => a.Address)
        //                        .FirstOrDefaultAsync();

        //    //return new
        //    //{
        //    //    user.Id,
        //    //    user.FullName,
        //    //    user.Email,
        //    //    user.UserName,
        //    //    user.PhoneNumber,
        //    //    addressId,
        //    //    roles
        //    //};
        //}

        //[HttpGet]
        //[Authorize(Roles = "Admin")]
        //[Route("ForAdmin")]
        //public string GetForAdmin()
        //{
        //    return "Web method for admin";
        //}

        //[HttpGet]
        //[Authorize(Roles = "Customer")]
        //[Route("ForCustomer")]
        //public string GetForCustomer()
        //{
        //    return "Web method for customer";
        //}

        //[HttpGet]
        //[Authorize(Roles = "Admin,Customer")]
        //[Route("ForAdminOrCustomer")]
        //public string GetForAdminOrCustomer()
        //{
        //    return "Web method for admin or customer";
        //}
    }
}
