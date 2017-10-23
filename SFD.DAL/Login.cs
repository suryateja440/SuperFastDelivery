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
//using System.Web.Configuration;


namespace SFD.DAL
{
   public class Login : System.Web.UI.Page
    {
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
                sqlCmd.Parameters.Add("@username", SqlDbType.VarChar, 200).Value = "123456789";
                sqlCmd.Parameters.Add("@passWord", SqlDbType.VarChar, 500).Value = "123456789";
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
                        if(!(string.IsNullOrEmpty(dt.Rows[0]["Id"].ToString())))
                        {
                            HttpContext.Current.Session["UserId"] = dt.Rows[0]["Id"];
                        }
                        
                        HttpContext.Current.Session["UserName"] = dt.Rows[0]["Username"];
                        HttpContext.Current.Session["Name"] = dt.Rows[0]["Name"];
                        
                  //  }
                    //JArray jr = new JArray();
                    //DataTable dt = ds.Tables[0];

                    //    foreach (DataRow dr in dt.Rows)
                    //    {
                    //        JObject tempJobj = new JObject();
                    //        foreach (DataColumn dc in dt.Columns)
                    //        {
                    //            tempJobj.Add(dc.ColumnName,dr[dc].ToString());
                    //        }
                    //        jr.Add(tempJobj);
                    //    }
                    //jobj.Add("items", jr);
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
    }
}
