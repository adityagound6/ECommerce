
using ECommerce.DAL.Model;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.Model
{
    public class CreateProduct
    {
        
        [Required(ErrorMessage = "product name is required")]
        public string? ProductName { get; set; }          
        public string? Description { get; set; }
        public string? Image { get; set; }
        [Required(ErrorMessage ="Category is required")]
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        
    }
}
