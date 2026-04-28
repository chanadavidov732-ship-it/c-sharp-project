using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    internal interface IOrder
    {
        List<SaleInProduct> AddProductToOrder(Order o,int id,int count);
        void CalcTotalPriceForProduct(ProductInOrder p);
        void CalcTotalPrice(Order o);
        void DoOrder(Order o);
        void SearchSaleForProduct(ProductInOrder pin,bool isPrefer);
    }
}
