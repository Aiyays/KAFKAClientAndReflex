using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvincialSecurity
{

    /// <summary>
    /// 省公卫控制方法  建议后期  直接以传输的数据中的State 作为反射的方法名
    /// </summary>
    public class ModuleSelection
    {
        /// <summary>
        /// 反射控制的方法
        /// </summary>
        /// <param name="data"></param>
        public void ControlCenter(Model.TransmitInfoModel transmitInfoModel)
        {
            ///当了解清楚传输的内容以后  这里填写将数据 根据解析类型的解析方法解析以后  分布的上传到各个IIS系统
        }
    }
}
