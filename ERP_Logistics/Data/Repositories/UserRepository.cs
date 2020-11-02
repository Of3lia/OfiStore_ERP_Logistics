using ERP_Logistics.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Logistics.Data.Repositories
{
    public class UserRepository : GenericRepository<ApplicationUser, StoreContext>
    {
        private readonly StoreContext context;
        private readonly UserManager<ApplicationUser> userManager;
        public UserRepository(StoreContext context, UserManager<ApplicationUser> userManager) : base(context)
        {
            this.context = context;
            this.userManager = userManager;
        }

        //public async Task<List<ApplicationUser>> GetUsersProfiles ([FromBody] ListModel listModel)
        //{
        //    string role = "";

        //    switch (listModel.Role)
        //    {
        //        case UserRoles.Admin:
        //            role = "0";
        //            break;
        //        case UserRoles.Employee:
        //            role = "1";
        //            break;
        //        case UserRoles.Customer:
        //            role = "2";
        //            break;
        //        default:
        //            role = "";
        //            break;
        //    }

        //    return await context.ApplicationUsers
        //        .Where(u => ((string)((object)u.Role)).Contains(role))
        //        .Where(u => u.UserName.Contains(listModel.SearchUserName))
        //        .Skip(listModel.Skip)
        //        .Take(listModel.Take)
        //        //.AsNoTracking()
        //        .ToListAsync();
        //}
    }
}
