using System;
using System.Collections.Generic;
using System.Linq;
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
            switch (type)
            {
                case "1":
                    {
                        JObject resJobj = new JObject();
                        // resJobj = new JObject(new JProperty("message", "successs"));
                        resJobj = LoginCheck(context);
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}