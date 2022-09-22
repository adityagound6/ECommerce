using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Model
{
    public class GeneralResultApi<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Result { get; set; }
    }
}
