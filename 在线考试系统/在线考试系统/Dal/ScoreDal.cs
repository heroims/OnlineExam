using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using 在线考试系统.Model;
namespace 在线考试系统.Dal
{
    class ScoreDal
    {
        SqlHelp SH = new SqlHelp();
        /// <summary>
        /// 获取用户成绩信息
        /// </summary>
        /// <param name="PaperID">试卷编号</param>
        /// <returns>DataSet类型，返回用户成绩信息数据集</returns>
        public DataSet FillDs(string PaperID)
        {
            string str = "select UserInfo.UserID,UserName,PaperID,Score,examTime,JudgeTime from UserInfo right join score on UserInfo.UserID=score.userID where 1=1";
            if (PaperID!="")
            {
                str += (" and PaperID=" + PaperID);
            }
            SH.SqlCom(str, CommandType.Text);
            return SH.SqlFillDs();
        }
        /// <summary>
        /// 删除用户成绩信息
        /// </summary>
        /// <param name="PaperID">试卷编号</param>
        public void Delete(string PaperID)
        {
            string str = "select ID from score where PaperID=@PaperID";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("PaperID", PaperID);
            string ID = SH.SqlES().ToString();
            str = "delete score where ID=@ID update score set ID-=1 where ID>@ID";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("ID", ID);
            SH.SqlENQ();
        }
        /// <summary>
        /// 添加用户成绩信息
        /// </summary>
        /// <param name="score">成绩实体集</param>
        public void Add(Score score)
        {
            string str = "select count(*) from score";
            SH.SqlCom(str, CommandType.Text);
            string ID = ((int)SH.SqlES()+1).ToString();
            str = "insert score values(@ID,@PaperID,@userID,@Score,@examTime,@JudgeTime)";
            SH.SqlCom(str, CommandType.Text);
            string[] str0 = { "@ID", "@PaperID", "@userID", "@Score", "@examTime", "@JudgeTime" };
            string[] str1 = { ID, score.PaperID.ToString(), score.UserID,score.Score0.ToString(), score.ExamTime.ToString(), score.JudgeTime.ToString() };
            SH.SqlPar(str0, str1);
            SH.SqlENQ();
        }
        /// <summary>
        /// 获取试卷编号
        /// </summary>
        /// <param name="PaperName">试卷名称</param>
        /// <returns>int类型，返回整数类型的试卷编号</returns>
        public int GetPaperID(string PaperName)
        {
            string str = "select PaperID from Paper where PaperName=@PaperName";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@PaperName", PaperName);
            return (int)SH.SqlES();
        }
        /// <summary>
        /// 获取用户成绩信息
        /// </summary>
        /// <param name="PaperIDorExamTime">试卷编号 考试时间</param>
        /// <param name="type">选择查询类型</param>
        /// <param name="UserID">用户编号</param>
        /// <returns>DataSet类型，返回用户成绩信息</returns>
        public DataSet UserScoreFillDs(string PaperIDorExamTime, string type, string UserID)
        {
            string str = "select score.* from score left join Paper on score.PaperID=Paper.PaperID where userID=@userID";
            if (type=="PaperID")
            {
                str += " and score.PaperID=@PaperID";
                SH.SqlCom(str, CommandType.Text);
                SH.SqlPar("@userID", UserID);
                SH.SqlPar("@PaperID", PaperIDorExamTime);
            }
            else if (type == "ExamTime")
            {
                str += " and score.examTime=@examTime";
                SH.SqlCom(str, CommandType.Text);
                SH.SqlPar("@userID", UserID);
                SH.SqlPar("@examTime", PaperIDorExamTime);
            }
            return SH.SqlFillDs();
        }
    }
}
