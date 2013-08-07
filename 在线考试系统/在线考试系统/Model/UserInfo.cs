using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 在线考试系统.Model
{
    public class UserInfo
    {
        #region 私有成员
        private string _userID;
        private string _userPwd;
        private string _userName;
        private int _roleId;
        private string _ID;
        #endregion
        #region 公有成员
        public string UserPwd
        {
            get { return _userPwd; }
            set { _userPwd = value; }
        }
        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public int RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        #endregion
        public UserInfo() { }
        public UserInfo(string userId, string userPwd)
        {
            UserID = userId;
            UserPwd = userPwd;
        }
        public UserInfo(string userId, string userPwd,string userName,int roleId)
        {
            UserID = userId;
            UserPwd = userPwd;
            UserName = userName;
            RoleId = roleId;
        }
    }
}
