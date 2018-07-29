using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ContactInformation.Models
{
    public class ContactModel
    {
        public Int32 Id { get; set; }
        [Required(ErrorMessage="Please fill First Name")]
        [Display(Name="First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Please fill Last Name")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Please fill Contact Number")]
        [Display(Name = "Contact Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage="Invalid Mobile Number")]
        public String MobileNumber { get; set; }

        [Required(ErrorMessage = "Please fill Email Address")]
        [EmailAddress(ErrorMessage="Invalid Email")]
        [Display(Name = "Email")]
        public String EmailAddress { get; set; }

       // [Required(ErrorMessage = "Please fill Status")]
        [Display(Name = "Status")]
        public string EmpStatus { get; set; }

        public string Task { get; set; }
        public List<ContactModel> lstContacts { get; set; }
    }
}