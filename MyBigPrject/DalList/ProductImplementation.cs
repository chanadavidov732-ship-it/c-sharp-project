namespace DalList;
using DO;
using DalApi;

internal class ProductImplementation : IProduct
{
    public int Create(Product item)
    {
        Product n = item with { ProductId = DataSource.Config.GetProductId() };
        DataSource.Products.Add(n);
        return n.ProductId;
    }
    
    public void Delete(int id)
    {
        var d = from p in DataSource.Products
                where p.ProductId == id
                select p;

        if(d.Any())
            DataSource.Products.Remove(d.First());
        else
            throw new Dal_Dont_Faund_EntitysId_Exception("מוצר לא קיים");
    }

    public Product? Read(Func<Product, bool> filter)
    {
        var d = from p in DataSource.Products
                where filter(p)
                select p;

        if (d.Any())
            return d.FirstOrDefault();
        else
            throw new Dal_Dont_Faund_EntitysId_Exception("מוצר לא קיים לקריאה");
    }
    public Product? Read(int id)
    {
        foreach (Product e in DataSource.Products)
        {
            if (e.ProductId == id)
                return e;
        }
        throw new Exception("מוצר לא קיים לקריאה");
    }
   
      

    public List<Product> ReadAll(Func<Product, bool>? filter = null)
    {
        if (filter == null)
        {
            var b = from p in DataSource.Products
                    select p;
            return b.ToList();
        }

        var d = from p in DataSource.Products
                where filter(p)
                select p;
        return d.ToList();
    }

    public void UpDate(Product item)
    {
        Delete(item.ProductId);
        DataSource.Products.Add(item);
    }

 
}