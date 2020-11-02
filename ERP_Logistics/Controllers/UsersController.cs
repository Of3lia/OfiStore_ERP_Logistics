using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_Logistics.Data.Repositories;
using ERP_Logistics.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP_Logistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly StoreContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly UserRepository repository;

        public UsersController(StoreContext _context, UserManager<ApplicationUser> _userManager, UserRepository repository)
        {
            context = _context;
            userManager = _userManager;
            this.repository = repository;
        }

        //// GET: api/Users
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<IdentityUser>>> GetUsers()
        //{
        //    return await _context.Users
        //        .ToListAsync();
        //}

        //[HttpPost]
        //[Authorize(Roles = "Admin")]
        //[Route("GetUsersList")]
        //public async Task<IList<ApplicationUser>> GetUsersList([FromBody] ListModel listModel)
        //{
        //    return await repository.GetUsersProfiles(listModel);
        //}



        //// GET: api/Users/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<IdentityUser>> GetUser(int id)
        //{
        //    var user = await _context.Users.FindAsync(id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return user;
        //}

        //// PUT: api/Users/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser(int id, ApplicationUser user)
        //{
        //    if (id.ToString() != user.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Users
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<ApplicationUser>> PostUser(ApplicationUser user)
        //{
        //    _context.Users.Add(user);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUser", new { id = user.Id }, user);
        //}

        //// DELETE: api/Users
        //[HttpDelete]
        //public async Task<ActionResult<ApplicationUser>> DeleteUser([FromBody] int id)
        //{
        //    var user = await context.ApplicationUsers.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    context.Users.Remove(user);
        //    await context.SaveChangesAsync();

        //    return user;
        //}

        //[HttpPut]
        //public async Task<ActionResult<ApplicationUser>> Update ([FromBody] ApplicationUserModel _user)
        //{
        //    var user = await userManager.FindByIdAsync(_user.Id);
        //    if(user != null)
        //    {
        //        user.UserName = _user.UserName;
        //        user.FullName = _user.FullName;
        //        user.Email = _user.Email;

        //        if(user.Role != _user.Role)
        //        {
        //            await userManager.RemoveFromRoleAsync(user, user.Role.ToString());
        //            user.Role = _user.Role;
        //            await userManager.AddToRoleAsync(user, _user.Role.ToString());
        //        }
        //        IdentityResult result = await userManager.UpdateAsync(user);
        //        if (result.Succeeded)
        //        {
        //            return Ok();
        //        }
        //        else
        //        {
        //            Errors(result);
        //        }
        //    }
        //    return NotFound();
        //}


        // DELETE: api/Users
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete (string id)
        //{
        //    var user = await userManager.FindByIdAsync(id);
        //    if (user != null)
        //    {
        //        IdentityResult result = await userManager.DeleteAsync(user);

        //        if (result.Succeeded)
        //        {
        //            return Ok();
        //        }
        //        else
        //        {
        //            Errors(result);
        //        }
        //    }
        //    return NotFound();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    ApplicationUser user = await userManager.FindByIdAsync(id);
        //    if (user != null)
        //    {
        //        IdentityResult result = await userManager.DeleteAsync(user);
        //        if (result.Succeeded)
        //            return RedirectToAction("Index");
        //        else
        //            Errors(result);
        //    }
        //    else
        //        ModelState.AddModelError("", "User Not Found");
        //    return View("Index", userManager.Users);
        //}

        //private void Errors(IdentityResult result)
        //{
        //    foreach (IdentityError error in result.Errors)
        //        ModelState.AddModelError("", error.Description);
        //}

        //private bool UserExists(int id)
        //{
        //    return _context.Users.Any(e => e.Id == id.ToString());
        //}
    }
}
