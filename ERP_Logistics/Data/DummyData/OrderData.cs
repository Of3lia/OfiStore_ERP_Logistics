using ERP_Logistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ERP_Logistics.Data.DummyData
{
    public class OrderData
    {
        public List<Order> Get(ApplicationUser client)
        {
            var list = new List<Order>();
            list.Add(new Order()
            {
                State = OrderState.Unrealized,
                OrderClient = new OrderClient()
                {
                    Client = client
                }
            });
            list.Add(new Order()
            {
                State = OrderState.Pending,
                OrderClient = new OrderClient()
                {
                    Client = client
                }
            });
            DateTime date = DateTime.Now;
            DateTime randomDate = date.AddDays(new Random().Next(-10, -1));
            list.Add(new Order()
            {
                State = OrderState.Finished,
                OrderClient = new OrderClient()
                {
                    Client = client
                },
                DateStarted = randomDate,
                DateEnded = randomDate.AddDays(1),
            });
            return list;
        }
    }
}