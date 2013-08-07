using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 在线考试系统.Model
{
    public class UserAnswer
    {
        #region 私有成员
        string _userID;
        int _paperID;
        string _paperName;
        string _type;
        string _examTime;
        int _singleProblem;
        int _multiProblem;
        int _judgeProblem;
        int _fillBlankProblem;
        int _questionProblem;
        int _titleID;
        int _mark;
        int _sign;
        string _answer;
        string _id;
        #endregion
        #region 公有成员        
        public string Answer
        {
            get { return _answer; }
            set { _answer = value; }
        }
        public int Mark
        {
            get { return _mark; }
            set { _mark = value; }
        } 
        public int TitleID
        {
            get { return _titleID; }
            set { _titleID = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        public int PaperID
        {
            get { return _paperID; }
            set { _paperID = value; }
        }
        public string PaperName
        {
            get { return _paperName; }
            set { _paperName = value; }
        }
        public string ExamTime
        {
            get { return _examTime; }
            set { _examTime = value; }
        }
        public int SingleProblem
        {
            get { return _singleProblem; }
            set { _singleProblem = value; }
        }
        public int MultiProblem
        {
            get { return _multiProblem; }
            set { _multiProblem = value; }
        }
        public int JudgeProblem
        {
            get { return _judgeProblem; }
            set { _judgeProblem = value; }
        }
        public int FillBlankProblem
        {
            get { return _fillBlankProblem; }
            set { _fillBlankProblem = value; }
        }
        public int QuestionProblem
        {
            get { return _questionProblem; }
            set { _questionProblem = value; }
        }
        public int Sign
        {
            get { return _sign; }
            set { _sign = value; }
        }
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion
        public UserAnswer() { }
        public UserAnswer(int paperID, string userID, string type, string examTime, int titleID, int mark, string answer,int sign,string id)
        {
            _paperID = paperID;
            _userID = userID;
            _type = type;
            _examTime = examTime;
            _titleID = titleID;
            _mark = mark;
            _answer = answer;
            _sign = sign;
            _id = Id;
        }
    }
}
