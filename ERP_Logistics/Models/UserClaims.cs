using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Logistics.Models
{
    public class UserClaims
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Role { get; set; }
    }
}
