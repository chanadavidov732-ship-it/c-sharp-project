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
        public List<SaleInProduct> ListSaleInProductOrder;
        public double ProductOrderTotalPrice { get; set; }

        public ProductInOrder() {}
        public ProductInOrder(int productOrderId, string productOrderName, double productOrderPrice, int productOrderCount, List<SaleInProduct> listSaleInProductOrder, double productOrderTotalPrice)
        {
            ProductOrderId = productOrderId;
            ProductOrderName = productOrderName;
            ProductOrderPrice = productOrderPrice;
            ProductOrderCount = productOrderCount;
            ListSaleInProductOrder = listSaleInProductOrder;
            ProductOrderTotalPrice = productOrderTotalPrice;
        }
    }
}
