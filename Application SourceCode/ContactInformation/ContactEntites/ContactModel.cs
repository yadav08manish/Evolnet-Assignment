using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactEntites
{
   public class ContactModel
    {
        public Int32 Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String MobileNumber { get; set; }
        public String EmailAddress { get; set; }
        public string EmpStatus { get; set; }
        public string Task { get; set; }
    }
}
