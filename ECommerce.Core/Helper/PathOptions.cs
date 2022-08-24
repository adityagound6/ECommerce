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
        public Category MyProperty { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
    public class Category
    {
        public string GetAll { get; set; }
        public string GetById { get; set; }
        public string Create { get; set; }
        public string Delete { get; set; }
        public string Update { get; set; }
    }
    public class Product
    {
        public string GetAll { get; set; }
        public string GetById { get; set; }
        public string Create { get; set; }
        public string Delete { get; set; }
        public string Update { get; set; }
        public string GetByCategoryId { get; set; }
    }
    public class Order
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
