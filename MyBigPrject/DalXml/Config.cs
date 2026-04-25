using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dal
{
    internal static class Config
    {
        const string filePath = @"xml\data-config.xml";
        private static string DATA_CONFIG = "data_config";
        private const string PRODUCT_NUM = "ProductNum";
        private const string SALE_NUM = "SaleNum";
        private const string CUSTOMER_NUM = "CustomerNum";

        public static int ProductNum { 
            get
            {
                XElement xelementConfig = XElement.Load(@"xml\data-config.xml");
                int id = int.Parse(xelementConfig.Element(PRODUCT_NUM).Value) + 1;
                xelementConfig.Element(PRODUCT_NUM).SetValue(id);
                xelementConfig.Save(filePath);
                return id;
            }  
        }
        public static int SaleNum { get
            {
                XElement xelementConfig = XElement.Load(@"xml\data-config.xml");
                int id = int.Parse(xelementConfig.Element(SALE_NUM).Value) + 1;
                xelementConfig.Element(SALE_NUM).SetValue(id);
                xelementConfig.Save(filePath);
                return id;
            } 
        }
        //בעקרון לא צריך כי מכנחס לבד ID
        //public static int CustomerNum { get
        //    {
        //        XElement xelementConfig = XElement.Load(@"xml\data-config.xml");
        //        int id = int.Parse(xelementConfig.Element(CUSTOMER_NUM).Value) + 1;
        //        xelementConfig.Element(CUSTOMER_NUM).SetValue(id);
        //        xelementConfig.Save(filePath);
        //        return id;
        //    }
        //}
        
        //מה שעשינו לפני הGET אותו הדבר רק עם PROPERTY 
        //static XElement xelementConfig = new XElement(DATA_CONFIG);

        //public static int GetProductNum()
        //{
        //    xelementConfig.Element(PRODUCT_NUM).SetValue(
        //        int.Parse(xelementConfig.Element(PRODUCT_NUM).Value) + 1);
        //    xelementConfig.Save(filePath);
        //    return int.Parse(xelementConfig.Element(PRODUCT_NUM).Value);
        //}
        //public static int GetSaleNum()
        //{
        //    xelementConfig.Element(SALE_NUM).SetValue(
        //        int.Parse(xelementConfig.Element(SALE_NUM).Value) + 1);
        //    xelementConfig.Save(filePath);
        //    return int.Parse(xelementConfig.Element(SALE_NUM).Value);
        //}
        //public static int GetCustomerNum()
        //{
        //    xelementConfig.Element(CUSTOMER_NUM).SetValue(
        //        int.Parse(xelementConfig.Element(CUSTOMER_NUM).Value) + 1);
        //    xelementConfig.Save(filePath);
        //    return int.Parse(xelementConfig.Element(CUSTOMER_NUM).Value);
        //}

    }
}
