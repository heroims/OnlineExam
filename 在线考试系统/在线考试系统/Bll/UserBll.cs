using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using 在线考试系统.Model;
using 在线考试系统.Dal;
namespace 在线考试系统.Bll
{
    class UserBll
    {
        static UserDal UserD;
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="User">用户信息实体</param>
        /// <returns>int类型，0表示有用户，1表示没有用户</returns>
        public static int UserISNO(UserInfo User)
        {
            UserD = new UserDal();
            return UserD.UserSelect(User);
        }
        /// <summary>
        /// 更新用户密码
        /// </summary>
        /// <param name="User">用户信息实体</param>
        public static void UserPwdUpdate(UserInfo User)
        {
            UserD = new UserDal();
            UserD.UserPwdUpdate(User);
        }
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="User">用户信息实体</param>
        public static void UserInsert(UserInfo User)
        {
            UserD = new UserDal();
            UserD.UserInsert(User);
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns>DateSet类型，返回用户信息数据集</returns>
        public static DataSet UserFill()
        {
            UserD = new UserDal();
            return UserD.UserFill();
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        public static void UserDelete()
        {
            UserD = new UserDal();
            UserD.UserUpdate();
        }
        /// <summary>
        /// 读取用户信息
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns>UserInfo类型，存储用户信息实体</returns>
        public static UserInfo UserRead(string UserID)
        {
            UserD = new UserDal();
            return UserD.UserRead(UserID);
        }
        /// <summary>
        /// 获取用户编号
        /// </summary>
        /// <param name="userName">用户姓名</param>
        /// <returns>string类型，返回字符串类型用户编号</returns>
        public static string GetUserID(string userName)
        {
            UserD = new UserDal();
            return UserD.GetUserID(userName);
        }
        /// <summary>
        /// 获取用户姓名
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns>string类型，返回字符串类型用户姓名</returns>
        public static string GetUserName(string UserID)
        {
            UserD = new UserDal();
            return UserD.GetUserName(UserID);
        }
        /// <summary>
        /// 判断是否存在用户
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns>bool类型，不存在返回true，存在返回false值</returns>
        public static bool GetUser(string UserID)
        {
            UserD = new UserDal();
            return UserD.GetUser(UserID);
        }
    }
}
