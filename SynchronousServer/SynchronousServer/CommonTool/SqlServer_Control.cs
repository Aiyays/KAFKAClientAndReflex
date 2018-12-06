using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonTool
{
    public class SqlServer_Control
    {


        /// <summary>
        /// 查询基础信息表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetBasicConfig()
        {
            DataTable dt = null;
            try
            {
                string sql = "Select * from V_GetBasicDataConfigInfo";
                var set = ControlSqlserver.Query(sql);
                dt = set.Tables.Count != 0 ? set.Tables[0] : new DataTable();
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Debug.Print("");
            }
            return dt;
        }


        /// <summary>
        /// 异常信息记录
        /// </summary>
        /// <param name="message">异常信息</param>
        /// <param name="remark">其他备注信息</param>
        public static void Log_WriteLine(string message, string remark)
        {
            var temp = (new StackTrace()).GetFrame(1).GetMethod();
            ///发生异常的类名+方法名
            string abnormalPosition = temp.ReflectedType.Name + "." + temp.Name;

        }


        

        /// <summary>
        /// 上传记录写入
        /// </summary>
        /// <param name="dist_Data">第三方平台下拉Json</param>
        /// <param name="kafka_Data">卡夫卡推送Json</param>
        /// <param name="merge_Data">合并后上传的Json</param>
        /// <param name="hospID">智能家庭医生ID</param>
        /// <param name="controlTime">时间</param>
        /// <param name="uploadResults">上传结果</param>
        /// <param name="TableName"> </param>
        public static void DataBackup_WriteLine(string dist_Data, string kafka_Data, string merge_Data, string hospID, string controlTime, string uploadResults, string TableName)
        {

        }

        /// <summary>
        /// 异常上传失败记录
        /// </summary>
        /// <param name="hid">医院ID</param>
        /// <param name="kafka_Data">kafka推送的JSon</param>
        /// <param name="controlTime">时间</param>
        /// <param name="erroInfo">错误信息</param>
        public static void UpdateErro(string hid, string kafka_Data, string erroInfo, string tableName)
        {
            //异常发生时间
            DateTime creatTime = DateTime.Now;
            var method = new StackTrace().GetFrame(1).GetMethod();
            //调用此方法的类名+方法名
            string abnormalPosition = method.ReflectedType.Name + "." + method.Name;

        }




    }
}
