using ECommerce.DAL.Model;
using ECommerce.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Services
{
    public class CustomerService : GenericRepositoryService<ECommerceContext, Customer>,ICustomerService
    {
    }
}
