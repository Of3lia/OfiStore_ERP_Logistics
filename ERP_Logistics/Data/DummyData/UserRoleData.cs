using ERP_Logistics.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Logistics.Data.DummyData
{
    public class UserRoleData
    {
        public List<IdentityUserRole<string>> Get(List<string> roleId, List<string> userId)
        {
            var list = new List<IdentityUserRole<string>>();
            list.Add(new IdentityUserRole<string>()
            {
                RoleId = roleId[0],
                UserId = userId[0]
            });
            list.Add(new IdentityUserRole<string>()
            {
                RoleId = roleId[1],
                UserId = userId[1]
            });

            return list;
        }
    }
}
