using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.DAL.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public decimal ActualPrice { get; set; } = 0;
        public decimal DiscountPrice { get; set; } = 0;
        public decimal MainPrice { get; set; } = 0;
    }
}
