using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Logistics.Models
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public OrderState State { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime? DateEnded { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
        public OrderClient OrderClient { get; set; }
        public OrderEmployee OrderEmployee { get; set; }
    }

    public enum OrderState
    {
        Unrealized, Pending, Attending, Delivering, Finished, Cancelled
    }
}
