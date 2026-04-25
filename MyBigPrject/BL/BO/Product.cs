using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    internal class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Category ProductCategory { get; set; }
        public int ProductQuntity { get; set; }
        public double ProductPrice { get; set; }
        public DateTime ProductDateCreat { get; set; }
        public Product( int ProductId, string ProductName, Category ProductCategory, int ProductQuntity, double ProductPrice, DateTime ProductDateCreat)
        {
            this.ProductId = ProductId;
            this.ProductName = ProductName;
            this.ProductCategory = ProductCategory;
            this.ProductQuntity = ProductQuntity;
            this.ProductPrice = ProductPrice;
            this.ProductDateCreat = ProductDateCreat;
        }
    }
}
