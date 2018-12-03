using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
namespace CommonTool
{

    /// <summary>
    /// 控制反射
    /// </summary>
    public class ControlReflex
    {
        /// <summary>
        /// 反射调用方法
        /// </summary>
        /// <param 实例调用的方法="model"></param>
        public static void Reflex(Model.ReflexModel model)
        {
            try
            {
                Assembly asmb = Assembly.LoadFrom(model.DomainName);
                Type type = asmb.GetType(model.ClassName);
                if (type != null)
                {
                    object obj = System.Activator.CreateInstance(type);
                    MethodInfo method = type.GetMethod(model.MethodName);
                    try
                    {
                        method.Invoke(obj, new object[] { model.Parameter });
                    }
                    catch (Exception e)
                    {
                        Debug.Print("未找到接收的方法:" + e);
                    }
                }
            }
            catch (Exception ex)
            {
                //记录到数据库
                CommonTool.SqlServer_Control.UpdateErro(model.Parameter.ZNJTYS_Hid,model.Parameter.Data,ex.Message,model.Parameter.TableName);
            }
        }
    }

}
