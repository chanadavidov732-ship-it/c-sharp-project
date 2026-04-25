using DO;
using DalApi;
using System.Xml.Serialization;
namespace Dal;

internal class ProductImplementation : IProduct
{
    const string filePath = @"xml\products.xml";
    XmlSerializer ProductSerializer = new XmlSerializer(typeof(List<Product?>));
    internal static List<Product?> Products = new List<Product>();

    public void deSerializeble()
    {
        using (StreamReader sr = new StreamReader(filePath))
        {
            Products = ProductSerializer.Deserialize(sr) as List<Product?>;
        }
    }
    public void serializeble()
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            ProductSerializer.Serialize(sw, Products);
        }
    }

    public int Create(Product item)
    {
        deSerializeble();
        Product n = item with { ProductId = Config.ProductNum };
        Products.Add(n);
        serializeble();
        return n.ProductId;
    }
    public void Delete(int id)
    {
        deSerializeble();
        var d = from p in Products
                where p.ProductId == id
                select p;

        if (d.Any())
        {
            Products.Remove(d.First());
            serializeble();
        }
        else
            throw new Dal_Dont_Faund_EntitysId_Exception("מוצר לא קיים");
    }
    public Product? Read(Func<Product, bool> filter)
    {
        deSerializeble();
        var d = from p in Products
                where filter(p)
                select p;

        if (d.Any())
            return d.FirstOrDefault();
        else
            throw new Dal_Dont_Faund_EntitysId_Exception("מוצר לא קיים לקריאה");
    }
    public Product? Read(int id)
    {
        deSerializeble();
        foreach (Product e in Products)
        {
            if (e.ProductId == id)
                return e;
        }
        throw new Exception("מוצר לא קיים לקריאה");
    }
    public List<Product> ReadAll(Func<Product, bool>? filter = null)
    {
        deSerializeble();
        if (filter == null)
            return Products.ToList();

        var d = from p in Products
                where filter(p)
                select p;
        return d.ToList();
    }
    public void UpDate(Product item)
    {
        deSerializeble();
        Delete(item.ProductId);
        Products.Add(item);
        serializeble();
    }
}
