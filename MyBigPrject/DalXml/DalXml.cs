using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//מנועה ואילה
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("DalTest")]
namespace Dal
{
    internal sealed class DalXml : IDal
    {
        public ICustomer Customer => new CustomerImplementation();
        public IProduct Product => new ProductImplementation();
        public ISale Sale => new SaleImplementation();
        private static readonly DalXml instance = new DalXml();
        public static DalXml Instance { get { return instance; } }


        private DalXml()
        {

        }
    }
}

