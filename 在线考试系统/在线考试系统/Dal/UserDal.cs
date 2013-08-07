using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using 在线考试系统.Model;
namespace 在线考试系统.Dal
{
    class UserDal
    {
        SqlHelp SH;
        /// <summary>
        /// 获取Command和Parmeter
        /// </summary>
        /// <param name="str">Command语句</param>
        /// <param name="User">用户信息实体</param>
        void UserNCP(string str,UserInfo User,CommandType ct)
        {
            SH = new SqlHelp();
            SH.SqlCom(str, ct);
            SH.SqlPar("@userID", User.UserID);
            SH.SqlPar("@userPwd", User.UserPwd);
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="User">用户信息实体</param>
        /// <returns>int类型，0表示有用户，1表示没有用户</returns>
        public int UserSelect(UserInfo User)
        {
            string str = "select RoleId from UserInfo where UserID=@userID and UserPwd=@userPwd";
            UserNCP(str, User,CommandType.Text);
            if (SH.SqlES()!=null)
            {
                return (int)SH.SqlES();
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 更新用户密码
        /// </summary>
        /// <param name="User">用户信息实体</param>
        public void UserPwdUpdate(UserInfo User)
        {
            string str = "update UserInfo set UserPwd=@userPwd where UserID=@userID";
            UserNCP(str, User, CommandType.Text);
            SH.SqlENQ();
        }
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="User">用户信息实体</param>
        public void UserInsert(UserInfo User)
        {
            string str = "insert UserInfo(UserID,UserName,UserPwd,RoleId) values(@userID,@userName,@userPwd,@roleId)";
            UserNCP(str, User, CommandType.Text);
            SH.SqlPar("@userID", User.ID);
            SH.SqlPar("@userName", User.UserName);
            SH.SqlPar("@userPwd", User.UserPwd);
            SH.SqlPar("@roleId", User.RoleId.ToString());
            SH.SqlENQ();
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns>DateSet类型，返回用户信息数据集</returns>
        public DataSet UserFill()
        {
            SH = new SqlHelp();
            string str = "select UserID,UserName,RoleId from UserInfo";
            SH.SqlCom(str, CommandType.Text);
            return SH.SqlFillDs();
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        public void UserUpdate()
        {
            SH = new SqlHelp();
            SH.SqlUpdate();
        }
        /// <summary>
        /// 读取用户信息
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns>UserInfo类型，存储用户信息实体</returns>
        public UserInfo UserRead(string UserID)
        {
            SH = new SqlHelp();
            string str = "select UserID,UserPwd,UserName,RoleId from UserInfo where UserID=@UserID";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@UserID", UserID);
            DataSet ds= SH.SqlFillDs();
            UserInfo user =new UserInfo( ds.Tables[0].Rows[0].ItemArray[0].ToString(), ds.Tables[0].Rows[0].ItemArray[1].ToString(), ds.Tables[0].Rows[0].ItemArray[2].ToString(), (int)ds.Tables[0].Rows[0].ItemArray[3] );
            return user;
        }
        /// <summary>
        /// 获取用户编号
        /// </summary>
        /// <param name="userName">用户姓名</param>
        /// <returns>string类型，返回字符串类型用户编号</returns>
        public string GetUserID(string userName)
        {
            SH = new SqlHelp();
            string str = "select UserID from UserInfo where UserName=@UserName";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@UserName", userName);
            return SH.SqlES().ToString();
        }
        /// <summary>
        /// 获取用户姓名
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns>string类型，返回字符串类型用户姓名</returns>
        public string GetUserName(string UserID)
        {
            SH = new SqlHelp();
            string str = "select UserName from UserInfo where UserID=@UserID";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@UserID", UserID);
            return SH.SqlES().ToString();
        }
        /// <summary>
        /// 判断是否存在用户
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns>bool类型，不存在返回true，存在返回false值</returns>
        public bool GetUser(string UserID)
        {
            string str = "select count(*) from UserInfo where UserID=@UserID";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@UserID", UserID);
            if ((int)SH.SqlES() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
