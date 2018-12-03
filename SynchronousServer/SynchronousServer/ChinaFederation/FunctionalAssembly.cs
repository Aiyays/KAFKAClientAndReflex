using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinaFederation
{
    /// <summary>
    /// 中联代码组装区域
    /// </summary>
    public class FunctionalAssembly
    {
        /// <summary>
        /// 中联公卫糖尿病的代码组装
        /// </summary>
        /// <param name="transmitInfoModel"></param>
        public void Diabetes(Model.TransmitInfoModel transmitInfoModel)
        {
            ///拼装完成后 按照配置文件 发送给相应的IIS服务器
            ///从Kafka接受到的数据：Topic:"随意"， {"RecordID":"随意","Type":"ChinaFederation","State":"Diabetes","Data":"随意","UpJson":null}
            ///接受到的TransmitInfoModel{"ZNJTYS_Hid":"随意","RecordID":"随意","Type":"ChinaFederation","State":"Diabetes","Data":"随意","UpJson":null}
        }
    }
}
