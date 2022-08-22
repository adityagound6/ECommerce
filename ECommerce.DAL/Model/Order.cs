using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Model
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public Product Products { get; set; } = new Product();
        public Customer Customer { get; set; } = new Customer();
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? Address { get; set; }
        public bool Status { get; set; }
        public DateTime date { get; set; }
    }
}
