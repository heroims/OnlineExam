using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using 在线考试系统.Model;
namespace 在线考试系统.Dal
{
    class QuestionDal
    {
        SqlHelp SH = new SqlHelp();
        /// <summary>
        /// 更新题库信息
        /// </summary>
        public void Update()
        {
            SH.SqlUpdate();
        }

        /// <summary>
        /// 获取题库信息
        /// </summary>
        /// <returns>DataSet类型，返回单选题，多选题，判断题，填空题，简答题的数据集</returns>
        public DataSet FillDs()
        {
            string str = "select*from singleProblem select*from multiProblem select*from judgeProblem select*from fillBlankProblem select*from questionProblem";
            SH.SqlCom(str, CommandType.Text);
            return SH.SqlFillDs();
        }
        /// <summary>
        /// 添加填空题信息
        /// </summary>
        /// <param name="courseID">课程编号</param>
        /// <param name="FrontTitle">前描述</param>
        /// <param name="backTitle">后描述</param>
        /// <param name="answer">正确答案</param>
        public void AddfillBlankProblem(fillBlankProblem fbp)
        {
            string str = "select count(*)from fillBlankProblem";
            SH.SqlCom(str, CommandType.Text);
            string ID = ((int)SH.SqlES() + 1).ToString();
            str = "insert fillBlankProblem values(@ID,@courseID,@FrontTitle,@backTitle,@answer)";
            SH.SqlCom(str, CommandType.Text);
            string[] str0={"@ID","@courseID","@FrontTitle","@backTitle","@answer"};
            string[] str1 = { ID, fbp.CourseID, fbp.FrontTitle, fbp.BackTitle, fbp.Answer };
            SH.SqlPar(str0,str1);
            SH.SqlENQ();
        }
        /// <summary>
        /// 删除填空题信息
        /// </summary>
        /// <param name="ID">题目号</param>
        public void DeletefillBlankProblem(string ID)
        {
            string str = "delete fillBlankProblem where ID=@ID update fillBlankProblem set ID-=1 where ID>@ID";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@ID", ID);
            SH.SqlENQ();
        }
        /// <summary>
        /// 添加单选题信息
        /// </summary>
        /// <param name="courseID">课程编号</param>
        /// <param name="title">题目</param>
        /// <param name="answerA">选项A</param>
        /// <param name="answerB">选项B</param>
        /// <param name="answerC">选项C</param>
        /// <param name="answerD">选项D</param>
        /// <param name="answer">正确答案</param>
        public void AddsingleProblem(SingleMultiProblem smp)
        {
            string str = "select count(*)from singleProblem";
            SH.SqlCom(str, CommandType.Text);
            string ID = ((int)SH.SqlES() + 1).ToString();
            str = "insert singleProblem values(@ID,@courseID,@title,@answerA,@answerB,@answerC,@answerD,@answer)";
            SH.SqlCom(str, CommandType.Text);
            string[] str0 = { "@ID", "@courseID", "@title", "@answerA", "@answerB", "@answerC", "@answerD", "@answer" };
            string[] str1 = { ID, smp.CourseID, smp.Title, smp.AnswerA, smp.AnswerB, smp.AnswerC, smp.AnswerD, smp.Answer };
            SH.SqlPar(str0, str1);
            SH.SqlENQ();
        }
        /// <summary>
        /// 删除单选题信息
        /// </summary>
        /// <param name="ID">题目号</param>
        public void DeletesingleProblem(string ID)
        {
            string str = "delete singleProblem where ID=@ID update singleProblem set ID-=1 where ID>@ID";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@ID", ID);
            SH.SqlENQ();;
        }
        /// <summary>
        /// 添加多选题信息
        /// </summary>
        /// <param name="courseID">课程编号</param>
        /// <param name="title">题目</param>
        /// <param name="answerA">选项A</param>
        /// <param name="answerB">选项B</param>
        /// <param name="answerC">选项C</param>
        /// <param name="answerD">选项D</param>
        /// <param name="answer">正确答案</param>
        public void AddmultiProblem(SingleMultiProblem smp)
        {
            string str = "select count(*)from multiProblem";
            SH.SqlCom(str, CommandType.Text);
            string ID = ((int)SH.SqlES() + 1).ToString();
            str = "insert multiProblem values(@ID,@courseID,@title,@answerA,@answerB,@answerC,@answerD,@answer)";
            SH.SqlCom(str, CommandType.Text);
            string[] str0 = { "@ID", "@courseID", "@title","@answerA","@answerB","@answerC", "@answerD", "@answer" };
            string[] str1 = { ID, smp.CourseID, smp.Title, smp.AnswerA, smp.AnswerB, smp.AnswerC, smp.AnswerD, smp.Answer };
            SH.SqlPar(str0, str1);
            SH.SqlENQ();
        }
        /// <summary>
        /// 删除多选题信息
        /// </summary>
        /// <param name="ID">题目号</param>
        public void DeletemultiProblem(string ID)
        {
            string str = "delete multiProblem where ID=@ID update multiProblem set ID-=1 where ID>@ID";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@ID", ID);
            SH.SqlENQ();
        }
        /// <summary>
        /// 添加判断题信息
        /// </summary>
        /// <param name="courseID">课程编号</param>
        /// <param name="title">题目</param>
        /// <param name="answer">正确答案</param>
        public void AddjudgeProblem(JudgeQuestionProblem jqp)
        {
            string str = "select count(*)from judgeProblem";
            SH.SqlCom(str, CommandType.Text);
            string ID = ((int)SH.SqlES() + 1).ToString();
            str = "insert judgeProblem values(@ID,@courseID,@title,@answer)";
            SH.SqlCom(str, CommandType.Text);
            string[] str0 = { "@ID", "@courseID", "@title", "@answer" };
            string[] str1 = { ID, jqp.CourseID, jqp.Title, jqp.Answer };
            SH.SqlPar(str0, str1);
            SH.SqlENQ();
        }
        /// <summary>
        /// 删除判断题信息
        /// </summary>
        /// <param name="ID">题目号</param>
        public void DeletejudgeProblem(string ID)
        {
            string str = "delete judgeProblem where ID=@ID update judgeProblem set ID-=1 where ID>@ID";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@ID", ID);
            SH.SqlENQ();
        }
        /// <summary>
        /// 添加简答题信息
        /// </summary>
        /// <param name="courseID">课程编号</param>
        /// <param name="title">题目</param>
        /// <param name="answer">正确答案</param>
        public void AddquestionProblem(JudgeQuestionProblem jqp)
        {
            string str = "select count(*)from questionProblem";
            SH.SqlCom(str, CommandType.Text);
            string ID = ((int)SH.SqlES() + 1).ToString();
            str = "insert questionProblem values(@ID,@courseID,@title,@answer)";
            SH.SqlCom(str, CommandType.Text);
            string[] str0 = { "@ID", "@courseID", "@title", "@answer" };
            string[] str1 = { ID, jqp.CourseID, jqp.Title, jqp.Answer };
            SH.SqlPar(str0, str1);
            SH.SqlENQ();
        }
        /// <summary>
        /// 删除简答题信息
        /// </summary>
        /// <param name="ID">题目号</param>
        public void DeletequestionProblem(string ID)
        {
            string str = "delete questionProblem where ID=@ID update questionProblem set ID-=1 where ID>@ID";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@ID", ID);
            SH.SqlENQ();
        }
        /// <summary>
        /// 获取填空题个数
        /// </summary>
        /// <param name="courseID">科目编号</param>
        /// <returns>int类型，返回整数类型填空题个数</returns>
        public int fillBlankCount(string courseID)
        {
            string str = "select count(*)from fillBlankProblem where courseID=@courseID";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@courseID", courseID);
            return (int)SH.SqlES();
        }
        /// <summary>
        /// 获取单选题个数
        /// </summary>
        /// <param name="courseID">科目编号</param>
        /// <returns>int类型，返回整数类型单选题个数</returns>
        public int singleCount(string courseID)
        {
            string str = "select count(*)from singleProblem where courseID=@courseID";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@courseID", courseID);
            return (int)SH.SqlES();
        }
        /// <summary>
        /// 获取多选题个数
        /// </summary>
        /// <param name="courseID">科目编号</param>
        /// <returns>int类型，返回整数类型多选题个数</returns>
        public int multiCount(string courseID)
        {
            string str = "select count(*)from multiProblem where courseID=@courseID";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@courseID", courseID);
            return (int)SH.SqlES();
        }
        /// <summary>
        /// 获取判断题个数
        /// </summary>
        /// <param name="courseID">科目编号</param>
        /// <returns>int类型，返回整数类型判断题个数</returns>
        public int judgeCount(string courseID)
        {
            string str = "select count(*)from judgeProblem where courseID=@courseID";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@courseID", courseID);
            return (int)SH.SqlES();
        }
        /// <summary>
        /// 获取简答题个数
        /// </summary>
        /// <param name="courseID">科目编号</param>
        /// <returns>int类型，返回整数类型简答题个数</returns>
        public int questionCount(string courseID)
        {
            string str = "select count(*)from questionProblem where courseID=@courseID";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@courseID", courseID);
            return (int)SH.SqlES();
        }
    }
}
