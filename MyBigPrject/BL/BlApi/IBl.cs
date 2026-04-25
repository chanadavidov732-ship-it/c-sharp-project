using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IBl
    {
        public ICustomer Customer { get; }
        public IProduct Product { get; }
        public ISale Sale { get; }
    }
}
