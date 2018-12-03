using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 传递的信息Model
    /// </summary>
    public class TransmitInfoModel
    {

        /// <summary>
        /// 智能家庭医生医院ID
        /// </summary>
        public string ZNJTYS_Hid { get; set; }

        /// <summary>
        /// 方法名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 基础信息
        /// </summary>
        public DataRow BasicInfo { get; set; }

        /// <summary>
        /// 需要上传的数据
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// 回执到服务器的信息发送
        /// </summary>
        public Action<string,string> ReceiptSend { private get; set; }

        /// <summary>
        /// 回执到服务器
        /// </summary>
        public Func<string,string,string> Ecdecnoy { private get; set; }

        /// <summary>
        /// 回执到服务器
        /// </summary>
        /// <param name="hospID">医院ID</param>
        /// <param name="tableName">表名</param>
        /// <param name="id">表iD</param>
        /// <param name="state">上传状态</param>
        /// <param name="message">失败原因（如果失败）</param>
        public void SendReceMsg(string hospID, string tableType, string id, string state, string message,string aes)
        {
            JObject retObj = new JObject()
            {
                {"hid",hospID },
                {"data",Ecdecnoy(new JObject(){
                        {"tableType", tableType},
                        {"id",id },
                        {"state",state },
                        {"message",message},
                }.ToString(),aes)},
            };
            ReceiptSend(retObj.ToString(), new JObject(){
                        {"tableType", tableType},
                        {"id",id },
                        {"state",state },
                        {"message",message},
                        
                }.ToString());

        }


    }
}
