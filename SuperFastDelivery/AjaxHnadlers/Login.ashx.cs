using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using Newtonsoft.Json.Linq;
using SFD.BAL;


namespace SuperFastDelivery.AjaxHandlers
{
    /// <summary>
    /// Summary description for Login
    /// </summary>
    public class Login : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string type = context.Request["type"];
            JObject resJobj = new JObject();
            switch (type)
            {
                case "1":
                    {
                        
                        resJobj = LoginCheck(context);
                        context.Response.Write(resJobj);
                        break;
                    }
                case "2":
                    {
                        
                         DownloadtoExcel(context);
                       
                        break;
                    }
                case "3":
                    {
                        resJobj =  SignUp(context);
                        context.Response.Write(resJobj);
                        break;

                    }


            }
            

        }
        public JObject LoginCheck(HttpContext context)
        {
            JObject jobj = new JObject();
            SFD.BAL.Login lgn = new SFD.BAL.Login();
            jobj = lgn.LoginCheck(context.Request["username"],context.Request["password"]);

            return jobj;
        }

        public void DownloadtoExcel(HttpContext context)
        { 
            try
            { 
            JObject jobj = new JObject();
            DataSet ds = new DataSet();
            SFD.BAL.Login lgn = new SFD.BAL.Login();
            ds = lgn.DownloadtoExcel();

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Reports.xls");

            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
            //sets font
            HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
            HttpContext.Current.Response.Write("<BR><BR><BR>");
            //sets the table border, cell spacing, border color, font of the text, background, foreground, font height
            HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' " +
              "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
              "style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");
            //am getting my grid's column headers
            int columnscount = ds.Tables[0].Columns.Count;

            for (int j = 0; j < columnscount; j++)
            {      //write in new column
                HttpContext.Current.Response.Write("<Td>");
                //Get column headers  and make it as bold in excel columns
                HttpContext.Current.Response.Write("<B>");
                HttpContext.Current.Response.Write(ds.Tables[0].Columns[j].ColumnName.ToString());
                HttpContext.Current.Response.Write("</B>");
                HttpContext.Current.Response.Write("</Td>");
            }
            HttpContext.Current.Response.Write("</TR>");
            foreach (DataRow row in ds.Tables[0].Rows)
            {//write in new row
                HttpContext.Current.Response.Write("<TR>");
                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    HttpContext.Current.Response.Write("<Td>");
                    HttpContext.Current.Response.Write(row[i].ToString());
                    HttpContext.Current.Response.Write("</Td>");
                }

                HttpContext.Current.Response.Write("</TR>");
            }
            HttpContext.Current.Response.Write("</Table>");
            HttpContext.Current.Response.Write("</font>");
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();

        }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.ToString());
            }
        }

        public JObject SignUp(HttpContext context)
        {
            JObject resjobj = new JObject();
            SFD.BAL.Login lg = new SFD.BAL.Login();
            resjobj = lg.SignUp(context.Request["Username"].ToString(), context.Request["PassWord"].ToString(), context.Request["MobileNumber"].ToString(), context.Request["EmaiID"].ToString());
            return resjobj;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}