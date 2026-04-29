using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    internal class OrderImplementation : IOrder
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public void CalcTotalPriceForProduct(ProductInOrder p)
        {
            List<SaleInProduct> list = new List<SaleInProduct>();
            int c = p.ProductOrderCount;
            double sum;
            foreach (SaleInProduct sip in p.ListSaleInProductOrder)
            {
                if (c == 0)
                    break;
                if (c < sip.SaleCount)
                    continue;
                else
                {
                    sum = (c / sip.SaleCount) * sip.SalePrice;
                    c = (c / sip.SaleCount) % 10;
                    list.Add(sip);
                }
            }
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
        public void SearchSaleForProduct(ProductInOrder pin, bool forMember)
        {
            List<SaleInProduct> ls = pin.ListSaleInProductOrder;

            foreach (DO.Sale sale in _dal.Sale.ReadAll())
            {
                if (!forMember)
                    if (sale.ProductId == pin.ProductId &&
                        sale.SaleDateStart < DateTime.Now &&
                        sale.SaleDateEnd > DateTime.Now &&
                        pin.ProductOrderCount >= sale.Count &&
                        !sale.ForCustomerMember)
                        ls.Add(new SaleInProduct(sale.SaleId,
                            sale.Count, sale.Price, sale.ForCustomerMember));

                if (forMember)
                    if (sale.ProductId == pin.ProductId &&
                                                sale.SaleDateStart < DateTime.Now &&

                        sale.SaleDateEnd > DateTime.Now &&
                        pin.ProductOrderCount >= sale.Count)
                        ls.Add(new SaleInProduct(sale.SaleId,
                            sale.Count, sale.Price, sale.ForCustomerMember));


            }

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
