
using System.ComponentModel.DataAnnotations;


namespace ECommerce.DAL.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string? CustomerFirstName { get; set; }
        public string? CustomerlastName { get; set; }
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int Role { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime LastUpdateDatetime { get; set; }
        public bool isActive { get; set; } = true;
    }
}
