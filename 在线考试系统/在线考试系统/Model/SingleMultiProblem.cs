using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 在线考试系统.Model
{
    class SingleMultiProblem
    {
        #region 私有成员
        string _courseID;
        string _tID;
        string _title;
        string _answerA;
        string _answerB;
        string _answerC;
        string _answerD;
        string _answer;
        string _writeTime;
        string _mark;   
        #endregion
        #region 公有成员
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
        public string CourseID
        {
            get { return _courseID; }
            set { _courseID = value; }
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
        public string AnswerA
        {
            get { return _answerA; }
            set { _answerA = value; }
        }
        public string AnswerB
        {
            get { return _answerB; }
            set { _answerB = value; }
        }
        public string AnswerC
        {
            get { return _answerC; }
            set { _answerC = value; }
        }
        public string AnswerD
        {
            get { return _answerD; }
            set { _answerD = value; }
        }
        public string Answer
        {
            get { return _answer; }
            set { _answer = value; }
        }
        #endregion
        public SingleMultiProblem() { }
        public SingleMultiProblem(string courseID, string title, string answerA, string answerB, string answerC, string answerD, string answer)
        {
            _courseID = courseID;
            _title = title;
            _answerA = answerA;
            _answerB = answerB;
            _answerC = answerC;
            _answerD = answerD;
            _answer = answer;
        }
        public SingleMultiProblem(string tID, string title, string answerA, string answerB, string answerC, string answerD, string answer,string writeTime,string mark)
        {
            _tID = tID;
            _title = title;
            _answerA = answerA;
            _answerB = answerB;
            _answerC = answerC;
            _answerD = answerD;
            _answer = answer;
            _writeTime=writeTime;
            _mark=mark;
        }
    }
}
