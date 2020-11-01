using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Logistics.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public ProductCategories Category { get; set; }

        public enum ProductCategories
        {
            Toys, Food, Electronic, Instruments, Sports
        }
    }
}
