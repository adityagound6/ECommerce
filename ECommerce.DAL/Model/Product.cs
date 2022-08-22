using System.ComponentModel.DataAnnotations;

namespace ECommerce.DAL.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public Category Category { get; set; } = new Category();
        public decimal ActualPrice { get; set; } = 0;
        public decimal DiscountPrice { get; set; } = 0;
    }
}
