using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
