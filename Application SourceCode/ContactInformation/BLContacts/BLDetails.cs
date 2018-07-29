using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DLContacts;
using ContactEntites;

namespace BLContacts
{

    // This is Concrete class 
    public class BLDetails : IDetailsOperation
    {
       // Here we are using Interface to create instance of DL concrete class.
        DLContacts.IDLDetailOperations concObj = DLContacts.DLDetailOperationFactory.GetInstace(); //objFactory.GetInstace();
        
        /// <summary>
        /// Get Contact Details
        /// </summary>
        /// <returns></returns>
        public DataTable GetContactDetails()
        {
            DataTable dt = new DataTable();

            dt = concObj.GetContactDetails();
           return dt;
        }

        /// <summary>
        /// Save, Update  Contact Details
        /// </summary>
        /// <param name="contactModel"></param>
        /// <returns></returns>
       public int PostContactDetails(ContactEntites.ContactModel contactModel)
       {

           int detailId = concObj.PostContactDetails(contactModel);
           return detailId;
       }

        public int DeleteContact(int id)
       {

           int detailId = concObj.DeleteContact(id);
           return detailId;
       }
       
    }
}
