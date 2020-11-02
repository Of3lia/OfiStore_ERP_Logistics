using ERP_Logistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Logistics.Data.DummyData
{
    public class OrderProductData
    {
        public List<OrderProduct> Get(Product product, Order order)
        {
            var list = new List<OrderProduct>();
            list.Add(new OrderProduct
            {
                Product = product,
                Order = order,
                Quantity = 3
            });
            return list;
        }
    }
}
