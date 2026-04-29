using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class SaleInProduct
    {
        public int SaleId { get; set; }
        public int SaleCount { get; set; }
        public double SalePrice { get; set; }
        public bool SaleProductForCustomer { get; set; }
        public SaleInProduct() {}
        public SaleInProduct(int saleId, int saleCount, double salePrice, bool SaleProductForCustomer)
        {
            SaleId = SaleId;
            SaleCount = SaleCount;
            SalePrice = SalePrice;
            SaleProductForCustomer = SaleProductForCustomer;
        }

    }
}
