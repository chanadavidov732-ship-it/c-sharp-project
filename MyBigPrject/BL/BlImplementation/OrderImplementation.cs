using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    internal class OrderImplementation:IOrder
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;


        public void CalcTotalPriceForProduct(ProductInOrder p)
        {

        }
        public double CalcTotalPrice(Order o)
        {

        }
        public void DoOrder(Order o)
        {
            
            foreach (ProductInOrder p in o.ProductListInOrder)
            {
                
            }
        }
        public void SearchSaleForProduct(ProductInOrder pin, bool isPrefer)
        {

        }
        public List<SaleInProduct> AddProductToOrder(Order o, int id, int count)
        {
            Product pr = Tools.ConversDoProductToBoProduct(_dal.Product.Read(id));
            List<ProductInOrder> pi = o.ProductListInOrder;
            foreach (var item in pi)
            {
                if (item.ProductOrderId == id)
                {
                    if (pr.ProductQuntity >= count)
                    {
                        pr.ProductQuntity -= count;
                        item.ProductOrderCount += count;
                    }
                    else
                        /////need to change the exception type and message
                        throw new Exception();
                }
            }
            if (pr.ProductQuntity >= count)
            {
                pr.ProductQuntity -= count;
                //לעשות את 2 הפרמטרים האחרים של המחלקה לפי הפונקציות פה
                pi.Add(new ProductInOrder(id, pr.ProductName, pr.ProductPrice, count,));
            }
            else
                /////need to change the exception type and message
                throw new Exception();



        }

    }
}
