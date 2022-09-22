using ECommerce.Core.Helper;
using ECommerce.Core.Interface;
using ECommerce.Core.Model;
using Microsoft.Extensions.Options;

namespace ECommerce.Core.Services
{
    public class ProductRepositry : IProductReppository
    {
        private readonly PathOptions _path;
        private readonly string _baseApiUrl;
        public ProductRepositry(string baseApiUrl, IOptions<PathOptions> path)
        {
            _path = path.Value;
            _baseApiUrl = baseApiUrl;
        }
        public async Task<Product> GetAllProduct()
        {
            APICallback<GeneralResultApi<Product>> data = new APICallback<GeneralResultApi<Product>>();
           
            throw new NotImplementedException();
        }
    }
}
