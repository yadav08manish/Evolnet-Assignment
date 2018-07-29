using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactInformation.Models;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Text;
using Newtonsoft.Json;


namespace ContactInformation.Controllers
{
    public class ContactController : Controller
    {
        ContactModel objContactModel = new ContactModel();
        string baseURL = System.Configuration.ConfigurationManager.AppSettings["ApiUrl"];
        
        /// <summary>
        /// GET: /Contact/ Get the Saved Contact details from database
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            try
            {
                List<SelectListItem> lstEmpStatus = new List<SelectListItem>() {  
                                                                new SelectListItem {  Text = "Active", Value = "Active"  },  
                                                                new SelectListItem {  Text = "InActive", Value = "InActive"   }
                                                                         };
                ViewBag.Status = lstEmpStatus;

                List<ContactModel> students = new List<ContactModel>();
                using (var client = new HttpClient())
                {
                    
                    string url = baseURL + "api/contactdetails/";
                    client.BaseAddress = new Uri(url);
                    //HTTP GET
                    var responseTask = client.GetAsync("Contact");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = (new JavaScriptSerializer()).Deserialize<List<ContactModel>>(result.Content.ReadAsStringAsync().Result);
                        students = readTask;
                        objContactModel.lstContacts = students;
                    }
                    else 
                    {
                       
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
                return View(objContactModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///Insert, Update and Delete the Contact details
        /// </summary>
        /// <param name="objCont"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Contact(ContactModel objCont)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        string url = baseURL + "api/contactdetails/";
                        client.BaseAddress = new Uri(url);
                       
                        var stringContent = new StringContent("json", Encoding.UTF8, "application/json");
                       

                        var result = client.PostAsync(url, new StringContent(
       new JavaScriptSerializer().Serialize(objCont), Encoding.UTF8, "application/json")).Result;

                        
                        if (result.IsSuccessStatusCode)
                        {
                            
                                TempData["SuccessMessage"] = "Saved Successfully";
                                return RedirectToAction("Contact");
                            
                            
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                            return View(objCont);
                        }
                    }

                }
                else
                {

                    return View(objCont);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
             
        }



        /// <summary>
        /// To Edit the record it binds the Id to update the record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastname"></param>
        /// <param name="mobileNumber"></param>
        /// <param name="emailAddress"></param>
        /// <param name="status"></param>
        [HttpPost]
        public void SetModel(string id,string firstName,string lastname, string mobileNumber, string emailAddress, string status)
        {
            objContactModel.Id = Convert.ToInt32(id);
            
        }

        /// <summary>
        /// To Delete the Existing Contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RemoveContact(int id)
        {
            objContactModel.Id = Convert.ToInt32(id);
            objContactModel.Task = "rem";
            using (var client = new HttpClient())
            {
                string url = baseURL + "api/contactdetails/";
                client.BaseAddress = new Uri(url);
                var stringContent = new StringContent("json", Encoding.UTF8, "application/json");

                var result = client.PostAsync(url, new StringContent(
new JavaScriptSerializer().Serialize(objContactModel), Encoding.UTF8, "application/json")).Result;

                //var result = response.Re;
                if (result.IsSuccessStatusCode)
                {

                    if (objContactModel.Task == "rem")
                    {
                        TempData["SuccessMessage"] = "Deleted Successfully";
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    return View(objContactModel);
                }
            }
            
            return Json("Successfull deleted", JsonRequestBehavior.AllowGet);
        }


    }
}