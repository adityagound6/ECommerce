using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.Model
{
    public class UpdateCategory
    {
        [Required(ErrorMessage ="Category id is required")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Category name is required")]
        public string? CategoryName { get; set; }
    }
}
