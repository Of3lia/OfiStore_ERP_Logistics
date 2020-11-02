using ERP_Logistics.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Logistics.Data.DummyData
{
    public class ApplicationUserData
    {
        public List<ApplicationUser> Get()
        {
            // All the Password Hashes are "password"

            var list = new List<ApplicationUser>();
            list.Add(new ApplicationUser()
            {
                UserName = "Admin",
                FullName = "Admin Rodriguez",
                Role = UserRoles.Admin,
                Password = BCrypt.Net.BCrypt.HashPassword("Admin"),
                Email = "MyEmail@Mail.com",
            });

            list.Add(new ApplicationUser()
            {
                UserName = "Sara",
                FullName = "Sara Swarswarz",
                Role = UserRoles.Employee,
                Password = BCrypt.Net.BCrypt.HashPassword("pass"),
                Email = "sarahh@Mail.com",
            });

            list.Add(new ApplicationUser()
            {
                UserName = "Fernanda",
                FullName = "Fernanda Malit",
                Role = UserRoles.Employee,
                Password = BCrypt.Net.BCrypt.HashPassword("pass"),
                Email = "fer2@Mail.com",
            });

            list.Add(new ApplicationUser()
            {
                UserName = "Rigoberta",
                FullName = "Rigoberta Rosales Reinaldina",
                Role = UserRoles.Employee,
                Password = BCrypt.Net.BCrypt.HashPassword("pass"),
                Email = "rrr@Mail.com",
            });
            
            list.Add(new ApplicationUser()
            {
                UserName = "Manfred",
                FullName = "Jose Santiago Manfredo de los Montes de Carolina",
                Role = UserRoles.Customer,
                Password = BCrypt.Net.BCrypt.HashPassword("pass"),
                Email = "mani@Mail.com",
            });

            list.Add(new ApplicationUser()
            {
                UserName = "Rosco",
                FullName = "Rosco Rostchild",
                Role = UserRoles.Customer,
                Password = BCrypt.Net.BCrypt.HashPassword("pass"),
                Email = "rrr2@Mail.com",
            });

            list.Add(new ApplicationUser()
            {
                UserName = "Eusebio",
                FullName = "Eusebio Fernandinez",
                Role = UserRoles.Customer,
                Password = BCrypt.Net.BCrypt.HashPassword("pass"),
                Email = "eusef@Mail.com",
            });
            list.Add(new ApplicationUser()
            {
                UserName = "Mirtha",
                FullName = "Mirtha Legrand",
                Role = UserRoles.Customer,
                Password = BCrypt.Net.BCrypt.HashPassword("pass"),
                Email = "mirtha@Mail.com",
            });
            
            list.Add(new ApplicationUser()
            {
                UserName = "Marta",
                FullName = "Marta Legrand",
                Role = UserRoles.Customer,
                Password = BCrypt.Net.BCrypt.HashPassword("pass"),
                Email = "martha@Mail.com",
            });
            
            list.Add(new ApplicationUser()
            {
                UserName = "Mica",
                FullName = "Micaela Marui",
                Role = UserRoles.Customer,
                Password = BCrypt.Net.BCrypt.HashPassword("pass"),
                Email = "mica@Mail.com",
            });
            list.Add(new ApplicationUser()
            {
                UserName = "Maca",
                FullName = "Macarena Marui",
                Role = UserRoles.Customer,
                Password = BCrypt.Net.BCrypt.HashPassword("pass"),
                Email = "Maca@Mail.com",
            });

            return list;
        }
    }
}
