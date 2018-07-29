using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyAPI.Models;
using System.Data;

 

namespace MyAPI.Controllers
{
    public class ContactDetailsController : ApiController
    {
        // Here we are using Interface to create instance of Concrete DL Class
        BLContacts.IDetailsOperation concObj = BLContacts.DetailsOperationFactory.GetInstance();// objFactory.GetInstance();
        
        /// <summary>
        /// Get the saved Contact Details
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetDetails()
        {
            try
            {
                DataTable dt = new DataTable();

                dt = concObj.GetContactDetails();
                return Ok(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insert the New and Update the Existing Contact Details
        /// </summary>
        /// <param name="contactModel"></param>
        /// <returns></returns>
        public IHttpActionResult PostDetails([FromBody] ContactEntites.ContactModel contactModel)
        {
           
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");
                
                int contactId = concObj.PostContactDetails(contactModel);

                return Ok(contactId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}