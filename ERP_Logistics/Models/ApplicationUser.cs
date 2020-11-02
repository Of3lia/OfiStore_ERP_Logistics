using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Logistics.Models
{
    public class ApplicationUser : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public List<OrderClient> OrderClient { get; set; }
        public UserRoles Role { get; set; }
        public Address Address { get; set; }
    }

    public enum UserRoles
    {
        Admin, Employee, Customer
    }
}
