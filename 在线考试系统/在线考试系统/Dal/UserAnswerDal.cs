using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using 在线考试系统.Model;
namespace 在线考试系统.Dal
{
    class UserAnswerDal
    {
        SqlHelp SH = new SqlHelp();
        /// <summary>
        /// 获取用户答题答案信息
        /// </summary>
        /// <returns>DataSet类型，返回用户答题答案信息数据集</returns>
        public DataSet FillDs()
        {
            string str = "select distinct RANK()over(order by UserName) as ID,UserName,examTime,PaperID from UserAnswer inner join UserInfo on UserInfo.UserID=UserAnswer.userID";
            SH.SqlCom(str, CommandType.Text);
            return SH.SqlFillDs();
        }
        /// <summary>
        /// 删除用户答题答案信息
        /// </summary>
        /// <param name="UserName">用户名称</param>
        public void Delete(string UserName,string date)
        {
            UserDal user = new UserDal();
            string userID = user.GetUserID(UserName); ;
            string str = "delete UserAnswer where userID=@userID and examTime=@date";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@userID", userID);
            SH.SqlPar("@examTime", date);
            SH.SqlENQ();
        }
        /// <summary>
        /// 获取用户简答题答案信息临时表
        /// </summary>
        /// <param name="userID">用户编号</param>
        /// <returns>DataSet类型，返回用户简答题答案信息临时表数据集</returns>
        public DataSet QuestionFillDs(string userID, string date,string paperID)
        {
            string str = "if exists (select name from sysobjects where type='u' and name='a')drop table a select identity(int,1,1) as ID,Title,UserAnswer.answer as useranswer,questionProblem.answer,CAST('' as int) score into a from UserAnswer inner join questionProblem on UserAnswer.TitleID=questionProblem.ID where userID=@userID and examTime=@examTime and not exists(select *from score where userID=@userID and examTime=@examTime and PaperID=@paperID)";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@userID",userID);
            SH.SqlPar("@examTime", date);
            SH.SqlPar("@paperID", paperID);
            SH.SqlENQ();
            str = "select *from a";
            SH.SqlCom(str, CommandType.Text);
            return SH.SqlFillDs();
        }
        /// <summary>
        /// 评定并获取简答题总分
        /// </summary>
        /// <returns>int类型，返回整数类型的简答题总分</returns>
        public int QuestionSum()
        {
            string str = "select count(*) from a";
            SH.SqlCom(str, CommandType.Text);
            if ((int)SH.SqlES() == 0)
            {
                return 0;
            }
            else
            {
                SH.SqlUpdate();
                str = "select SUM(score) from a";
                SH.SqlCom(str, CommandType.Text);
                if (SH.SqlES().ToString() == "")
                {
                    return 0;
                }
                else
                {
                    return (int)SH.SqlES();
                }
            }
        }
        /// <summary>
        /// 删除用户简答题信息临时表
        /// </summary>
        public void QuestionDrop()
        {
            string str = "if exists (select name from sysobjects where type='u' and name='a')drop table a";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlENQ();
        }
        /// <summary>
        /// 获取单选题总分
        /// </summary>
        /// <param name="userID">用户编号</param>
        /// <returns>int类型，返回整数类型的单选题总分</returns>
        public int singleProblemSum(string userID, string date,string paperID)
        {
            string str = "select SUM(Mark) from UserAnswer left join singleProblem on UserAnswer.TitleID=singleProblem.ID where UserAnswer.answer=singleProblem.answer and Type=@Type and userID=@userID and examTime=@examTime and not exists(select *from score where userID=@userID and examTime=@examTime and PaperID=@paperID)";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@Type", "singleProblem");
            SH.SqlPar("@userID", userID);
            SH.SqlPar("@examTime", date);
            SH.SqlPar("@paperID", paperID);
            if (SH.SqlES().ToString() == "")
            {
                return 0;
            }
            else
            {
                return (int)SH.SqlES();
            }
        }
        /// <summary>
        /// 获取多选题总分
        /// </summary>
        /// <param name="userID">用户编号</param>
        /// <returns>int类型，返回整数类型的多选题总分</returns>
        public int multiProblemSum(string userID, string date, string paperID)
        {
            string str = "select SUM(Mark) from UserAnswer left join multiProblem on UserAnswer.TitleID=multiProblem.ID where UserAnswer.answer=multiProblem.answer and Type=@Type and userID=@userID and examTime=@examTime and not exists(select *from score where userID=@userID and examTime=@examTime and PaperID=@paperID)";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@Type", "multiProblem");
            SH.SqlPar("@userID", userID);
            SH.SqlPar("@examTime", date);
            SH.SqlPar("@paperID", paperID);
            if (SH.SqlES().ToString() == "")
            {
                return 0;
            }
            else
            {
                return (int)SH.SqlES();
            }
        }
        /// <summary>
        /// 获取判断题总分
        /// </summary>
        /// <param name="userID">用户编号</param>
        /// <returns>int类型，返回整数类型的判断题总分</returns>
        public int judgeProblemSum(string userID, string date, string paperID)
        {
            string str = "select SUM(Mark) from UserAnswer left join judgeProblem on UserAnswer.TitleID=judgeProblem.ID where UserAnswer.answer=CONVERT(varchar(1000) ,judgeProblem.answer) and Type=@Type and userID=@userID and examTime=@examTime and not exists(select *from score where userID=@userID and examTime=@examTime and PaperID=@paperID)";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@Type", "judgeProblem");
            SH.SqlPar("@userID", userID);
            SH.SqlPar("@examTime", date);
            SH.SqlPar("@paperID", paperID);
            if (SH.SqlES().ToString() == "")
            {
                return 0;
            }
            else
            {
                return (int)SH.SqlES();
            }
        }
        /// <summary>
        /// 获取填空题总分
        /// </summary>
        /// <param name="userID">用户编号</param>
        /// <returns>int类型，返回整数类型的填空题总分</returns>
        public int fillBlankProblemSum(string userID, string date, string paperID)
        {
            string str = "select SUM(Mark) from UserAnswer left join fillBlankProblem on UserAnswer.TitleID=fillBlankProblem.ID where UserAnswer.answer=fillBlankProblem.answer and Type=@Type and userID=@userID and examTime=@examTime and not exists(select *from score where userID=@userID and examTime=@examTime and PaperID=@paperID)";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@Type", "fillBlankProblem");
            SH.SqlPar("@userID", userID);
            SH.SqlPar("@examTime", date);
            SH.SqlPar("@paperID", paperID);
            if (SH.SqlES().ToString() == "")
            {
                return 0;
            }
            else
            {
                return (int)SH.SqlES();
            }
        }
        /// <summary>
        /// 获取用户考试试卷和考试时间
        /// </summary>
        /// <param name="userID">用户编号</param>
        /// <returns>UserAnswer类型，返回用户答案模板的信息</returns>
        public UserAnswer GetUserAnswer(string userID,string date,string paperID)
        {
            string str = "select distinct PaperName,UserAnswer.examTime from UserAnswer left join Paper on UserAnswer.PaperID=Paper.PaperID where userID=@userID and UserAnswer.examTime=@examTime and not exists(select *from score where userID=@userID and examTime=@examTime and PaperID=@paperID)";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@userID", userID);
            SH.SqlPar("@examTime", date);
            SH.SqlPar("@paperID", paperID);
            UserAnswer Answer = new UserAnswer();
            Answer.PaperName = SH.SqlFillDs().Tables[0].Rows[0].ItemArray[0].ToString();
            Answer.ExamTime = SH.SqlFillDs().Tables[0].Rows[0].ItemArray[1].ToString();
            return Answer;
        }
        /// <summary>
        /// 添加用户答案信息
        /// </summary>
        /// <param name="ua">用户答案实体集</param>
        public void AddUserAnswer(KeyValuePair<string,UserAnswer> ua)
        {
            string str = "select count(*) from UserAnswer";
            SH.SqlCom(str, CommandType.Text);
            int ID = (int)SH.SqlES() + 1;
            str = "insert UserAnswer values(@ID,@PaperID,@userID,@Type,@examTime,@TitleID,@Mark,@answer)";
            SH.SqlCom(str, CommandType.Text);
            string[] str0 = { "@ID", "@PaperID", "@userID", "@Type", "@examTime", "@TitleID", "@Mark", "@answer" };
            string[] str1 = { ID.ToString(), ua.Value.PaperID.ToString(), ua.Value.UserID, ua.Value.Type, ua.Value.ExamTime, ua.Value.TitleID.ToString(), ua.Value.Mark.ToString(), ua.Value.Answer };
            SH.SqlPar(str0, str1);
            SH.SqlENQ();
        }
    }
}
