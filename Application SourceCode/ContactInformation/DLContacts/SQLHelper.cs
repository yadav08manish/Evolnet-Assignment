using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Linq;

namespace DLContacts
{
   public abstract class SQLHelper
    {
       public static readonly string ConnectionStringLocal = ConfigurationManager.ConnectionStrings["ConCont"].ConnectionString;
       public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameter)
       {
           SqlCommand cmd = new SqlCommand();
           cmd.CommandTimeout = 0;
           SqlConnection conn =new SqlConnection(connectionString);

           PrepareCommand(cmd, conn, null, commandType, commandText, commandParameter);
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           da.Fill(ds);
           cmd.Parameters.Clear();
           return ds;
       }

       private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
       {
           if (conn.State != ConnectionState.Open)
               conn.Open();

           cmd.Connection = conn;
           cmd.CommandText = cmdText;

           if(trans !=null)
           cmd.Transaction=trans;

           cmd.CommandType = cmdType;

           if (cmdParms != null)
           {
               foreach (SqlParameter parm in cmdParms)
                   cmd.Parameters.Add(parm);
           }
       }

       public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
       {
           SqlCommand cmd = new SqlCommand();
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
               object val = cmd.ExecuteScalar();
               cmd.Parameters.Clear();
               return val;
           }
       }
    }

    
}
