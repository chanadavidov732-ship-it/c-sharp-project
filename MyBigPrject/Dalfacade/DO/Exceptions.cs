using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    [Serializable]
    public class Dont_Found_Id_Exception:Exception
    {
        public Dont_Found_Id_Exception(string? message):base(message) { }
 
        public Dont_Found_Id_Exception(string? message, Exception? innerException):base(message, innerException) { }
    }

    [Serializable]
    public class Already_Exist_Id_Exception : Exception
    {
        public Already_Exist_Id_Exception(string? message) : base(message) { }

        public Already_Exist_Id_Exception(string? message, Exception? innerException) : base(message, innerException) { }
    }

    [Serializable]
    public class Dal_Dont_Faund_EntitysId_Exception : Exception
    {
        public Dal_Dont_Faund_EntitysId_Exception(string? message) : base(message) { }

        public Dal_Dont_Faund_EntitysId_Exception(string? message, Exception? innerException) : base(message, innerException) { }
    }


    [Serializable]
    public class Dal_Entitys_Already_Exist_Exception : Exception
    {
        public Dal_Entitys_Already_Exist_Exception(string? message) : base(message) { }

        public Dal_Entitys_Already_Exist_Exception(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
