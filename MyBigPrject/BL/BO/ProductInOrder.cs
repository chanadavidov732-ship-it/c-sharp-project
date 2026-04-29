using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ProductInOrder
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductOrderCount { get; set; }
        public List<SaleInProduct> ListSaleInProductOrder;
        public double ProductTotalPrice { get; set; }

        public ProductInOrder() {}
        public ProductInOrder(int ProductId, string ProductName, double ProductPrice, int productOrderCount, List<SaleInProduct> listSaleInProductOrder, double ProductTotalPrice)
        {
            ProductId = ProductId;
            ProductName = ProductName;
            ProductPrice = ProductPrice;
            ProductOrderCount = productOrderCount;
            ListSaleInProductOrder = listSaleInProductOrder;
            ProductTotalPrice = ProductTotalPrice;
        }

    }
}
