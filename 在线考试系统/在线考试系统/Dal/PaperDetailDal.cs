using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 在线考试系统.Model;
using System.Data;
namespace 在线考试系统.Dal
{
    class PaperDetailDal
    {
        SqlHelp SH = new SqlHelp();
        /// <summary>
        /// 添加试卷定制信息
        /// </summary>
        /// <param name="pd">试卷详细信息实体集的泛型集合</param>
        public void Add(List<PaperDetail> pd)
        {
            foreach (PaperDetail  a in pd)
            {
                string str = "select count(*) from PaperDetail";
                SH.SqlCom(str, CommandType.Text);
                string ID = ((int)SH.SqlES() + 1).ToString();
                str = "insert PaperDetail values(@ID,@PaperID,@type,@titleID,@Mark,@WriteTime)";
                string[] str0 = { "@ID", "@PaperID", "@type", "@titleID", "@Mark", "@WriteTime" };
                string[] str1 = { ID, a.PaperID.ToString(), a.Type, a.TitleID.ToString(), a.Mark.ToString(),a.WriteTime.ToString() };
                SH.SqlCom(str, CommandType.Text);
                SH.SqlPar(str0, str1);
                SH.SqlENQ();
            }
        }
        /// <summary>
        /// 获取试卷临时详细信息
        /// </summary>
        /// <param name="Type">试题类型</param>
        /// <returns>DataSet类型，返回试卷临时详细信息数据集</returns>
        public DataSet FillDs(List<PaperDetail> pd,string Type)
        {
            string str = "if exists (select name from sysobjects where type='u' and name='a')drop table a create table a(type varchar(50),titleID int,Mark int,WriteTime int)";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlENQ();
            foreach (PaperDetail a in pd)
            {
                str = "insert a values(@type,@titleID,@Mark,@WriteTime)";
                string[] str0 = { "@type", "@titleID", "@Mark", "@WriteTime" };
                string[] str1 = {  a.Type, a.TitleID.ToString(), a.Mark.ToString(), a.WriteTime.ToString() };
                SH.SqlCom(str, CommandType.Text);
                SH.SqlPar(str0, str1);
                SH.SqlES();
            }
            string strsql="";
            switch (Type)
            {
                case "singleProblem":
                    strsql = "select a.*,courseID,title,answerA,answerB,answerC,answerD,answer from a left join singleProblem on a.TitleID=singleProblem.ID where Type=@type";
                    break;
                case "multiProblem":
                    strsql = "select a.*,courseID,title,answerA,answerB,answerC,answerD,answer from a left join multiProblem on a.TitleID=multiProblem.ID where Type=@type";
                    break;
                case "judgeProblem":
                    strsql = "select a.*,courseID,title,answer from a left join judgeProblem on a.TitleID=judgeProblem.ID where Type=@type";
                    break;
                case "fillBlankProblem":
                    strsql = "select a.*,courseID,FrontTitle,backTitle,answer from a left join fillBlankProblem on a.TitleID=fillBlankProblem.ID where Type=@type";
                    break;
                case "questionProblem":
                    strsql = "select a.*,courseID,Title,answer from a left join questionProblem on a.TitleID=questionProblem.ID where Type=@type";
                    break;
                default:
                    break;
            }
            SH.SqlCom(strsql, CommandType.Text);
            SH.SqlPar("@type", Type);
            return SH.SqlFillDs();
        }
        /// <summary>
        /// 删除试卷临时详细信息
        /// </summary>
        public void DropPaper()
        {
            string str = "if exists (select name from sysobjects where type='u' and name='a')drop table a";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlENQ();
        }

