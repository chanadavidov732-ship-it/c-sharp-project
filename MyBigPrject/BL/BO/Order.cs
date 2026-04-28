using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Order
    {
        public bool member { get; set; }
        public int TotalPrice { get; set; }
        public List<ProductInOrder> ProductListInOrder { get; set; }
    }
}
