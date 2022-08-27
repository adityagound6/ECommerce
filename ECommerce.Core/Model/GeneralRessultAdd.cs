using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Model
{
    public class GeneralRessultAdd
    {
        public string Message { get; set; }
        public bool isSucces { get; set; }
        public List<string> ValidationError { get; set; } = new List<string>();
    }
}
