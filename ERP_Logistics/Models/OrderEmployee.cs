using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Logistics.Models
{
    public class OrderEmployee
    {
        public int Id { get; set; }
        public ApplicationUser Employee { get; set; }
    }
}
