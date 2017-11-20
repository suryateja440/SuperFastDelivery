using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;

namespace SuperFastDelivery.AjaxHnadlers
{
    /// <summary>
    /// Summary description for ExportToExcel
    /// </summary>
    public class ExportToExcel : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string type = context.Request["type"];
            switch (type)
            {
                case "1":
                    {
                        JObject resJobj = new JObject();
                        // resJobj = new JObject(new JProperty("message", "successs"));
                      //  resJobj = LoginCheck(context);
                        context.Response.Write(resJobj);
                        break;
                    }
                case "2":
                    {
                        JObject resJobj = new JObject();
                        // resJobj = new JObject(new JProperty("message", "successs"));
                        context.Response.AddHeader("content-disposition", "attachment; filename=FileName.xls");
                        context.Response.ContentType = "application/ms-excel";
                        HttpRequest request = context.Request;
                        HttpResponse response = context.Response;
                        string exportContent = CreateExcel();
                        response.Write(exportContent);

                        break;
                    }


            }
            
        }

        private string CreateExcel()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            //ds = GetDatasetFromDatabase();//implement this function to get data from database
            //dt = ds.Tables[0];//get datatable from dataset
           // dt = GetTable();//dummy table filled with dummy data
            SFD.BAL.Login lgn = new SFD.BAL.Login();
            ds = lgn.DownloadtoExcel();
            dt = ds.Tables[0];
            using (StringWriter sb = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sb))
                {
                    Table table = new Table();// create a table to hold all the data which we need to export
                    TableHeaderRow thr = new TableHeaderRow();
                    TableRow row = new TableRow();
                    TableHeaderCell thc;//create 1st row as header row
                    foreach (DataColumn dc in dt.Columns)//loop to create header columns
                    {
                        thc = new TableHeaderCell();
                        thc.Text = dc.ColumnName;
                        row.Cells.Add(thc);
                    }
                    table.Rows.Add(row);//add header row to table
                    TableCell tc;
                    foreach (DataRow dr in dt.Rows)//loop to crate all rows of excel
                    {
                        row = new TableRow();//create new row of table
                        foreach (DataColumn dc in dt.Columns)//loop to create columns of individual row
                        {
                            tc = new TableCell();
                            tc.Text = dr[dc].ToString();
                            row.Cells.Add(tc);
                        }
                        table.Rows.Add(row);//add row to table
                    }
                    table.RenderControl(htw);//render table to html text writer
                    return sb.ToString();//return table as string
                }
            }
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