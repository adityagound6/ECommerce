using ECommerce.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Interface
{
    public interface IProductReppository
    {
        Task<Product> GetAllProduct();
    }
}
