using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IProduct
    {
        int Create(Product item);
        Product? Read(int id);
        Product? Read(Func<Product, bool> filter);
        List<Product?> ReadAll(Func<Product, bool>? filter = null);
        void Delete(int id);
        void UpDate(Product item);
        void GetAllSale(ProductInOrder pio,bool isPrefer);
    }
}
