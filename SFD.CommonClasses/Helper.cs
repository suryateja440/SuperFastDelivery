using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;
namespace SFD.CommonClasses
{
   public class Helper
    {
        public static JObject jobj;
        public static void ConvertOutPutParametersToJson(SqlParameterCollection Sqlparameters)
        {
            jobj = new JObject();
            foreach (SqlParameter sqlparameter in Sqlparameters )
            {
                
                if (sqlparameter.Direction == ParameterDirection.Output)
                {
                    string parameterName = sqlparameter.ParameterName.ToString().Substring(1, sqlparameter.ParameterName.ToString().Length -1);
                    jobj.Add(new JProperty(parameterName, sqlparameter.Value.ToString()));

                }

            }
        }
        public static void DataSetToJson(DataSet ds)
        {
            foreach (DataTable dt in ds.Tables)
            {
                JArray jarr = new JArray();
                foreach (DataRow dr in dt.Rows)
                {
                    JObject TempJobj = new JObject();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        TempJobj.Add(new JProperty(dc.ColumnName, dr[dc.ColumnName]));
                    }
                    jarr.Add(TempJobj);
                }
                jobj.Add(dt.TableName.ToString(),jarr);

            }

        }
    }
}
