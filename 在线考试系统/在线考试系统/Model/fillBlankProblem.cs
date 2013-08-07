using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 在线考试系统.Model
{
    class fillBlankProblem
    {
        #region 私有成员
        string _courseID;
        string _tID;
        string _frontTitle;
        string _backTitle;
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
        public string FrontTitle
        {
            get { return _frontTitle; }
            set { _frontTitle = value; }
        }
        public string BackTitle
        {
            get { return _backTitle; }
            set { _backTitle = value; }
        }
        public string Answer
        {
            get { return _answer; }
            set { _answer = value; }
        }
        #endregion
        public fillBlankProblem() { }
        public fillBlankProblem(string courseID, string frontTitle, string backTitle, string answer)
        {
            _courseID = courseID;
            _frontTitle = frontTitle;
            _backTitle = backTitle;
            _answer = answer;
        }
        public fillBlankProblem(string tID, string frontTitle, string backTitle, string answer,string writeTime,string mark)
        {
            _tID = tID;
            _frontTitle = frontTitle;
            _backTitle = backTitle;
            _answer = answer;
            _writeTime = writeTime;
            _mark = mark;
        }
    }
}
