
using System.ComponentModel.DataAnnotations;


namespace ECommerce.DAL.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int Role { get; set; }
    }
}
