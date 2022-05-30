using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusStationTickets.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Range(0.01,99999999)]
        public double Price { get; set; }
        public Category Category { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }       
        public List<Cart> Carts { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}
