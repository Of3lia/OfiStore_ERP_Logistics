using ERP_Logistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Logistics.Data.Repositories
{
     public class ProductRepository : GenericRepository<Product, StoreContext>
    {
        public ProductRepository(StoreContext context) : base(context)
        {

        }
    }
}
