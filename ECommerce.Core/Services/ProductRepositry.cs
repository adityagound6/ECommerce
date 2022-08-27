using ECommerce.Core.Helper;
using ECommerce.Core.Interface;
using ECommerce.Core.Model;
using Microsoft.Extensions.Options;

namespace ECommerce.Core.Services
{
    public class ProductRepositry : IProductReppository
    {
        private readonly PathOptions _path;
        public ProductRepositry(IOptions<PathOptions> path)
        {
            _path = path.Value;
        }
        public async Task<List<Product>> GetAllProduct()
        {
            GeneralResultList<List<Product>> data = await ApiCall<List<Product>>.CallFunction(_path.WebBaseUrl + _path.Product.GetAll);
            if (data.isSuccess == true)
            {
                var product = data.Result;
                return product;
            }
            return null;
        }
    }
}
