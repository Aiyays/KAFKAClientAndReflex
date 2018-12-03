using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTool
{
    /// <summary>
    /// 配置表
    /// </summary>
    public   class ControlBasicConfig
    {
        /// <summary>
        /// 基本用户配置信息表
        /// </summary>
        private static DataTable basicDataConfig_Data;

        /// <summary>
        /// 初始化配置文件
        /// </summary>
        public static void InitializationBasicConfig()
        {
            basicDataConfig_Data = CommonTool.SqlServer_Control.GetBasicConfig();
        }

        /// <summary>
        /// 获取当前在线的医院数量
        /// </summary>
        /// <returns></returns>
        public static string GetNumber()
        {
            return  basicDataConfig_Data != null ?string.Format("目前在线医院有{0}家", basicDataConfig_Data.Rows.Count.ToString()) : "请先给基本用户信息表赋值";
        }

        /// <summary>
        /// 根据医院ID获取相应的配置
        /// </summary>
        /// <param name="hid"></param>
        /// <returns></returns>
        public static DataRow GetHidConfig(string hid)
        {
            DataRow dr=null;
            try
            {
                //根据医院ID查询配置信息
                var drS = basicDataConfig_Data.Select("ZNJTYS_HID="+hid);
                dr = drS.Length != 0 ? drS[0] : null;
            }
            catch ( Exception ex)
            {
                
            }
            return dr;
        }
        

    }
}
