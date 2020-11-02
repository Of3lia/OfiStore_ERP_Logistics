using ERP_Logistics.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Logistics.Data.Repositories
{
    public class OrderRepository : GenericRepository<Order, StoreContext>
    {
        private readonly StoreContext context;
        public OrderRepository(StoreContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IList<Order>> GetOrderByClient(string userid)
        {
             return await context.Orders
                .Where(c => c.OrderClient.Client.Id.ToString() == userid)
                .Include(o => o.OrderProducts)
                .ThenInclude(p => p.Product)
                .OrderBy(o => o.State)
                .ToListAsync();
        }

        public async Task<Order> GetOrderByEmployee(string userid)
        {
            return await context.Orders
               .Where(c => c.OrderEmployee.Employee.Id.ToString() == userid)
               .Where(o => o.State != OrderState.Finished)
               .Include(o => o.OrderProducts)
               .ThenInclude(p => p.Product)
               .Include(c => c.OrderClient)
               .ThenInclude(a => a.Client.Address)
               .FirstOrDefaultAsync();
        }
        public async Task<List<Order>> GetOrdersByAdmin()
        {
            return await context.Orders
               .Where(o => o.State == OrderState.Finished)
               .Include(o => o.OrderProducts)
               .ThenInclude(p => p.Product)
               .OrderBy(o => o.DateEnded)
               .ToListAsync();
        }

        public async Task<Order> ChangeOrderState(Order order)
        {
            Order Order = await context.Orders.Where(o => o.Id == order.Id).FirstOrDefaultAsync();
            Order.State = order.State;

            if (order.State == OrderState.Finished)
            {
                Order.DateEnded = DateTime.Now;
            }

            try
            {
                await context.SaveChangesAsync();
                return Order;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Order> AssignOrderToEmployee(string userid)
        {

            Order order = await context.Orders.Where(o => o.OrderEmployee.Employee == null).Where(o => o.State == OrderState.Pending).FirstOrDefaultAsync();

            if (order == null) { return null; }

            order.State = OrderState.Attending;
            order.DateStarted = DateTime.Now;

            ApplicationUser employee = await context.ApplicationUsers.Where(u => u.Id.ToString() == userid).FirstOrDefaultAsync();


            order.OrderEmployee = new OrderEmployee()
            {
                Employee = employee
            };

            try
            {
                await context.SaveChangesAsync();
                return order;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IList<Order>> GetOrderHistorialEmployee(string userid)
        {
            return await context.Orders
                .Where(c => c.OrderEmployee.Employee.Id.ToString() == userid)
                .Where(o => o.State == OrderState.Finished)
                .ToListAsync();
        }
    }
}
