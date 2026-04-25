using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    internal class Sale
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public bool ForCustomerMember { get; set; }
        public DateTime SaleDateStart { get; set; }
        public DateTime SaleDateEnd { get; set; }


        public Sale(int SaleId, int ProductId, int Count, int Price, bool ForCustomerMember, DateTime SaleDateStart, DateTime SaleDateEnd)
        {
            this.SaleId = SaleId;
            this.ProductId = ProductId;
            this.Count = Count;
            this.Price = Price;
            this.ForCustomerMember = ForCustomerMember;
            this.SaleDateStart = SaleDateStart;
            this.SaleDateEnd = SaleDateEnd;
        }
    }
}
