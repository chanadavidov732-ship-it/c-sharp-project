using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Customer(int CustomerId, string CustomerName, string CustomerAdress, string CustomerPhone, DateTime CustomerDateJoin)
    {
        public Customer() : this(-1, "", "", "", DateTime.Now) { }
    }

}
