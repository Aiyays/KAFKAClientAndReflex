using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCProvinceHygiene
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
            try
            {
                //反射控制
                CommonTool.ControlReflex.Reflex(new Model.ReflexModel()
                {
                    ClassName = transmitInfoModel.BasicInfo["Code"] + ".FunctionalAssembly",
                    DomainName = string.Format(@".\{0}.dll", transmitInfoModel.BasicInfo["Code"]),
                    MethodName = transmitInfoModel.TableName,
                    Parameter = transmitInfoModel
                });
            }
            catch ( Exception ex)
            {
                //失败异常日志记录
                CommonTool.SqlServer_Control.UpdateErro(transmitInfoModel.ZNJTYS_Hid,transmitInfoModel.Data,ex.Message,transmitInfoModel.TableName); 
            }
        } 
    }
}
