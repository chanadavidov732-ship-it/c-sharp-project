using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Sale(int SaleId,int ProductId,int Count,int Price,bool ForCustomerMember, DateTime SaleDateStart, DateTime SaleDateEnd)
    {
        public Sale() : this(0,0,2,500,false,DateTime.Now, DateTime.Now.AddMonths(1)) { }
    }

}
