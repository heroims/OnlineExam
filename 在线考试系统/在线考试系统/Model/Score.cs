using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 在线考试系统.Model
{
    class Score
    {
        #region 私有成员
        int _id;
        int _paperID;
        string _userID;
        double _score;
        DateTime _examTime;
        DateTime _judgeTime;
        #endregion
        #region 公有成员
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int PaperID
        {
            get { return _paperID; }
            set { _paperID = value; }
        }
        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        public double Score0
        {
            get { return _score; }
            set { _score = value; }
        }
        public DateTime ExamTime
        {
            get { return _examTime; }
            set { _examTime = value; }
        }
        public DateTime JudgeTime
        {
            get { return _judgeTime; }
            set { _judgeTime = value; }
        }
        #endregion
    }
}
