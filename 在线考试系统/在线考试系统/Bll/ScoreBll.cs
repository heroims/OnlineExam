using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using 在线考试系统.Dal;
using 在线考试系统.Model;
namespace 在线考试系统.Bll
{
    class ScoreBll
    {
        static ScoreDal sd = new ScoreDal();
        /// <summary>
        /// 获取用户成绩信息
        /// </summary>
        /// <param name="PaperID">试卷编号</param>
        /// <returns>DataSet类型，返回用户成绩信息数据集</returns>
        public static DataSet ScoreFillDs(string PaperID)
        {
            return sd.FillDs(PaperID);
        }
        /// <summary>
        /// 删除用户成绩信息
        /// </summary>
        /// <param name="PaperID">试卷编号</param>
        public static void ScoreDel(string PaperID)
        {
            sd.Delete(PaperID);
        }
        /// <summary>
        /// 添加用户成绩信息
        /// </summary>
        /// <param name="score">成绩实体集</param>
        public static void ScoreAdd(Score score)
        {
            sd.Add(score);
        }
        /// <summary>
        /// 获取试卷编号
        /// </summary>
        /// <param name="PaperName">试卷名称</param>
        /// <returns>int类型，返回整数类型的试卷编号</returns>
        public static int GetPaperID(string PaperName)
        {
            return sd.GetPaperID(PaperName);
        }
        /// <summary>
        /// 获取用户成绩信息
        /// </summary>
        /// <param name="PaperIDorExamTime">试卷编号 考试时间</param>
        /// <param name="type">选择查询类型</param>
        /// <param name="UserID">用户编号</param>
        /// <returns>DataSet类型，返回用户成绩信息</returns>
        public static DataSet UserScoreFillDs(string PaperIDorExamTime, string type, string UserID)
        {
            return sd.UserScoreFillDs(PaperIDorExamTime, type, UserID);
        }
    }
}
