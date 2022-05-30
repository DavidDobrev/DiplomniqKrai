using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusStationTickets.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int OrederDetailId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quality { get; set; }
        public Decimal Price { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
