using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sybase.Data.AseClient;
using System.Text.RegularExpressions;
using Model;
using System.IO;

namespace SynchronousServer
{
    class Program
    {
        enum MyEnum
        {
            糖尿病,
            高血压,
            智障,
        }
        static void Main(string[] args)
        {
 

            //给数据库地址赋值         
            CommonTool.ControlSqlserver.connectionString = ConfigurationManager.AppSettings["SqlserverPath"] + string.Format("Password = {0};", CommonTool.DEncrypt.Decrypt(ConfigurationManager.AppSettings["password"], ConfigurationManager.AppSettings["path"]));

            //本地配置   
            //CommonTool.ControlSqlserver.connectionString = ConfigurationManager.AppSettings["SQLServerUrl"];

            //初始化配置文件
            CommonTool.ControlBasicConfig.InitializationBasicConfig();

            //初始化kafuka
            ControlServer.KafkaClient kafkaClient = new ControlServer.KafkaClient();

            //线程运行Kafka
            new Task(() =>
            {
                kafkaClient.Consumer(ConfigurationManager.AppSettings["IPLis"], ConfigurationManager.AppSettings["TopicLis"].Split(',').ToList(), HandleData.ControlCenter);
            }).Start();

            Cmd();

        }


        public static TransModel TransModel(TransModel transModel)
        {
            if (transModel.Value.GetType().Name.Equals("JArray"))
                transModel.Value = new JArray();
            else
                transModel.Value = "";
            
            return transModel;

        }


      

        /// <summary>
        /// 遍历一个Json直到最底层
        /// </summary>
        /// <param name="object">需要遍历的Json传</param>
        /// <param name="func">Json转换的方法</param>
        /// <param name="upper">这是一个预值 用来判断是否存在上级</param>
        public static JObject Test(JObject @object, Func<Model.TransModel, TransModel> func, string upper="")
        {
            //循环遍历得到的参数
            foreach (var item in new JObject(@object))
            {
                //创建实体
                TransModel model = new TransModel() { Key = item.Key.Trim(), Value = item.Value.ToString().Trim() };
                //判断是否有上级,我们的上级 用 A_B的方式代表 
                model.Key = upper.Equals("") ? item.Key : upper + "_" + item.Key;
                //根据数据类型处理
                if (item.Value.GetType().Name.Equals("JObject"))
                    model.Value = Test(JObject.FromObject(item.Value), func, model.Key);
                //根据传入方法转换
               else
                    model = func(model);
                //在这里判断为JArray直接合并 
                if (item.Value.GetType().Name.Equals("JArray"))
                    @object[item.Key.Trim()]=model.Value;
                else
                    //赋值并返回
                    @object[item.Key.Trim()] = model.Value;
            }
            return @object;
        }





        public void 暂时存放()
        {
            //给数据库地址赋值         
            CommonTool.ControlSqlserver.connectionString = ConfigurationManager.AppSettings["SqlserverPath"] + string.Format("Password = {0};", CommonTool.DEncrypt.Decrypt(ConfigurationManager.AppSettings["password"], ConfigurationManager.AppSettings["path"]));

            //本地配置   
            //CommonTool.ControlSqlserver.connectionString = ConfigurationManager.AppSettings["SQLServerUrl"];

            //初始化配置文件
            CommonTool.ControlBasicConfig.InitializationBasicConfig();

            //初始化kafuka
            ControlServer.KafkaClient kafkaClient = new ControlServer.KafkaClient();

            //线程运行Kafka
            new Task(() =>
            {
                kafkaClient.Consumer(ConfigurationManager.AppSettings["IPLis"], ConfigurationManager.AppSettings["TopicLis"].Split(',').ToList(), HandleData.ControlCenter);
            }).Start();


        }
        /// <summary>
        /// 控制台常用指令
        /// </summary>
        static void Cmd()
        {
            while (true)
            {
                string cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "cls"://清屏
                        Console.Clear();
                        break;
                    case "exit"://退出
                        System.Environment.Exit(0);
                        break;
                    case "hospcount": //当前医院数量
                        Console.WriteLine(CommonTool.ControlBasicConfig.GetNumber());
                        break;
                    case "information"://现在个人集群地址
                        Console.WriteLine(string.Format("话题:{0}\r\n集群地址{1}", ConfigurationManager.AppSettings["TopicLis"], ConfigurationManager.AppSettings["IPLis"]));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
