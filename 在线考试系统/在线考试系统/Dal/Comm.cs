using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace 在线考试系统.Dal
{
    class Comm
    {
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <returns>数据库连接串</returns>
        public static string getConnectionStr()
        {
            return ConfigurationManager.ConnectionStrings["conStr"].ToString();
        }
    }
}
