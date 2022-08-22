
using ECommerce.DAL.Model;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.Model
{
    public class CreateProduct
    {
        public static explicit operator CreateProduct(Product item)
        {
            return new CreateProduct
            {
                ProductName = item.ProductName, 
                ActualPrice = item.ActualPrice,
                Description = item.Description,
                Image = item.Image,
                DiscountPrice = item.DiscountPrice,
                CategoryName = item.Category.CategoryName,
                CategoryId = item.Category.CategoryId
            };
        }
        [Required(ErrorMessage = "product name is required")]
        public string? ProductName { get; set; }          
        public string? Description { get; set; }
        public string? Image { get; set; }
        [Required(ErrorMessage ="Category is required")]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public decimal ActualPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public Product ToCreateDbModel()
        {
            return new Product
            {
                ProductName = ProductName,
                Description = Description,
                Image = Image,
                ActualPrice = ActualPrice,
                DiscountPrice = DiscountPrice,
                Category = new Category { CategoryId = CategoryId,CategoryName = CategoryName}
            };
        }
    }
}
