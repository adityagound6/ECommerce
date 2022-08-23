using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Model
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? Address { get; set; }
        public bool Status { get; set; }
        public DateTime date { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime LastUpdateDatetime { get; set; }
    }
}
