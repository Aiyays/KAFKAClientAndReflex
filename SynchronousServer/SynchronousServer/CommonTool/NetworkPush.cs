using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonTool
{

    /// <summary>
    /// 网络提交
    /// </summary>
    public class NetworkPush
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strURL"></param>
        /// <returns></returns>
        public static string GetHTTP(string strURL)
        {
            string retString = "";
            try
            {
                HttpWebRequest request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
                request.Method = "get";
                request.KeepAlive = false;
                System.Net.HttpWebResponse response;
                response = (System.Net.HttpWebResponse)request.GetResponse();
                System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
                retString = myreader.ReadToEnd();
                myreader.Close();
                response.Close();
            }
            catch
            {
            }
            return retString;
        }
        /// <summary>
        /// Post请求方式
        /// </summary>
        /// <param name="strURL"></param>
        /// <returns></returns>
        public static string PostHTTP(string strURL)
        {
            string retString = "";
            try
            {
                HttpWebRequest request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
                request.Method = "POST";
                request.KeepAlive = false;
                System.Net.HttpWebResponse response;
                response = (System.Net.HttpWebResponse)request.GetResponse();
                System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
                retString = myreader.ReadToEnd();
                myreader.Close();
                response.Close();
            }
            catch(Exception ex) {
                SqlServer_Control.Log_WriteLine(ex.Message,strURL);
            }
            return retString;
            //string[] temp = strURL.Split('?');

            //return postHTTP(temp[0],temp[1]);
        }
        /// <summary>  
        /// Post数据到网站  
        /// </summary>  
        /// <param name="posturl">网址</param>  
        /// <param name="postData">参数</param>  
        /// <returns></returns>  
        public static string PostHTTP(string posturl, string postData)
        {
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Encoding encoding = System.Text.Encoding.GetEncoding("UTF-8");
            byte[] data = encoding.GetBytes(postData);
            // 准备请求...  
            try
            {
                // 设置参数  
                request = WebRequest.Create(posturl) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;
                outstream = request.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Close();
                //发送请求并获取相应回应数据  
                response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求  
                instream = response.GetResponseStream();
                sr = new StreamReader(instream, encoding);
                //返回结果网页（html）代码  
                string content = sr.ReadToEnd();
                string err = string.Empty;
                return content;
            }
            catch (Exception ex)
            {
                SqlServer_Control.Log_WriteLine(ex.Message, string.Format("{0}<--->{1}",posturl,postData));
                string err = ex.Message;

                //Print.WriteLine(string.Format("时间:{0} \r\n具体位置锁定:{1} \r\n异常信息:{2} \r\n异常位置锁定:{3}\r\n", DateTime.Now, MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name, ex.Message + ex.InnerException, ex.StackTrace));
                return string.Empty;
            }
        }


        /// <summary>
        /// WebServers提交
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="action">方法类型 例 55-1</param>
        /// <param name="data">上传的Date</param>
        /// <returns></returns>
        public static string WebserversPost(string url, string action, string data)
        {
            //自己开启一个WebService发送器
            WebService his = new WebService(url) { Url = url };
            while (true)
            {
                try
                {
                    //请求返回结果
                    string result = his.HIS_Interface(action, data); //自带WebService请求接口
                    //请求结果不为空 则返回
                    if (result != null)
                        return result;
                }
                catch (Exception ex)
                {
                    CommonTool.SqlServer_Control.Log_WriteLine(ex.Message, string.Format("{0}-{1}-{2}", url, action, data));
                }
                Thread.Sleep(10);
            }


        }


    }
}
