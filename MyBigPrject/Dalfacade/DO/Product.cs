using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Product(int ProductId, string ProductName, Category ProductCategory, int ProductQuntity, double ProductPrice, DateTime ProductDateCreat)
    {
        public Product() : this(0, "shoes",Category.CHILDREN, 5, 100, DateTime.Now) { }

    }
}
