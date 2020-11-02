using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ERP_Logistics.Data.Repositories;
using ERP_Logistics.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ERP_Logistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ApplicationUsersController : GenericController<ApplicationUser, ApplicationUserRepository>
    {
        private readonly ApplicationUserRepository repository;

        public ApplicationUsersController(ApplicationUserRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        //POST : /api/ApplicationUser/Register
        public override async Task<ActionResult<ApplicationUser>> Post(ApplicationUser item)
        {
            var user = await repository.Register(item);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        //POST : /api/ApplicationUser/Register
        public async Task<ActionResult<ApplicationUser>> Login(ApplicationUser item)
        {
            var token = await repository.Login(item);

            if(token == "Error")
            {
                return NotFound();
            }

            return Ok(new
            {
                token
            });
        }

        [HttpGet]
        [Route("UserProfile")]
        //GET : /api/UserProfile
        public async Task<ActionResult<ApplicationUser>> GetUserProfile()
        {
            var userid = User.Claims.First(t => t.Type == "userid").Value;

            var userProfile = await repository.GetUserProfile(userid);
            return userProfile;
        }

        [HttpPost]
        [Authorize(Policy = Policies.Admin)]
        [Route("GetUsersList")]
        public async Task<IList<ApplicationUser>> GetUsersList([FromBody] ListModel listModel)
        {
            return await repository.GetUsersProfiles(listModel);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<ActionResult<ApplicationUser>> UpdateUser([FromBody] ApplicationUser _user)
        {
            var result = await repository.UpdateUser(_user);

            if(result == null)
            {
                return NotFound();
            }
            return Ok();
        }

        //[HttpGet]
        //[Route("GetClaims")]
        //public string GetClaims()
        //{
        //    return User.Claims.Where(c => c.Type == "userid").FirstOrDefault().Value;
        //    //return User.Claims.ToList();
        //}
    }
}
