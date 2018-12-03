//using LitJson;
using RdKafka;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlServer
{

    /// <summary>
    /// 卡夫卡客户端
    /// </summary>
    public class KafkaClient
    {

        /// <summary>
        /// 消费者
        /// </summary>
        /// <param 服务器地址集群="ipColony">192.168.8.124:9092,192.168.8.169:9092,192.168.8.163:9092</param>
        /// <param 订阅的话题的集合="topicLis"></param>
        /// <param 处理接受到的数据的方法="ControlRecive"> </param>
        public void Consumer(string ipColony, List<string> topicLis, Action<string,string,Action<string,string>> ControlRecive)
        {
            //配置消费者组
            var config = new Config() { GroupId = "ZNJTYS-LISServer-Recvive" };
            using (var consumer = new EventConsumer(config, ipColony))
            {
                //注册一个事件
                consumer.OnMessage += (obj, msg) =>
                {
                    string data = Encoding.UTF8.GetString(msg.Payload, 0, msg.Payload.Length);
                    //new Task(()=>{
                        ControlRecive(data, msg.Topic.ToString(),Producer);
                    //}).Start();   
                };
                //订阅一个或者多个Topic
                consumer.Subscribe(topicLis);
                //启动
                consumer.Start();
                Console.WriteLine(string.Format("开启Kafka消费模式\r\n网络集群地址{0}\r\n消费Topic:{1}",ipColony, topicLis[0]));
                Console.ReadLine();
            }
        }

        /// <summary>
        /// 生产者
        /// </summary>
        /// <param 话题名称="topicName"></param>
        /// <param 发送的消息="sendMsg"></param>
        /// <param 服务器地址集群="ipColony">192.168.8.124:9092,192.168.8.169:9092,192.168.8.163:9092</param>
        public static void Producer(string sendMsg,string plaintext)
        {
            new Task(async () =>
            {
                string IpColony = ConfigurationManager.AppSettings["IPLis"];
                // Producer 接受一个或多个 BrokerList
                //配置生产者组
                Console.WriteLine(string.Format("向话题znjtys发送:{0}", plaintext.Replace("\r","").Replace("\n","")));
                  
                using (Producer producer = new Producer(IpColony))
                //发送到一个名为 topicName 的Topic，如果没有就会创建一个
                using (Topic topic = producer.Topic("znjtyss"))
                {
                    byte[] data = Encoding.UTF8.GetBytes(sendMsg);
                    DeliveryReport deliveryReport = await topic.Produce(data);
                }

            }).Start();
        }

        /// <summary>
        /// 生产者
        /// </summary>
        /// <param 话题名称="topicName"></param>
        /// <param 发送的消息="sendMsg"></param>
        /// <param 服务器地址集群="ipColony">192.168.8.124:9092,192.168.8.169:9092,192.168.8.163:9092</param>
        public void Producer(string topicName, string sendMsg,string ipColony)
        {
            new Task(async () =>
            {
                // Producer 接受一个或多个 BrokerList
                //配置生产者组
                using (Producer producer = new Producer(ipColony))
                //发送到一个名为 topicName 的Topic，如果没有就会创建一个
                using (Topic topic = producer.Topic(topicName))
                {
                    byte[] data = Encoding.UTF8.GetBytes(sendMsg);
                    DeliveryReport deliveryReport = await topic.Produce(data);
                }
            }).Start();
        }

    }
}
