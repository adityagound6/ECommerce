using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.ModelVM
{
    public class ProductVm
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public CategoryVm Category { get; set; } = new CategoryVm();
    }
}
