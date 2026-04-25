namespace DalList;
using DO;
static internal  class DataSource
{
    internal static List<Customer?> Customers = new List<Customer>();
    internal static List<Product?> Products = new List<Product>();
    internal static List<Sale?> Sales = new List<Sale>();
    internal static class Config
    {
        internal const int SaleIdStart =1;
        internal const int ProductIdStart = 1000;

        private static int SaleId1 = SaleIdStart;
        private static int ProductId1 = ProductIdStart;

        public static int GetSaleId()
        {return SaleId1++;}

        public static int GetProductId()
        { return ProductId1++; }
    }
}