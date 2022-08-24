using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Helper
{
    public class PathOptions
    {
        public const string Path = "Path";
        public string WebBaseUrl { get; set; }
        public CategoryPath MyProperty { get; set; }
        public ProductPath Product { get; set; }
        public OrderPath Order { get; set; }
    }
    public class CategoryPath
    {
        public string GetAll { get; set; }
        public string GetById { get; set; }
        public string Create { get; set; }
        public string Delete { get; set; }
        public string Update { get; set; }
    }
    public class ProductPath
    {
        public string GetAll { get; set; }
        public string GetById { get; set; }
        public string Create { get; set; }
        public string Delete { get; set; }
        public string Update { get; set; }
        public string GetByCategoryId { get; set; }
    }
    public class OrderPath
    {
        public string GetAll { get; set; }
        public string GetById { get; set; }
        public string Create { get; set; }
        public string Delete { get; set; }
        public string Update { get; set; }
        public string GetByCustomerId { get; set; }
        public string GetByOrderNumber { get; set; }
    }
}
