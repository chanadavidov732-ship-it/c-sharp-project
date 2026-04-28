using BlApi;
using BO;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    internal class CustomerImplementation : ICustomer
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public int Create(BO.Customer item)
        {
            return _dal.Customer.Create(Tools.ConversBoCustomerToDoCustomer(item));

        }
        public void Delete(int id)
        {
            _dal.Customer.Delete(id);

        }

        public BO.Customer? Read(Func<BO.Customer, bool> filter)
        {
            
           return Tools.ConversDoCustomerToBoCustomer(_dal.Customer.Read(filter));
        }

        public BO.Customer? Read(int id)
        {
            return Tools.ConversDoCustomerToBoCustomer(_dal.Customer.Read(id));

        }

        public List<BO.Customer> ReadAll(Func<BO.Customer, bool>? filter = null)
        {
            List<BO.Customer> l=new List<BO.Customer>();
            foreach(DO.Customer item in _dal.Customer.ReadAll(filter))
            {
                l.Add(Tools.ConversDoCustomerToBoCustomer(item));
            }
            return l;
        }

        public void UpDate(BO.Customer item)
        {
            _dal.Customer.UpDate(Tools.ConversBoCustomerToDoCustomer(item));
        }
        public bool IsExsits(BO.Customer item)
        {
            try { 
                _dal.Customer.Read(Tools.ConversBoCustomerToDoCustomer(item).CustomerId); 
            }
            catch(Exception e) 
            {
                return false;
            }

            return true;
        }
    }
}
