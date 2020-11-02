using ERP_Logistics.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Logistics.Data.DummyData
{
    public class DummyData
    {
        public static void CreateDummy(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<StoreContext>();

                var dbNotExisting = context.Database.EnsureCreated();

                //var _userManager = serviceScope.ServiceProvider.GetService<UserManager<IdentityUser>>();

                //if (!context.Roles.Any())
                //{
                //    context.Roles.AddRange(new RoleData().Get());
                //}
                //context.SaveChanges();

                if (!context.ApplicationUsers.Any())
                {
                    context.ApplicationUsers.AddRange(new ApplicationUserData().Get());
                }
                context.SaveChanges();

                var users = context.ApplicationUsers.ToList();

                //if (!context.UserRoles.Any())
                //{
                //    foreach (var u in users)
                //    {
                //        context.UserRoles.AddRange(new IdentityUserRole<string>() { RoleId = context.Roles.Where(r => r.Name == u.Role.ToString()).FirstOrDefault().Id, UserId = u.Id });
                //    }
                //}
                //context.SaveChanges();

                if (!context.Addresses.Any())
                {
                    int i = 1;

                    foreach (var u in users)
                    {
                        context.Addresses.AddRange(new AddressData().Get());
                        context.SaveChanges();

                        u.Address = context.Addresses.Where(a => a.Id == i).FirstOrDefault();
                        i++;
                    }
                }
                context.SaveChanges();

                if (!context.Products.Any())
                {
                    context.Products.AddRange(new ProductData().Get());
                }
                context.SaveChanges();

                if (!context.Orders.Any())
                {
                    foreach (var u in users)
                    {
                        context.Orders.AddRange(new OrderData().Get(u));
                    }
                }
                context.SaveChanges();

                if (!context.OrderProducts.Any())
                {
                    foreach (var order in context.Orders.ToList())
                    {
                        int rdm = new Random().Next(1, 10);
                        context.OrderProducts.AddRange(new OrderProductData().Get(
                        context.Products.Where(p => p.Id == rdm).FirstOrDefault(),
                        order
                            ));
                        rdm = new Random().Next(1, 10);
                        context.OrderProducts.AddRange(new OrderProductData().Get(
                       context.Products.Where(p=>p.Id == rdm).FirstOrDefault(),
                       order
                           ));
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
