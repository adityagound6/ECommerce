using ECommerce.DAL.Model;
using ECommerce.Service.Interfaces;


namespace ECommerce.Service.Services
{
    public class CategoryService : GenericRepositoryService<ECommerceContext, Category>, ICategoryService
    {
   
    }
}
