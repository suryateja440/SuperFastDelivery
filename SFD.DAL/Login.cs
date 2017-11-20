using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;
using System.Configuration;
using System.Web.Services;
using SFD.CommonClasses;
//using System.Web.Configuration;


namespace SFD.DAL
{
   public class Login : System.Web.UI.Page
    {
        
        string conString = ConfigurationManager.ConnectionStrings["SuperFastDelivery"].ToString();
        SqlConnection sqlCon;
        SqlCommand sqlCmd;
        SqlDataAdapter da;
        DataSet ds;
       // SFD.CommonClasses.Helper hs = Common
       
        [WebMethod(EnableSession = true)]
        public JObject LoginCheck( string userName, string PassWord)

        {
            JObject jobj = new JObject();
            try
            {

                SqlConnection sqlCon = new SqlConnection("Data Source=(local); Integrated Security=SSPI;Initial Catalog= SuperFastDelivery; uid=sa; Password=surya@440");
                SqlCommand sqlCmd = new SqlCommand("Login", sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@username", SqlDbType.VarChar, 200).Value = userName;
                sqlCmd.Parameters.Add("@passWord", SqlDbType.VarChar, 500).Value = PassWord;
                sqlCmd.Parameters.Add("@mode", SqlDbType.TinyInt).Value = 1;
                sqlCmd.Parameters.Add("@retMsg", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                da.SelectCommand = sqlCmd;
                da.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    //string sessionUserId = "";
                    //    sessionUserId = HttpContext.Current.Session["UserId"] as string;
                    //if (string.IsNullOrEmpty(sessionUserId))
                    //{
                    //if (HttpContext.Current.Session != null)
                    //{
                    //    this.Session["UserId"] = dt.Rows[0]["Id"];
                    //}

                    //else
                    //{
                    //    this.Session.Add("UserId", dt.Rows[0]["Id"]);
                    //}   
                    //    HttpContext.Current.Session["UserName"] = dt.Rows[0]["Username"];
                    //    HttpContext.Current.Session["Name"] = dt.Rows[0]["Name"];

                    //  }
                    JArray jr = new JArray();
                  

                    foreach (DataRow dr in dt.Rows)
                    {
                        JObject tempJobj = new JObject();
                        foreach (DataColumn dc in dt.Columns)
                        {
                            tempJobj.Add(dc.ColumnName, dr[dc].ToString());
                        }
                        jr.Add(tempJobj);
                    }
                    jobj.Add("items", jr);
                }

                jobj.Add("Success", true);
                jobj.Add("Message", sqlCmd.Parameters["@retMsg"].Value.ToString());
            }
            catch (Exception ex)
            {
                jobj.Add("Success", false);
                jobj.Add("Message", ex.Message);
            }
            return jobj;

        }
        public DataSet DownloadtoExcel()
        {
            JObject jobj = new JObject();
            DataSet ds = new DataSet();
            try
            {

                SqlConnection sqlCon = new SqlConnection("Data Source=(local); Integrated Security=SSPI;Initial Catalog= SuperFastDelivery; uid=sa; Password=surya@440");
                SqlCommand sqlCmd = new SqlCommand("Login", sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
               
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@mode", SqlDbType.TinyInt).Value = 2;
                sqlCmd.Parameters.Add("@retMsg", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                da.SelectCommand = sqlCmd;
                da.Fill(ds);
     
            }
            catch (Exception ex)
            {
                jobj.Add("Success", false);
                jobj.Add("Message", ex.Message);
            }
            return ds;

        }
        public JObject SignUp(string UserName, string PassWord, string MobileNumber, string EmailID)
        {
            JObject jobj = new JObject();
            try
            {
                sqlCon = new SqlConnection(conString);
                sqlCmd = new SqlCommand("SignUp", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@mode", SqlDbType.TinyInt).Value = 1;
                sqlCmd.Parameters.Add("@UserName", SqlDbType.VarChar, 200).Value = UserName;
                sqlCmd.Parameters.Add("@PassWord", SqlDbType.VarChar, 200).Value = PassWord;
                sqlCmd.Parameters.Add("@MobileNumber", SqlDbType.VarChar, 200).Value = MobileNumber;
                sqlCmd.Parameters.Add("@EmailID", SqlDbType.VarChar, 200).Value = EmailID;
                sqlCmd.Parameters.Add("@RetVal", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@RetMsg", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                da = new SqlDataAdapter(sqlCmd);
                ds = new DataSet();
                da.Fill(ds);
                if(ds.Tables.Count > 0)
                ds.Tables[0].TableName = "";
                Helper.ConvertOutPutParametersToJson(sqlCmd.Parameters);
                Helper.DataSetToJson(ds);
               
                jobj = Helper.jobj;

            }
            catch(Exception ex)
            {
                jobj.Add(new JProperty("Message",ex.ToString()));
            }
            finally
            {
                sqlCon.Dispose();
                da.Dispose();
            }
            return jobj;
        }
    }
}
