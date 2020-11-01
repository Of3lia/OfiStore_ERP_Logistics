using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Logistics.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
