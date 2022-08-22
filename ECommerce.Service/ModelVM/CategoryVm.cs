using ECommerce.DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.ModelVM
{
    public class CategoryVm
    {
        public static explicit operator CategoryVm(Category item)
        {
            return new CategoryVm
            {
                 CategoryName = item.CategoryName,
            };
        }
        [Required(ErrorMessage = "Category is required")]
        public string CategoryName { get; set; }
        public Category ToCategoryDbModel()
        {
            return new Category
            {
                CategoryName = CategoryName,
            };
        }
    }
    
}
