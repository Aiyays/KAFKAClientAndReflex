using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTool
{
    /// <summary>
    /// 时间类
    /// </summary>
    public class ControlTime
    {
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static int GetTimeStampTime()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return (int)Convert.ToInt64(ts.TotalSeconds);
        }

        /// <summary>
        /// 把指定时间变成时间戳
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int GetTimeStampTime(DateTime dt)
        {
            DateTime dateStart = new DateTime(1970, 1, 1, 8, 0, 0);
            long timeStamp = Convert.ToInt32((dt - dateStart).TotalSeconds);
            return (int)timeStamp;
        }


        /// <summary>
        /// 获取当前时间戳
        /// </summary>
        /// <returns></returns>
        public static int GetTimeStampDate()
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0)); // 当地时区
            int timeStamp = (int)(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 00:00:00")) - startTime).TotalSeconds; // 相差秒数
            return timeStamp;
        }

        /// <summary>
        /// 把指定时间转换为时间戳
        /// </summary>
        /// <returns></returns>
        public static int GetTimeStampDate(DateTime dt)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0)); // 当地时区
            int timeStamp = (int)(Convert.ToDateTime(dt.ToString("yyyy-MM-dd 00:00:00")) - startTime).TotalSeconds; // 相差秒数
            return timeStamp;
        }

        /// <summary>
        /// 获取GUID
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string GetGuid(int Length = 32)
        {
            return Guid.NewGuid().ToString("N").Substring(0, Length);
        }
        /// <summary>
        /// 时间戳转换成时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(long time)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0)); // 当地时区
            DateTime dt = startTime.AddSeconds(time);
            return dt;
        }

    }
}
