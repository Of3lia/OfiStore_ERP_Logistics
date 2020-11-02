using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Logistics.Data.DummyData
{
    public class RoleData
    {
        public List<IdentityRole> Get()
        {
            var list = new List<IdentityRole>();
            list.Add(new IdentityRole()
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            });
            list.Add(new IdentityRole()
            {
                Name = "Employee",
                NormalizedName = "EMPLOYEE"
            });
            list.Add(new IdentityRole()
            {
                Name = "Customer",
                NormalizedName = "CUSTOMER"
            });

            return list;
        }
    }
}
