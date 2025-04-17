using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public class IServiceManager
    {
        public IProductService ProductService { get;  }
    }
}
