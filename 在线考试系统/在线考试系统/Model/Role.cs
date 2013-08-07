using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 在线考试系统.Model
{
    class Role
    {
        #region 私有成员
        int _roleID;
        int _userManage;
        int _role;
        int _userScore;
        int _courseManage;
        int _paperSetup;
        int _paperLists;
        int _userPaperList;
        int _questionManage;
        #endregion
        #region 公有成员
        public int RoleID
        {
            get { return _roleID; }
            set { _roleID = value; }
        }
        public int Role1
        {
            get { return _role; }
            set { _role = value; }
        }
        public int UserManage
        {
            get { return _userManage; }
            set { _userManage = value; }
        }
        public int UserScore
        {
            get { return _userScore; }
            set { _userScore = value; }
        }
        public int CourseManage
        {
            get { return _courseManage; }
            set { _courseManage = value; }
        }
        public int PaperSetup
        {
            get { return _paperSetup; }
            set { _paperSetup = value; }
        }
        public int PaperLists
        {
            get { return _paperLists; }
            set { _paperLists = value; }
        }
        public int UserPaperList
        {
            get { return _userPaperList; }
            set { _userPaperList = value; }
        }
        public int QuestionManage
        {
            get { return _questionManage; }
            set { _questionManage = value; }
        }
        #endregion
    }
}
