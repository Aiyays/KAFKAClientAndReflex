using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
 
    /// <summary>
    /// 数据内容
    /// </summary>
    public class Data
    {
        /// <summary>
        /// 表类型(比如说followBpm)
        /// </summary>
        public string tableType { get; set; }
        /// <summary>
        /// followBpm的id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 是否上传到生工委(1:成功,0:失败)
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// 失败原因
        /// </summary>
        public string message { get; set; }
    }

    /// <summary>
    /// 回执服务器需要用到的信息
    /// </summary>
    public class ReceiptInfoModel
    {
        /// <summary>
        /// 医院id
        /// </summary>
        public string hid { get; set; }
        /// <summary>
        /// 数据内层
        /// </summary>
        public Data data { get; set; }

    }
}
