using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.API.Model
{
    public class CreateOrder
    {
        [Required(ErrorMessage ="Product id required")]
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Customer is required")]
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        [Required(ErrorMessage ="Address is required")]
        public string? Address { get; set; }
        public bool Status { get; set; }
        [Required(ErrorMessage ="Mobile number is required")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage ="Pincode is required")]
        public string Pincode { get; set; }
    }
}
