using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    internal static class Tools
    {
        //בא לי להבין
        public static string ToStringProperty<T>(T obj)
        {
            if (obj == null) return "null";

            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            List<string> propertyStrings = new List<string>();

            foreach (var property in properties)
            {
                object value = property.GetValue(obj);
                if (value is IEnumerable)
                {
                    List<string> listItems = new List<string>();
                    foreach (var item in (IEnumerable)value)
                    {
                        listItems.Add(item?.ToString());
                    }
                    propertyStrings.Add($"{property.Name}: [{string.Join(", ", listItems)}]");
                }
                else
                {
                    propertyStrings.Add($"{property.Name}: {value?.ToString()}");
                }
            }

            return string.Join(", ", propertyStrings);
        }


        public static DO.Product ConvertBoProductToDoProduct(this BO.Product product)
        {
            return new DO.Product(product.ProductId, product.ProductName,(DO.Category)product.ProductCategory,
                product.ProductQuntity, product.ProductPrice,product.ProductDateCreat);
        }

        public static BO.Product ConversDoProductToBoProduct(this DO.Product product)
        {
            return new BO.Product(product.ProductId, product.ProductName, (BO.Category)product.ProductCategory,
                product.ProductQuntity, product.ProductPrice, product.ProductDateCreat);
        }

        //public static BO.Product ConversDoProductToBoProductWithId(this DO.Product product)
        //{
        //    return new BO.Product(product.ProductId, product.ProductName, (BO.Category)product.ProductCategory,
        //        product.ProductQuntity, product.ProductPrice, product.ProductDateCreat);
        //}


        public static DO.Customer ConversBoCustomerToDoCustomer(this BO.Customer customer)
        {
            return new DO.Customer(customer.CustomerId,customer.CustomerName,customer.CustomerAdress,customer.CustomerPhone,customer.CustomerDateJoin);
        }

        public static BO.Customer ConversDoCustomerToBoCustomer(this DO.Customer customer)
        {
            return new BO.Customer(customer.CustomerId, customer.CustomerName, customer.CustomerAdress, customer.CustomerPhone, customer.CustomerDateJoin);
        }

        public static DO.Sale ConversBoSaleToDoSale(this BO.Sale sale)
        {
            return new DO.Sale(sale.SaleId, sale.ProductId, sale.Count, sale.Price, sale.ForCustomerMember, sale.SaleDateStart, sale.SaleDateEnd);
        }

        public static BO.Sale ConversDoSaleToBoSale(this DO.Sale sale)
        {
            return new BO.Sale(sale.SaleId,sale.ProductId,sale.Count,sale.Price,sale.ForCustomerMember,sale.SaleDateStart,sale.SaleDateEnd);
        }
    }
}
