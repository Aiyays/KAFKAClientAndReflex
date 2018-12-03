using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{

    /// <summary>
    /// 卡夫卡接受到的数据的解析实例
    /// </summary>
    public class ReflexModel
    {

        /// <summary>
        /// 文件地址
        /// </summary>
        public string DomainName { get; set; }

        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName { get; set;}

        /// <summary>
        /// 方法名
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// Json参数
        /// </summary>
        public TransmitInfoModel Parameter { get; set; }



    }
}
