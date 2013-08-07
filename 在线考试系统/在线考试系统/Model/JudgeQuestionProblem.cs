using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 在线考试系统.Model
{
    class JudgeQuestionProblem
    {
        #region 私有成员
        string _courseID;
        string _tID;
        string _title;
        string _answer;
        string _writeTime;
        string _mark; 
        #endregion
        #region 公有成员
        public string CourseID
        {
            get { return _courseID; }
            set { _courseID = value; }
        }
        public string WriteTime
        {
            get { return _writeTime; }
            set { _writeTime = value; }
        }
        public string Mark
        {
            get { return _mark; }
            set { _mark = value; }
        }
        public string TID
        {
            get { return _tID; }
            set { _tID = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Answer
        {
            get { return _answer; }
            set { _answer = value; }
        }
        #endregion
        public JudgeQuestionProblem() { }
        public JudgeQuestionProblem(string courseID, string title, string answer)
        {
            _courseID = courseID;
            _title = title;
            _answer = answer;
        }
        public JudgeQuestionProblem(string tID, string title, string answer,string writeTime,string mark)
        {
            _tID = tID;
            _title = title;
            _answer = answer;
            _writeTime = writeTime;
            _mark = mark;
        }
    }
}
