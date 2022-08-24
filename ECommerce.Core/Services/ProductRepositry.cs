using ECommerce.Core.Interface;
using ECommerce.Core.Model;

namespace ECommerce.Core.Services
{
    public class ProductRepositry : IProductReppository
    {
        private readonly string baseApiUrl;
        public ProductRepositry(string baseApiUrl)
        {
            this.baseApiUrl = baseApiUrl;
        }
        public Task<Product> GetAllProduct()
        {
            throw new NotImplementedException();
        }
    }
}
