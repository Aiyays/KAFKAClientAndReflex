using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvincialPrimaryHealthCare
{
    /// <summary>
    /// 基层控制层
    /// </summary>
    public class PrimaryControl
    {
        /// <summary>
        /// 基层控制器
        /// </summary>
        public void ControlCenter(Model.TransmitInfoModel transmitInfoModel)
        {
            Debug.Print(JsonConvert.SerializeObject(transmitInfoModel));

          
            
        }
    }
}
