using ECommerce.DAL.Model;
using ECommerce.Service.Interfaces;

namespace ECommerce.Service.Services
{
    public class OrderService : GenericRepositoryService<ECommerceContext, Order>,IOrderService
    {
    }
}
