using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Customer
    {
        public int CustomerId{ get; set; }
        public string CustomerName { get; set; }
        public string CustomerAdress { get; set; }
        public string CustomerPhone { get; set; }
        public DateTime CustomerDateJoin { get; set; }
        public Customer(int CustomerId, string CustomerName, string CustomerAdress, string CustomerPhone, DateTime CustomerDateJoin)
        {
            this.CustomerId = CustomerId;
            this.CustomerName = CustomerName;
            this.CustomerAdress = CustomerAdress;
            this.CustomerPhone = CustomerPhone;
            this.CustomerDateJoin = CustomerDateJoin;
        }
    }
}
