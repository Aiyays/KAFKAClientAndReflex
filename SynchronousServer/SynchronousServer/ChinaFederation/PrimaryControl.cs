using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinaFederation
{
    public class PrimaryControl
    {

        /// <summary>
        /// 基层控制器
        /// </summary>
        public void ControlCenter(Model.TransmitInfoModel transmitInfoModel)
        {
            //CommonTool.ControlReflex.Reflex(new Model.ReflexModel()
            //{
            //    ClassName = transmitInfoModel.Type + ".FunctionalAssembly",
            //    DomainName = string.Format(@".\{0}.dll", transmitInfoModel.Type),
            //    MethodName = transmitInfoModel.State,
            //    Parameter = transmitInfoModel
            //});
        }

 
    }
}