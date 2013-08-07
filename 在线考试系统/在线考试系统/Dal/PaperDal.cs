using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace 在线考试系统.Dal
{
    class PaperDal
    {
        SqlHelp SH = new SqlHelp();
        /// <summary>
        /// 获取试卷信息数据集
        /// </summary>
        /// <returns>DataSet类型，表示试卷信息数据集</returns>
        public DataSet FillDs()
        {
            string str = "select PaperID,PaperName from Paper select courseName,PaperName,PaperState from Paper left join Course on Paper.courseID=Course.courseID";
            SH.SqlCom(str, CommandType.Text);
            return SH.SqlFillDs();
        }
        /// <summary>
        /// 删除试卷信息
        /// </summary>
        /// <param name="PaperName">试卷名称</param>
        public void Delete(string PaperName)
        {
            string str = "delete Paper where PaperName=@PaperName";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@PaperName", PaperName);
            SH.SqlENQ();
        }
        /// <summary>
        /// 添加试卷信息
        /// </summary>
        /// <param name="PaperName">试卷名称</param>
        /// <param name="courseID">科目编号</param>
        public void Add(string PaperName,string courseID)
        {
            string str = "select count(*) from Paper";
            SH.SqlCom(str, CommandType.Text);
            string PaperID = ((int)SH.SqlES() + 1).ToString();
            str = "insert Paper values(@PaperID,@courseID,@PaperName,@PaperState,@ExamTime)";
            SH.SqlCom(str, CommandType.Text);
            string[] str0={"@PaperID","@courseID","@PaperName","@PaperState","@ExamTime"};
            string[] str1={PaperID,courseID,PaperName,"0",DateTime.Now.ToString()};
            SH.SqlPar(str0, str1);
            SH.SqlENQ();
        }
        /// <summary>
        /// 判断是否存在试卷
        /// </summary>
        /// <param name="PaperName">试卷名称</param>
        /// <returns>bool类型，不存在返回true，存在返回false值</returns>
        public bool GetPaper(string PaperName)
        {
            string str = "select count(PaperID) from Paper where PaperName=@PaperName";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@PaperName", PaperName);
            if ((int)SH.SqlES() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取试卷编号
        /// </summary>
        /// <param name="PaperName">试卷名称</param>
        /// <returns>int类型，返回整数类型的试卷编号</returns>
        public int GetPaperID(string PaperName)
        {
            string str = "select count(*) from Paper";
            SH.SqlCom(str, CommandType.Text);
            return (int)SH.SqlES()+1;
        }
    }
}
