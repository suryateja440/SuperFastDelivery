using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperFastDelivery
{
    public partial class Home : System.Web.UI.Page
    {
        public string Username;
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (string.IsNullOrEmpty(Session["UserName"].ToString()))
            //{
            //    Response.Redirect("/Login.aspx");
            //}
            //else
            //{
            //    this.Username = Session["Username"].ToString();
            //}
            if (Request.QueryString["access_token"] != null)
            {
                string test = Request.QueryString["access_token"];
            }
            if (Request.QueryString["access_token"] != null)
            {

                String URI = "https://www.googleapis.com/oauth2/v1/userinfo?access_token=" +
Request.QueryString["access_token"].ToString();

                WebClient webClient = new WebClient();
                Stream stream = webClient.OpenRead(URI);
                string b;

                /*I have not used any JSON parser because I do not want to use any extra dll/3rd party dll*/
                using (StreamReader br = new StreamReader(stream))
                {
                    b = br.ReadToEnd();
                }
                JObject jobj = JObject.Parse(b);
                JObject resjobj = new JObject();
                resjobj = jobj;
                b = b.Replace("id", "").Replace("email", "");
                b = b.Replace("given_name", "");
                b = b.Replace("family_name", "").Replace("link", "").Replace("picture", "");
                b = b.Replace("gender", "").Replace("locale", "").Replace(":", "");
                b = b.Replace("\"", "").Replace("name", "").Replace("{", "").Replace("}", "");

                /*
                 
                "id": "109124950535374******"
                  "email": "usernamil@gmail.com"
                  "verified_email": true
                  "name": "firstname lastname"
                  "given_name": "firstname"
                  "family_name": "lastname"
                  "link": "https://plus.google.com/10912495053537********"
                  "picture": "https://lh3.googleusercontent.com/......./photo.jpg"
                  "gender": "male"
                  "locale": "en" } 
               */
                string id = resjobj["id"].ToString();
                string Email = resjobj["email"].ToString();
                Username = resjobj["name"].ToString();
                string familyname = resjobj["family_name"].ToString();
                
                
            }
        }
    }
}