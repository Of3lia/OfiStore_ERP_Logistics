using ERP_Logistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Logistics.Data.DummyData
{
    public class AddressData
    {
        public List<Address> Get()
        {
            var list = new List<Address>();
            list.Add(new Address()
            {
                Street = "Ringwood Ave",
                StreetNumber = 56,
                Door = "B",
                City = "Palo Alto",
                Country = "USA",
                PostalCode = "9832164",
            });
            return list;
        }
    }
}
