using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTool
{
    class SQLServerAffair
    {

        public bool transactionOp()
        {
            // 事务成功返回true，事务失败返回false
            bool result = false;
            string SqlConnectionString = "Data Source=.;Initial Catalog=DataBaseName;User ID=sa;pwd=123456;Connection Lifetime=0;max pool size=200";
            SqlConnection cn = new SqlConnection(SqlConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlTransaction transaction = null;

            try
            {
                // 打开数据库
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                // 开始事务
                transaction = cn.BeginTransaction();
                cmd.Transaction = transaction;
                cmd.Connection = cn;

                // 执行第一条SQL语句
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Users values('admin', 'admin')";
                if (cmd.ExecuteNonQuery() < 0)
                    throw new Exception();

                // 执行第二条SQL语句
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Users set pwd = '123456' where name = '小明'";
                if (cmd.ExecuteNonQuery() < 0)
                    throw new Exception();

                // 提交事务
                transaction.Commit();
                result = true;
            }
            catch
            {
                result = false;
                // 回滚事务
                transaction.Rollback();
            }
            finally
            {
                // 关闭数据库
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Dispose();
                cmd.Dispose();
                transaction.Dispose();
            }
            return result;
        }

    }
}
