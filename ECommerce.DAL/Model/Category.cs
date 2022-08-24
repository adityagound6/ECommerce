
using System.ComponentModel.DataAnnotations;


namespace ECommerce.DAL.Model
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime LastUpdateDatetime { get; set; }
        public bool isActive { get; set; } = true;
    }
}
