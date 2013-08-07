using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace 在线考试系统.Dal
{
    class CourseDal
    {
        SqlHelp SH = new SqlHelp();
        /// <summary>
        /// 获取科目信息
        /// </summary>
        /// <returns>DataSet类型，返回科目信息数据集</returns>
        public DataSet FillDs()
        {
            string str = "select *from Course";
            SH.SqlCom(str, CommandType.Text);
            return SH.SqlFillDs();
        }
        /// <summary>
        /// 添加科目信息
        /// </summary>
        /// <param name="CName">string类型，表示科目名称</param>
        public void AddCou(string CName)
        {
            string str = "select count(*)from Course";
            SH.SqlCom(str, CommandType.Text);
            string CID = ((int)SH.SqlES() + 1).ToString();
            str = "insert Course values(@courseID,@courseName)";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@courseID", CID);
            SH.SqlPar("@courseName", CName);
            SH.SqlENQ();
        }
        /// <summary>
        /// 删除科目信息
        /// </summary>
        /// <param name="courseID">科目编号</param>
        public void DeleteCou(string courseID)
        {
            string str = "delete Course where courseID=@courseID";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@courseID", courseID);
            SH.SqlENQ();
            str = "update fillBlankProblem set courseID-=1 where courseID>@courseID";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@courseID", courseID);
            SH.SqlENQ();
        }
        /// <summary>
        /// 判断是否存在科目
        /// </summary>
        /// <param name="courseName">科目名称</param>
        /// <returns>bool类型，不存在返回true，存在返回false值</returns>
        public bool GetCourse(string courseName)
        {
            string str = "select count(*) from Course where courseName=@courseName";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@courseName", courseName);
            if ((int)SH.SqlES() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
