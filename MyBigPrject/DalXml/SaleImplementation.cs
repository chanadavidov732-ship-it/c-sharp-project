namespace Dal;
using DalApi;
using DO;
using System.Xml.Serialization;

internal class SaleImplementation : ISale
{

    const string filePath = @"xml\sales.xml";
    XmlSerializer SaleSerializer = new XmlSerializer(typeof(List<Sale?>));
    internal static List<Sale?> Sales = new List<Sale>();

    public void deSerializeble()
    {
        using (StreamReader sr = new StreamReader(filePath))
        {
            Sales = SaleSerializer.Deserialize(sr) as List<Sale?>;
        }
    }
    public void serializeble()
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            SaleSerializer.Serialize(sw, Sales);
        }
    }
    
    public int Create(Sale item)
    {
        deSerializeble();
        Sale n = item with { SaleId = Config.SaleNum };
        Sales.Add(n);
        serializeble();
        return n.SaleId;
    }
    public void Delete(int id)
    {
        deSerializeble();
        var d = from s in Sales
                where s.SaleId == id
                select s;
        if (d.Any())
        {
            Sales.Remove(d.First());
            serializeble();

        }
        else
            throw new Dal_Dont_Faund_EntitysId_Exception("מבצע לא קיים");
    }
    public Sale? Read(Func<Sale, bool> filter)
    {
        deSerializeble();
        var d = from s in Sales
                where filter(s)
                select s;
        if (d.Any())
            return d.FirstOrDefault();
        else
            throw new Dal_Dont_Faund_EntitysId_Exception("מבצע לא קיים לקריאה");
    }
    public Sale? Read(int id)
    {
        deSerializeble();
        foreach (Sale e in Sales)
        {
            if (e.SaleId == id)
                return e;
        }
        throw new Dont_Found_Id_Exception("מוצר לא קיים לקריאה");

    }
    public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
    {
        deSerializeble();
        if (filter == null)
        {
            var b = from s in Sales
                    select s;
            return b.ToList();
        }

        var d = from s in Sales
                where filter(s)
                select s;
        return d.ToList();
    }
    public void UpDate(Sale item)
    {
        deSerializeble();
        Delete(item.SaleId);
        Sales.Add(item);
        serializeble();
    }
}


