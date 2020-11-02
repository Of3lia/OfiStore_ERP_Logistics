using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Logistics.Models
{
    public class ListModel
    {
        public UserRoles Role { get; set; }
        public string SearchUserName { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
