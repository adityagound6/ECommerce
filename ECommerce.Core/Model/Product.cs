using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
        public decimal ActualPrice { get; set; } = 0;
        public decimal DiscountPrice { get; set; } = 0;
        public decimal MainPrice { get; set; } = 0;
        public DateTime CreateDateTime { get; set; }
        public DateTime LastUpdateDatetime { get; set; }
        public bool isActive { get; set; } 
    }
}
