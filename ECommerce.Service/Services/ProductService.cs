using ECommerce.DAL.Model;
using ECommerce.Service.Interfaces;


namespace ECommerce.Service.Services
{
    public class ProductService : GenericRepositoryService<ECommerceContext,Product>,IProductService
    {
    }
}
