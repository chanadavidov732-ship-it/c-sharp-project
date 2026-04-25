using DO;
using DalApi;
using System.Xml.Serialization;
namespace Dal;

internal class CustomerImplementation : ICustomer
{
    const string filePath = @"xml\customers.xml";
    XmlSerializer CustomerSerializer = new XmlSerializer(typeof(List<Customer?>));
    internal static List<Customer?> Customers = new List<Customer>();

    public void deSerializeble()
    {
        using (StreamReader sr = new StreamReader(filePath))
        {
            Customers = CustomerSerializer.Deserialize(sr) as List<Customer?>;
        }
    }
    public void serializeble()
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            CustomerSerializer.Serialize(sw, Customers);
        }
    }

    public int Create(Customer item)
    {
        deSerializeble();   
        var d = from c in Customers
                where c.CustomerId == item.CustomerId
                select c;
        if (d.Any())
            throw new Dal_Entitys_Already_Exist_Exception("לקוח כבר קיים");
        else
        {
            Customers.Add(item);
            serializeble(); 
        }
        return item.CustomerId;
    }
    public void Delete(int id)
    {
        deSerializeble();
        var d = from c in Customers
                where c.CustomerId == id
                select c;

        if (d.Any())
        {
            Customers.Remove(d.First());
            serializeble();
        }
        else
            throw new Dal_Dont_Faund_EntitysId_Exception("לקוח לא קיים");

    }
    public Customer? Read(int id)
    {
        deSerializeble();   
        foreach (Customer e in Customers)
        {
            if (e.CustomerId == id)
                return e;
        }
        throw new Dont_Found_Id_Exception("לקוח לא קיים לקריאה");

    }
    public Customer? Read(Func<Customer, bool> filter)
    {
        deSerializeble();
        var d = from c in Customers
                where filter(c)
                select c;
        if (d.Any())
            return d.FirstOrDefault();
        else
            throw new Dal_Dont_Faund_EntitysId_Exception("לקוח לא קיים לקריאה");
    }
    public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
    {
        deSerializeble();
        if (filter == null)
            return Customers.ToList();

        var d = from c in Customers
                where filter(c)
                select c;
        return d.ToList();
    }
    public void UpDate(Customer item)
    {
        deSerializeble();   
        Delete(item.CustomerId);
        Customers.Add(item);
        serializeble();
    }
}