using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Model
{
    public class GeneralResultList<T>
    {
        public bool isSuccess { get; set; }
        public T Result { get; set; }
        public string Message { get; set; }
    }
}
