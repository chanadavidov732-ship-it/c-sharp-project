using DalApi;
using DO;
//using DalList;
//using DalXml;

namespace DalTest
{
    internal class Program
    {
        private static IDal? S_Dal = DalApi.Factory.Get;
        // private static IDal? S_Dal = DalXml.DalXml.Instance;

        private static int ShowSubMenu()
        { 
            int num;
            Console.WriteLine("for customer press 1");
            Console.WriteLine("for product press 2");
            Console.WriteLine("for sale press 3");
            Console.WriteLine("Exite 4");
            num = int.Parse(Console.ReadLine());

            while (num < 0&&num>5)
            {
                Console.WriteLine("press again");
                num = int.Parse(Console.ReadLine());
            }
            return num;
        }
        private static void CreateCustomer()
        {
            int CustomerId;
            string CustomerName;
            string CustomerAdress;
            string CustomerPhone;
            Console.WriteLine("enter CustomerId");
            CustomerId= int.Parse(Console.ReadLine());
            Console.WriteLine("enter CustomerName");
            CustomerName = Console.ReadLine();
            Console.WriteLine("enter CustomerAdress");
            CustomerAdress = Console.ReadLine();
            Console.WriteLine("enter CustomerPhone");
            CustomerPhone = Console.ReadLine();
            Console.WriteLine(S_Dal.Customer.Create(new Customer(CustomerId, CustomerName, CustomerAdress, CustomerPhone,DateTime.Now)));
        }
        private static void CreateProduct()
        {
            string ProductName;
            Category ProductCategory=Category.WOMAN;
            int ProductQuntity;
            double ProductPrice;
            int n;
            Console.WriteLine("enter ProductName");
            ProductName = Console.ReadLine();
            Console.WriteLine("enter ProductQuntity");
            ProductQuntity=int.Parse(Console.ReadLine());
            Console.WriteLine("enter ProductPrice");
            ProductPrice= double.Parse(Console.ReadLine());
            Console.WriteLine("enter ProductCategory\n for Category WOMAN press1 MAN press2 CHILDREN press3 BABY press4 ");
            n= int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    ProductCategory=Category.WOMAN;
                    break;
                case 2:
                    ProductCategory = Category.MAN;
                    break;
                case 3:
                    ProductCategory = Category.CHILDREN;
                    break;
                case 4:
                    ProductCategory = Category.BABY;
                    break;
            }
            S_Dal.Product.Create(new Product(0, ProductName,ProductCategory,ProductQuntity,ProductPrice, DateTime.Now));
        }
        private static void CreateSale()
        {
            int ProductId;
            int Count;
            int Price;
            bool ForCustomerMember;
            DateTime SaleDateEnd;

            Console.WriteLine("enter ProductId");
            ProductId = int.Parse(Console.ReadLine());
            Console.WriteLine("enter Count");
            Count = int.Parse(Console.ReadLine());
            Console.WriteLine("enter Price");
            Price = int.Parse(Console.ReadLine());
            Console.WriteLine("enter ForCustomerMember");
            ForCustomerMember = bool.Parse(Console.ReadLine());
            Console.WriteLine("enter SaleDateEnd");
            SaleDateEnd = DateTime.Parse(Console.ReadLine());
            S_Dal.Sale.Create(new Sale(0,ProductId, Count, Price, ForCustomerMember, DateTime.Now, SaleDateEnd));
        }
        private static void ReadCustomer()
        {
            Console.WriteLine("enter CustomerId");
            int CustomerId= int.Parse(Console.ReadLine());
            Customer ne= S_Dal.Customer.Read(CustomerId);

            Console.WriteLine("CustomerId={0}\n CustomerName={1}\n CustomerAdress={2}\n CustomerPhone={3}\n CustomerDateJoin={4}\n",
                                ne.CustomerId,ne.CustomerName,ne.CustomerAdress,ne.CustomerPhone,ne.CustomerDateJoin);
        }
        private static void ReadProduct()
        {
            
            Console.WriteLine("enter ProductId");
            int ProductId = int.Parse(Console.ReadLine());
            Product ne = S_Dal.Product.Read(ProductId);
            Console.WriteLine("ProductId={0}\n ProductName={1}\n ProductCategory={2}\n ProductQuntity={3}\n ProductPrice={4}\n ProductDateCreat={5}\n",
                                ne.ProductId, ne.ProductName, ne.ProductCategory, ne.ProductQuntity, ne.ProductPrice,ne.ProductDateCreat);

        }
        private static void ReadSale()
        {
            Console.WriteLine("enter SaleId");
            int SaleId = int.Parse(Console.ReadLine());
            Sale ne = S_Dal.Sale.Read(SaleId);
            Console.WriteLine("SaleId={0}\n ProductId={1}\n Count={2}\n Price={3}\n ForCustomerMember={4}\n SaleDateStart={5}\n SaleDateEnd={6}",
                                ne.SaleId, ne.ProductId, ne.Count, ne.Price, ne.ForCustomerMember, ne.SaleDateStart,ne.SaleDateEnd);

        }
        private static void UpdateCustomer()
        {
            int CustomerId;
            string CustomerName;
            string CustomerAdress;
            string CustomerPhone;
            DateTime CustomerDateJoin;
            Console.WriteLine("enter CustomerId");
            CustomerId = int.Parse(Console.ReadLine());
            Console.WriteLine("enter CustomerName");
            CustomerName = Console.ReadLine();
            Console.WriteLine("enter CustomerAdress");
            CustomerAdress = Console.ReadLine();
            Console.WriteLine("enter CustomerPhone");
            CustomerPhone = Console.ReadLine();
            CustomerDateJoin = DateTime.Parse(Console.ReadLine());
            S_Dal.Customer.UpDate(new Customer(CustomerId, CustomerName, CustomerAdress, CustomerPhone, CustomerDateJoin));
        }
        private static void UpdateProduct()
        {
            string ProductName;
            Category ProductCategory = Category.WOMAN;
            int ProductQuntity;
            double ProductPrice;
            int n;
            Console.WriteLine("enter ProductName");
            ProductName = Console.ReadLine();
            Console.WriteLine("enter ProductQuntity");
            ProductQuntity = int.Parse(Console.ReadLine());
            Console.WriteLine("enter ProductPrice");
            ProductPrice = double.Parse(Console.ReadLine());
            Console.WriteLine("enter ProductCategory\n for Category WOMAN press1 MAN press2 CHILDREN press3 BABY press4 ");
            n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    ProductCategory = Category.WOMAN;
                    break;
                case 2:
                    ProductCategory = Category.MAN;
                    break;
                case 3:
                    ProductCategory = Category.CHILDREN;
                    break;
                case 4:
                    ProductCategory = Category.BABY;
                    break;
            }
            S_Dal.Product.UpDate(new Product(0, ProductName, ProductCategory, ProductQuntity, ProductPrice, DateTime.Now));
        }
        private static void UpdateSale()
        {
            int ProductId;
            int Count;
            int Price;
            bool ForCustomerMember;
            DateTime SaleDateEnd;
            Console.WriteLine("enter ProductId");
            ProductId = int.Parse(Console.ReadLine());
            Console.WriteLine("enter Count");
            Count = int.Parse(Console.ReadLine());
            Console.WriteLine("enter Price");
            Price = int.Parse(Console.ReadLine());
            Console.WriteLine("enter ForCustomerMember");
            ForCustomerMember = bool.Parse(Console.ReadLine());
            Console.WriteLine("enter SaleDateEnd");
            SaleDateEnd = DateTime.Parse(Console.ReadLine());
            S_Dal.Sale.UpDate(new Sale(0, ProductId, Count, Price, ForCustomerMember, DateTime.Now, SaleDateEnd));
        }
        private static void DeleteCustomer()
        {
            Console.WriteLine("enter CustomerId");
            int CustomerId = int.Parse(Console.ReadLine());
            S_Dal.Customer.Delete(CustomerId);
        }
        private static void DeleteProduct()
        {
            Console.WriteLine("enter ProductId");
            int ProductId = int.Parse(Console.ReadLine());
            S_Dal.Product.Delete(ProductId);
        }
        private static void DeleteSale()
        {
            Console.WriteLine("enter SaleId");
            int SaleId = int.Parse(Console.ReadLine());
            S_Dal.Sale.Delete(SaleId);
        }
        private static void ReadAllCustomer()
        {
            List<Customer> l=S_Dal.Customer.ReadAll();
            for(int i = 0; i < l.Count; i++)
            {
                Customer ne = S_Dal.Customer.Read(l[i].CustomerId);
                Console.WriteLine("CustomerId={0}\n CustomerName={1}\n CustomerAdress={2}\n CustomerPhone={3}\n CustomerDateJoin={4}\n",
                                    ne.CustomerId, ne.CustomerName, ne.CustomerAdress, ne.CustomerPhone, ne.CustomerDateJoin);
            }
        }
        private static void ReadAllProduct()
        {
            List<Product> l= S_Dal.Product.ReadAll();
            for (int i = 0; i < l.Count; i++)
            {
                Product ne = S_Dal.Product.Read(l[i].ProductId);
                Console.WriteLine("ProductId={0}\n ProductName={1}\n ProductCategory={2}\n ProductQuntity={3}\n ProductPrice={4}\n ProductDateCreat={5}\n",
                                    ne.ProductId, ne.ProductName, ne.ProductCategory, ne.ProductQuntity, ne.ProductPrice, ne.ProductDateCreat);
            }
        }
        private static void ReadAllSale()
        {
            List<Sale> l = S_Dal.Sale.ReadAll();
            for (int i = 0; i < l.Count; i++)
            {
                Sale ne = S_Dal.Sale.Read(l[i].SaleId);
                Console.WriteLine("SaleId={0}\n ProductId={1}\n Count={2}\n Price={3}\n ForCustomerMember={4}\n SaleDateStart={5}\n SaleDateEnd={6}",
                                    ne.SaleId, ne.ProductId, ne.Count, ne.Price, ne.ForCustomerMember, ne.SaleDateStart, ne.SaleDateEnd);

            }

        }
        private static void ShowMainMenu()
        {
            Console.WriteLine("Hello menu");
            Console.WriteLine("for create press 1");
            Console.WriteLine("for read press 2");
            Console.WriteLine("for readAll press 3");
            Console.WriteLine("for update press 4");
            Console.WriteLine("for delete press 5");
            Console.WriteLine("any key to exit");
            int num=int.Parse(Console.ReadLine());
            int num2;
            switch(num) {
                //create
                case 1:
                    num2= ShowSubMenu();
                    switch (num2)
                    {
                        case 1:
                            CreateCustomer();
                              break;
                        case 2:
                            CreateProduct();
                            break;
                        case 3:
                            CreateSale();
                            break;
                        case 4: 
                            ShowMainMenu(); 
                            break;
                    }
                    break;
                //read
                case 2:
                    num2 = ShowSubMenu();
                    switch (num2)
                    {
                        case 1:
                            ReadCustomer();
                            break;
                        case 2:
                            ReadProduct();
                            break;
                        case 3:
                            ReadSale();
                            break;
                        case 4:
                            ShowMainMenu();
                            break;
                    }
                    break;
                //readAll
                case 3:
                    num2 = ShowSubMenu();
                    switch (num2)
                    {
                        case 1:
                            ReadAllCustomer();
                            break;
                        case 2:
                            ReadAllProduct();
                            break;
                        case 3:
                            ReadAllSale();
                            break;
                        case 4:
                            ShowMainMenu();
                            break;
                    }
                    break;
                //update
                case 4:
                    num2 = ShowSubMenu();
                    switch (num2)
                    {
                        case 1:
                            UpdateCustomer();
                            break;
                        case 2:
                            UpdateProduct();
                            break;
                        case 3:
                            UpdateSale();
                            break;
                        case 4:
                            ShowMainMenu();
                            break;
                    }
                    break;
                //Delete
                case 5:
                    num2 = ShowSubMenu();
                    switch (num2)
                    {
                        case 1:
                            DeleteCustomer();
                            break;
                        case 2:
                            DeleteProduct();
                            break;
                        case 3:
                            DeleteSale();
                            break;
                        case 4:
                            ShowMainMenu();
                            break;
                    }
                    break;
                //exit
                default:
                    return;
            }
        }
        static void Main(string[] args)
        {
            try {
                Initialization.Initialize();
                ShowMainMenu();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message);}
        }
    }
}
