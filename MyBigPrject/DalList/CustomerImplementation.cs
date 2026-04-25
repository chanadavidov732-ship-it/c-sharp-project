namespace DalList;
using DO;
using DalApi;


internal class CustomerImplementation : ICustomer
{
    public int Create(Customer item)
    {
        var d = from c in DataSource.Customers
                where c.CustomerId == item.CustomerId
                select c;
        if (d.Any())
            throw new Dal_Entitys_Already_Exist_Exception("לקוח כבר קיים");
        else
            DataSource.Customers.Add(item);
        return item.CustomerId;

    }
    
    public void Delete(int id)
    {
        var d = from c in DataSource.Customers
                where c.CustomerId == id
                select c;

        if (d.Any())
            DataSource.Customers.Remove(d.First());
        else
            throw new Dal_Dont_Faund_EntitysId_Exception("לקוח לא קיים");

    }

    public Customer? Read(Func<Customer, bool> filter)
    {
        var d = from c in DataSource.Customers
                where filter( c)
                select c;
        if (d.Any())
            return d.FirstOrDefault();
        else
            throw new Dal_Dont_Faund_EntitysId_Exception("לקוח לא קיים לקריאה");
    }

    public Customer? Read(int id)
    {
        foreach (Customer e in DataSource.Customers)
        {
            if (e.CustomerId == id)
                return e;
        }
        throw new Dont_Found_Id_Exception("לקוח לא קיים לקריאה");

    }

    public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
    {
        if(filter == null)
        {
            var b = from c in DataSource.Customers
                    where filter(c)
                    select c;
            return b.ToList();
        }

        var d = from c in DataSource.Customers
                where filter(c)
                select c;
        return d.ToList();
    }

    public void UpDate(Customer item)
    {
        Delete(item.CustomerId);
        DataSource.Customers.Add(item);
    }
}
