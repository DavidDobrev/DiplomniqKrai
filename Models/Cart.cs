using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusStationTickets.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public DateTime DateCreated { get; set; }
        public string CustomerId { get; set; }
        public int Quality { get; set;}
        public double Price { get; set; }
        public Product Product { get; set; }

    }
}
