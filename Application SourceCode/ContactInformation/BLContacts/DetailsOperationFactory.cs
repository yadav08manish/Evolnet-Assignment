using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLContacts
{
    //Factory class which is responsible to Create Inatance
   public static class DetailsOperationFactory
    {
       /// <summary>
       /// Responsible to refrencing the instace of concrete class to Interface
       /// </summary>
       /// <returns></returns>
        public static IDetailsOperation GetInstance()
        {
            IDetailsOperation objDetail = null;
            objDetail = new BLContacts.BLDetails();
            return objDetail;
        }
    }
}
