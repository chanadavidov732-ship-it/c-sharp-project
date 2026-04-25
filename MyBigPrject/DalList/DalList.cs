using DalApi;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalList
{
    internal sealed class DalList : IDal
    {
        public ICustomer Customer=>new CustomerImplementation();
        public IProduct Product => new ProductImplementation();
        public ISale Sale => new SaleImplementation();

        private static readonly DalList instance = new DalList();
        public static DalList Instance { get { return instance; } }

        private DalList()
        {
            
        }
    }
}
