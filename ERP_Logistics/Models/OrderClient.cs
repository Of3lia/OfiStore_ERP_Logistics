using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Logistics.Models
{
    public class OrderClient
    {
        public int Id { get; set; }
        public ApplicationUser Client { get; set; }
    }
}
