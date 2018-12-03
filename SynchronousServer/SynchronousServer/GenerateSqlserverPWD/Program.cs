using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateSqlserverPWD
{
    ///用来生成加密的Sqlserver的密码
    class Program
    {
        static void Main(string[] args)
        {
            string msg =  Console.ReadLine();
            string pwd =msg.Equals("")?"这里填写默认的密码" :msg;
            ///生成Sqlserver的密码
            Console.WriteLine(CommonTool.DEncrypt.Encrypt(pwd, "ZNJTYS_SQLSERVER"));
            Console.ReadLine();
        }
    }
}
