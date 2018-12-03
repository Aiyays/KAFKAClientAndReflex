using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    /// <summary>
    /// 接受数据的ConsumerModel
    /// </summary>
    public class ConsumerModel
    {

        /// <summary>
        /// 话题
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        /// 分区
        /// </summary>
        public string Partition { get; set; }

        /// <summary>
        /// 偏移量
        /// </summary>
        public string Offset { get; set; }

        /// <summary>
        /// 接受到的
        /// </summary>
        public string Data { get; set; }

    }
}
