using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLContacts
{
    //This is a Factory class which is responsible to create Instance of Concrete DL Class
   public static  class DLDetailOperationFactory
    {
       /// <summary>
        /// Responsible to refrencing the instace of concrete class to Interface
       /// </summary>
       /// <returns></returns>
       public static IDLDetailOperations GetInstace()
       {
           IDLDetailOperations objIDL = null; ;
           objIDL = new DLContacts.DLDetails();
           return objIDL;
       }
    }
}
