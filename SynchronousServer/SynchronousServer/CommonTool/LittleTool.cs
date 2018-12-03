using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonTool
{
    public class LittleTool
    {

        /// <summary>
        ///Model实体进行数据的拼装(只能拼装实体)
        /// </summary>
        /// <typeparam 传进来的Model的类型="T"></typeparam>
        /// <param 以这个Model为准="own"></param>
        /// <param 这个是对比与查漏补缺的Model="client"></param>
        public static T AssemblyModel<T>(T own,T client)
        {
            Type ownType = own.GetType();
            Type clientType = client.GetType();
            PropertyInfo[] ownPropertList = ownType.GetProperties();   
            PropertyInfo[] clientPropertList = clientType.GetProperties();
            foreach (var item in ownPropertList)
            {
                string name = item.Name;
                object value = item.GetValue(own, null);
                if (value is null?true :value.Equals("")? true:false)
                {
                    try
                    {
                        value = clientPropertList.Where(s => s.Name == item.Name).Select(s => s.GetValue(client, null)).FirstOrDefault();
                    }
                    catch (Exception ex)
                    {     }
                    item.SetValue(own, value, null);
                }                 
            }
                return own ;
        }

 

        
    }
}
