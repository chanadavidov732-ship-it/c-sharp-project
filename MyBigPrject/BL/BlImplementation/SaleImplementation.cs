using BlApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    internal class SaleImplementation:ISale
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;
    }
}
