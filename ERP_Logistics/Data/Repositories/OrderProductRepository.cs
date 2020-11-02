using ERP_Logistics.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ERP_Logistics.Data.Repositories
{
    public class OrderProductRepository : GenericRepository<OrderProduct, StoreContext>
    {
        public readonly StoreContext context;
     //   public readonly HttpContext httpContext;
        public OrderProductRepository(StoreContext context/*, HttpContext httpContext*/) : base(context)
        {
            this.context = context;
           // this.httpContext = httpContext;
        }

        public async Task<OrderProduct> PostProductInOrder(OrderProduct orderProduct, string userId)
        {
            //string userId = httpContext.User.Claims.First(c => c.Type == "userid").Value;

            OrderProduct ExistingOrderProduct = context.OrderProducts
                                                .Where(o => o.Product.Id == orderProduct.Product.Id)
                                                .Where(o => o.Order.OrderClient.Client.Id.ToString() == userId)
                                                .Where(o => o.Order.State == OrderState.Unrealized).FirstOrDefault();

            // If order product exists, add product quantity.
            if (ExistingOrderProduct != null)
            {
                // If quantity is negative it means that we should add the new quantity to the old one, instead of assign a quantity.
                if (orderProduct.Quantity > 0)
                {
                    ExistingOrderProduct.Quantity = orderProduct.Quantity;
                }
                else
                {
                    ExistingOrderProduct.Quantity += Math.Abs(orderProduct.Quantity);
                }

                await context.SaveChangesAsync();
                return ExistingOrderProduct;
            }
            else // order product doesnt exist, therefore create one.
            {
                Order UnrealizedOrder = context.Orders.Where(o => o.OrderClient.Client.Id.ToString() == userId).Where(o => o.State == OrderState.Unrealized).FirstOrDefault();

                // If unrealized order dont exist we create one
                if (UnrealizedOrder == null)
                {
                    UnrealizedOrder = context.Orders.Add(new Order()
                    {
                        OrderClient = new OrderClient()
                        {
                            Client = context.ApplicationUsers.Where(u => u.Id.ToString() == userId).FirstOrDefault()
                        },
                        State = OrderState.Unrealized
                    }).Entity;
                }
                var NewOrderProduct = context.OrderProducts.Add(new OrderProduct()
                {
                    Order = UnrealizedOrder,
                    Product = context.Products.Where(p => p.Id == orderProduct.Product.Id).FirstOrDefault(),
                    Quantity = Math.Abs(orderProduct.Quantity)
                });
                await context.SaveChangesAsync();
                return NewOrderProduct.Entity;
            }
        }

        public async Task<OrderProduct> RemoveProduct(string id)
        {
            OrderProduct OrderProduct = await context.OrderProducts.FindAsync(id);

            context.OrderProducts.Remove(OrderProduct);
            await context.SaveChangesAsync();
            return OrderProduct;
        }
    }
}
