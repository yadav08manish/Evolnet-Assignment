using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace BLContacts
{
    //Interface to implement Factory Pattern
   public interface IDetailsOperation
    {

       DataTable GetContactDetails();
       int PostContactDetails(ContactEntites.ContactModel contactModel);
       int DeleteContact(int id);
    }
}
