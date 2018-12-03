using Newtonsoft.Json.Linq;
using RdKafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestKafka
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "918";
            while(true)
            {
    
           
                Console.WriteLine("任意键回车发送");
                string msg = "SoDpQrd+Umc55FWn4Mlo84LEfpP3kjOJDcrn+0dwxk27m3JE6l8w6hEJBdN/oTUqKn/tgKEqmMRE\noEQ6E7eECWxeLfncNrXUfCeln1IvwVXY4mqPCZ3r/AHt8BUe1/9vgTFn8EFe9WilkFIG+6tfkbwL\nKdzvOdcXmudzjfeM9xUM3tlPo1cuviaYNIr5NCpQYjeRBn7TdcvcAYVioOhliLVuY9fXak65/ckM\nshj5RhHqSy4t7Gmup9i+TVtL7oowaQMFUKsDGonz52JupMIQ8kQMyLq+GJpDDokOsYdXqKJshDFj\ntFi1SD11oqif1qT7jE/pZ4WTdrNfQelfb3k3uiZVkeU+ZaJC36O2vQEGXiLpwbf5zoRe0EeVvMuj\nO1gIZu2BXOF1FsTOQ526nFs+4NWZiwfY44somkBdq0tW5EglNQG+ZUH9SNL+yj9vSwxOl4tYX1Vb\nKOgNjGk6AcKIHdlZ/HkN6hEU1YHue+2FISXRfk510m0hLCQX50z5rIJyZkj6FTUoxu4zdxdKpX0M\nhERS0GjtK8S5ff2WSXrwp9VLKuSwJezwHEAKd0aQoUD2Cs8d/szCHDFeRdPv81TAVagQD2OJjZvl\nwcu/VhSUo+7x92LybQvejoPiBXJ3v6AgFEVlMHcRnhsu9JwemMmtbRzya5oOLD5QUqAgcbBoJ1mc\nP2mKR9fcJoqyZN4/bxjoUCTCqRmqRi+o2/Xq0YVxWFHHhsRrrNbasd3iDlrqn+OLuGDZrS3wvbhN\nczafuL+x07bDuZ8ya1PAeIGmJeNBc9JlPeaBpSuHWUDRH1zdnDLqgKij+Rf2HakfndzjF5WYjk0P\nUU06EVpasQsS8VeblqWxiETKuJB4XQtwV+ABJadIACIXmLuLf+aVb8Xn0AQWSX+EpWyRcj581KCO\nzt031HXKtr//sk0+VJVPefeDu7JzqZNU9viijNUPnjomh1cmLE9ho2jo3H4c7ZKuTraFodDjVO2t\nLHY/35WcphTGWNM1qKXw2DVI9+hNBtGnxxqK";
                Producer(str, msg, "47.100.164.82:9092,47.100.164.82:9093,47.100.164.82:9094");

                Console.ReadLine();


                
            }
        }


        /// <summary>
        /// 消费者
        /// </summary>
        /// <param 服务器地址集群="ipColony">192.168.8.124:9092,192.168.8.169:9092,192.168.8.163:9092</param>
        /// <param 订阅的话题的集合="topicLis"></param>
        /// <param 处理接受到的数据的方法="ControlRecive"> </param>
        public static void Consumer(string ipColony, List<string> topicLis )
        {
            //配置消费者组
            var config = new Config() { GroupId = "ZNJTYS-LISServer-Recve" };
            using (var consumer = new EventConsumer(config, ipColony))
            {
                //注册一个事件
                consumer.OnMessage += (obj, msg) =>
                {
                    string data = Encoding.UTF8.GetString(msg.Payload, 0, msg.Payload.Length);
                    Console.WriteLine(string.Format("{0}接到未解密数据{1}",DateTime.Now,data));
                };
                //订阅一个或者多个Topic
                consumer.Subscribe(topicLis);
                //启动
                consumer.Start();
                Console.WriteLine(string.Format("开启Kafka消费模式\r\n网络集群地址{0}\r\n消费Topic:{1}", ipColony, topicLis[0]));
                Console.ReadLine();
            }
        }

        /// <summary>
        /// 生产者
        /// </summary>
        /// <param 话题名称="topicName"></param>
        /// <param 发送的消息="sendMsg"></param>
        /// <param 服务器地址集群="ipColony">192.168.8.124:9092,192.168.8.169:9092,192.168.8.163:9092</param>
        public static void Producer(string topicName, string sendMsg, string ipColony)
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
