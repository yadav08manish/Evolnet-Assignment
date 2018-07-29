using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using ContactEntites;
namespace DLContacts
{
    //This is Concrete Class
    public class DLDetails:IDLDetailOperations 
    {
         
        /// <summary>
        /// Get Contact Details
        /// </summary>
        /// <returns></returns>
        public DataTable GetContactDetails()
        {
            DataTable dt=new DataTable();
            try
            {
                DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.ConnectionStringLocal, CommandType.StoredProcedure, "SpGetDetails");
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                else
                {
                    dt = null;
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Save , Update Contact Detail
        /// </summary>
        /// <param name="contactModel"></param>
        /// <returns></returns>
        public int PostContactDetails(ContactEntites.ContactModel contactModel)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] parmList ={
                                             new SqlParameter("@Id",contactModel.Id),
                                            new SqlParameter("@FirstName",contactModel.FirstName),
                                            new SqlParameter("@LastName",contactModel.LastName),
                                            new SqlParameter("@EmailAddress",contactModel.EmailAddress),
                                            new SqlParameter("@MobileNumber",contactModel.MobileNumber),
                                            new SqlParameter("@EmpStatus",contactModel.EmpStatus),
                                            new SqlParameter("@Task",contactModel.Task),
                                           
                                           
                                        };
                int ContactId = 0;
                ContactId =Convert.ToInt32( SQLHelper.ExecuteScalar(SQLHelper.ConnectionStringLocal, CommandType.StoredProcedure, "SpSaveDetails", parmList));
                return ContactId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteContact(int Id)
        {
            try
            {
                SqlParameter[] parmList ={
                                             new SqlParameter("@Id",Id),              
                                        };
                int ContactId = 0;
                ContactId = Convert.ToInt32(SQLHelper.ExecuteScalar(SQLHelper.ConnectionStringLocal, CommandType.StoredProcedure, "SpDeleteDetails", parmList));
                return ContactId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
