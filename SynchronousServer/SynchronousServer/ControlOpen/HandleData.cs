using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SynchronousServer
{
    /// <summary>
    /// 
    /// </summary>
    public class HandleData
    {

        /// <summary>
        /// 最外层控制器
        /// </summary>
        /// <param name="data">data数据</param>
        /// <param name="hid">Hid</param>
        public static void ControlCenter(string msg, string hid, Action<string,string> receipt)
        {
            try
            {
                DataRow dr = CommonTool.ControlBasicConfig.GetHidConfig(hid);
                string c = msg;
                //解析接到的数据
                msg = CommonTool.DeEncryption.AESDecrypt(msg, dr["ZNJTYS_Aes"].ToString());
                var info = JsonConvert.DeserializeObject<Dictionary<string, object>>(msg);
                //表名
                string tableName = Regex.Replace(info["tableName"].ToString(), @"^\w", t => t.Value.ToUpper());

                Console.WriteLine(string.Format("接受到表{0}的数据",tableName));
                //数据
                string data = info["data"].ToString().Replace(@"\r\n","").Replace(@"\", "").Replace("\"{", "{").Replace("\"[", "[").Replace("}\"", "}").Replace("]\"", "]").Trim('"');
                //上传信息
                Model.TransmitInfoModel infoModel = new TransmitInfoModel()
                {
                    Data = data,
                    ZNJTYS_Hid = hid,
                    BasicInfo = dr,
                    TableName = tableName,
                    ReceiptSend = receipt,
                    Ecdecnoy = CommonTool.DeEncryption.AESEncrypt,
                };
                Console.WriteLine("接受到{0}的数据{1}",tableName,data);
                //反射控制
                CommonTool.ControlReflex.Reflex(new Model.ReflexModel()
                {
                    ClassName = dr["Code"] + ".PrimaryControl",
                    DomainName = string.Format(@".\{0}.dll", dr["Code"]),
                    MethodName = "ControlCenter",
                    Parameter = infoModel
                });
            }
            catch (Exception ex)
            {
                CommonTool.SqlServer_Control.UpdateErro(hid, msg, ex.Message, "");
            }
        }

   

    }
}
