using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ProductInOrder
    {
        public int ProductOrderId { get; set; }
        public string ProductOrderName { get; set; }
        public double ProductOrderPrice { get; set; }
        public int ProductOrderCount { get; set; }
        List<SaleInProduct> ListSaleInProductOrder;
        public double ProductOrderTotalPrice { get; set; }

        public ProductInOrder() {}
        //full ctor
    }
}
