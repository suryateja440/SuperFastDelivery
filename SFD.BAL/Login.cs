using System.Data;
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
        public DataSet DownloadtoExcel()
        {
            string message = "";
            JObject jobj = new JObject();
            DataSet ds = new DataSet();
            SFD.DAL.Login lgn = new DAL.Login();
            ds = lgn.DownloadtoExcel();
            return ds;
        }
        public JObject SignUp(string UserName,string PassWord,string MobileNumber,string EmailID)
        {
            JObject jobj = new JObject();
            SFD.DAL.Login lg = new DAL.Login();
            jobj = lg.SignUp(UserName,PassWord,MobileNumber,EmailID);
            return jobj;
        }
    }
}
