namespace DalList;
using DO;
using DalApi;
internal class SaleImplementation:ISale
{
    public int Create(Sale item)
    { 
        Sale n = item with { SaleId = DataSource.Config.GetSaleId() };
        DataSource.Sales.Add(n);
        return n.SaleId;
    }
    
    public void Delete(int id)
    {
        var d = from s in DataSource.Sales
                where s.SaleId == id
                select s;
        if (d.Any())
            DataSource.Sales.Remove(d.First());
        else
            throw new Dal_Dont_Faund_EntitysId_Exception("מבצע לא קיים");

        //foreach (Sale e in DataSource.Sales)
        //{
        //    if (e.SaleId == id)
        //    {
        //        DataSource.Sales.Remove(e);
        //        return;
        //    }
        //}
        //throw new Dont_Found_Id_Exception("מבצע לא קיים");
    }

    public Sale? Read(Func<Sale, bool> filter)
    {
        var d = from s in DataSource.Sales
                where filter(s)
                select s;
        if (d.Any())
            return d.FirstOrDefault();
        else
            throw new Dal_Dont_Faund_EntitysId_Exception("מבצע לא קיים לקריאה");
    }

    public Sale? Read(int id)
    {
        foreach (Sale e in DataSource.Sales)
        {
            if (e.SaleId == id)
                return e;
        }
        throw new Dont_Found_Id_Exception("מוצר לא קיים לקריאה");

    }


    public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
    {
        if (filter == null)
        {
            var b = from s in DataSource.Sales
                    select s;
            return b.ToList();
        }

        var d = from s in DataSource.Sales
                where filter(s)
                select s;
        return d.ToList();
    }

    public void UpDate(Sale item)
    {
        Delete(item.SaleId);
        DataSource.Sales.Add(item);
    }
}
