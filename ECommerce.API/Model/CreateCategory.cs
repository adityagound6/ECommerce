using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.Model
{
    public class CreateCategory
    {
        [Required(ErrorMessage ="Category name is requored")]
        public string CategoryName { get; set; }
    }
}
