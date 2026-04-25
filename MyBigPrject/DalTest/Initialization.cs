
namespace DalTest;
using DalApi;
using DO;
using DalList;
using System.Data.Common;

public static class Initialization
{
    private static IDal? S_Dal;

    private static void CreateCustomers() 
    {
        S_Dal.Customer.Create(new Customer(123,"chanaD","modin.Netish.16","0533188732",DateTime.Now));
        S_Dal.Customer.Create(new Customer(234, "chanaS", "modin.Aviz.20", "0555555555", DateTime.Now));
    }
    private static void CreateProducts()
    {
        S_Dal.Product.Create(new Product(0,"SnikersWomanBlack",Category.WOMAN,100,350,DateTime.Now));
        S_Dal.Product.Create(new Product(0, "SnikersWomanWhite", Category.WOMAN, 300, 350, DateTime.Now));
    }
    private static void CreateSales()
    {
        S_Dal.Sale.Create(new Sale(0,0,2,500,false,DateTime.Now, DateTime.Now.AddMonths(1)));
        S_Dal.Sale.Create(new Sale(0, 0, 3, 600, false, DateTime.Now, DateTime.Now.AddMonths(1)));
    }
    public static void Initialize()
    {
        S_Dal= DalApi.Factory.Get;
        CreateCustomers();
        CreateProducts();
        CreateSales();
    }
}