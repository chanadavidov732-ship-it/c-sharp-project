using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class SaleInProduct
    {
        public int SaleProductId { get; set; }
        public int SaleProductCount { get; set; }
        public double SaleProductPrice { get; set; }
        public bool SaleProductCustomer { get; set; }
        public SaleInProduct() {}
        public SaleInProduct(int saleProductId, int saleProductCount, double saleProductPrice, bool saleProductCustomer)
        {
            SaleProductId = saleProductId;
            SaleProductCount = saleProductCount;
            SaleProductPrice = saleProductPrice;
            SaleProductCustomer = saleProductCustomer;
        }
    }
}
