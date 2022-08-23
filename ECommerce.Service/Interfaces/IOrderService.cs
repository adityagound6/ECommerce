using ECommerce.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Interfaces
{
    public interface IOrderService : IGenericRepository<Order>
    {
    }
}
