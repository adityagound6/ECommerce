using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.ModelVM
{
    public class OrderVm
    {
        public ProductVm Products { get; set; } = new ProductVm();
        public CustomerVm Customer { get; set; } = new CustomerVm();
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? Address { get; set; }
        public bool Status { get; set; }
        public DateTime date { get; set; }
    }
}
