using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using System.Web.Services;

namespace SuperFastDelivery
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                string token1 = Request.QueryString["access_token"];
                if (Request.QueryString["access_token"] != null)
                {
                    string token = Request.QueryString["access_token"];
                }

            }
            else
            {
               
            }
        }
        protected void Button_Login(object sender, EventArgs e)
        {
            JObject jobj = new JObject();
            SFD.BAL.Login lgn = new SFD.BAL.Login();
            jobj = lgn.LoginCheck(txtUserName.Text,txtPassWord.Text);
            if (jobj["Message"].ToString() == "Valid Username and Password")
            {
                Session["UserId"] = jobj["items"][0]["Id"];
                Session["UserName"] = jobj["items"][0]["Username"];
                Session["Name"] = jobj["items"][0]["Name"];
                if (string.IsNullOrEmpty(Session["UserId"].ToString()))
                {

                }
                else
                {
                    Response.Redirect("/Home.aspx");
                }
            }
            else {

                lblInvalidUser.Text = "Invalid User Name and password";
            }
            //return jobj; 
        }
    }
}