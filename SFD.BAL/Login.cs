using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SFD.DAL;

namespace SFD.BAL
{
   public class Login
    {
        public JObject LoginCheck(string username,string password)
        {
            JObject jobj = new JObject();
            SFD.DAL.Login lgn = new DAL.Login();
            jobj = lgn.LoginCheck(username,password);
            return jobj;
        }
    }
}
