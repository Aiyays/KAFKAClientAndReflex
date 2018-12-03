using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTool
{
    /// <summary>
    /// 智能家庭医生接口调用
    /// </summary>
    public class Znjtys_Api
    {

    
        /// <summary>
        /// 查询个人基本信息  POST访问
        /// </summary>
        /// <param name="hid">医院id</param>
        /// <param name="ufid">个人id</param>
        /// <param name="aes">Aes秘钥</param>
        /// <returns></returns>
        public static JObject QueryPersonInfo(string hid, string ufid, string aes)
        {
            JObject jo = null;
            string data = CommonTool.DeEncryption.AESEncrypt("a",aes) ;
            string url = string.Format(@"{0}?data={1}&hid={2}&ufid={3}",ConfigurationManager.AppSettings["ZNJTYS_Path"], data, hid, ufid);
            string ret = "";
            try
            {
                ret = CommonTool.NetworkPush.PostHTTP(url);
                jo = JObject.Parse(ret);
                string msg = CommonTool.DeEncryption.AESDecrypt(jo["data"].ToString(), aes).ToString().Replace(@"\", "").Replace("\"{", "{").Replace("\"[", "[").Replace("}\"", "}").Replace("]\"", "]").Trim('"'); ;
                jo = JObject.Parse(JArray.Parse(msg)[0].ToString());
            }
            catch (Exception ex)
            {
                SqlServer_Control.Log_WriteLine(ex.Message,string.Format("{0}-{1}-{2}-{3}",hid,ufid,ret,jo.ToString()));
            }
            return jo;
        }






    }
}