        /// <summary>
        /// 获取用户使用的试卷详细信息
        /// </summary>
        /// <param name="PaperID">试卷编号</param>
        /// <param name="TitleID">题号</param>
        /// <returns>DataSet类型，返回用户使用的试卷试题详细信息的数据集</returns>
        public DataSet UserPaper(string PaperID)
        {
            string str = "select TitleID,title,answerA,answerB,answerC,answerD,answer,WriteTime,Mark from PaperDetail left join singleProblem on PaperDetail.TitleID=singleProblem.ID where Type='singleProblem' and PaperID=@PaperID and TitleID=singleProblem.ID"
                + " select TitleID,title,answerA,answerB,answerC,answerD,answer,WriteTime,Mark from PaperDetail left join multiProblem on PaperDetail.TitleID=multiProblem.ID where Type='multiProblem' and PaperID=@PaperID and TitleID=multiProblem.ID"
                + " select TitleID,title,answer,WriteTime,Mark from PaperDetail left join judgeProblem on PaperDetail.TitleID=judgeProblem.ID where Type='judgeProblem' and PaperID=@PaperID and TitleID=judgeProblem.ID"
                + " select TitleID,FrontTitle,backTitle,answer,WriteTime,Mark from PaperDetail left join fillBlankProblem on PaperDetail.TitleID=fillBlankProblem.ID where Type='fillBlankProblem' and PaperID=@PaperID and TitleID=fillBlankProblem.ID"
                + " select TitleID,Title,answer,WriteTime,Mark from PaperDetail left join questionProblem on PaperDetail.TitleID=questionProblem.ID where Type='questionProblem' and PaperID=@PaperID and TitleID=questionProblem.ID";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@PaperID", PaperID);
            return SH.SqlFillDs();
        }
        /// <summary>
        /// 获取打印试卷详细信息
        /// </summary>
        /// <param name="PaperID">试卷编号</param>
        /// <returns>DataSet类型，返回用户使用的试卷试题详细信息的数据集</returns>
        public DataSet UserPaperFillDs(string PaperName)
        {
            string str = "select PaperID from Paper where PaperName=@PaperName";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@PaperName", PaperName);
            string PaperID = SH.SqlES().ToString();
            str = "select title,answerA,answerB,answerC,answerD,answer,WriteTime,Mark from PaperDetail left join singleProblem on PaperDetail.TitleID=singleProblem.ID where Type='singleProblem' and PaperID=@PaperID"
                + " select title,answerA,answerB,answerC,answerD,answer,WriteTime,Mark from PaperDetail left join multiProblem on PaperDetail.TitleID=multiProblem.ID where Type='multiProblem' and PaperID=@PaperID"
                + " select title,answer,WriteTime,Mark from PaperDetail left join judgeProblem on PaperDetail.TitleID=judgeProblem.ID where Type='judgeProblem' and PaperID=@PaperID "
                + " select FrontTitle,backTitle,answer,WriteTime,Mark from PaperDetail left join fillBlankProblem on PaperDetail.TitleID=fillBlankProblem.ID where Type='fillBlankProblem' and PaperID=@PaperID"
                + " select Title,answer,WriteTime,Mark from PaperDetail left join questionProblem on PaperDetail.TitleID=questionProblem.ID where Type='questionProblem' and PaperID=@PaperID";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@PaperID", PaperID);
            return SH.SqlFillDs();
        }
        /// <summary>
        /// 获取题目个数
        /// </summary>
        /// <param name="PaperID">试卷编号</param>
        /// <param name="Type">考题类型</param>
        /// <returns>int类型，返回整数类型的题目个数</returns>
        public int GetQuestionCount(string PaperID, string Type)
        {
            string str = "select count(titleID) from PaperDetail where PaperID=@PaperID and @type=Type";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@PaperID", PaperID);
            switch (Type)
            {
                case "singleProblem":
                    SH.SqlPar("@type", Type);
                    break;
                case "multiProblem":
                    SH.SqlPar("@type", Type);
                    break;
                case "judgeProblem":
                    SH.SqlPar("@type", Type);
                    break;
                case "fillBlankProblem":
                    SH.SqlPar("@type", Type);
                    break;
                case "questionProblem":
                    SH.SqlPar("@type", Type);
                    break;
                default:
                    break;
            }
            return (int)SH.SqlES();
        }
    }
}
