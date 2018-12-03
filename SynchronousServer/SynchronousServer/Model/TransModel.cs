using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 转换Model
    /// </summary>
    public class TransModel
    {
        /// <summary>
        /// 键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public JToken Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public JObject KafkaData { get; set; }


        /// <summary>
        /// 后续拉取到的信息
        /// </summary>
        public UEEstimateModel userInfo { get; set; }

        /// <summary>
        /// 个人基本信息
        /// </summary>
        public DataRow BasicInfo { get; set; }

    }
}
