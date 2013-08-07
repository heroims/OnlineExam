using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using 在线考试系统.Dal;
namespace 在线考试系统.Bll
{
    class PaperBll
    {
        static PaperDal paper = new PaperDal();
        /// <summary>
        /// 获取试卷信息数据集
        /// </summary>
        /// <returns>DataSet类型，表示试卷信息数据集</returns>
        public static DataSet PaperFillDs()
        {
            return paper.FillDs();
        }
        /// <summary>
        /// 绑定ComboBox
        /// </summary>
        /// <param name="cbo">将要绑定的ComboBox</param>
        public static void FillcboPaper(ComboBox cbo)
        {
            cbo.ValueMember = "PaperID";
            cbo.DisplayMember = "PaperName";
            cbo.DataSource = PaperFillDs().Tables[0];
        }
        /// <summary>
        /// 删除试卷信息
        /// </summary>
        /// <param name="PaperName">试卷名称</param>
        public static void DelPaper(string PaperName)
        {
            paper.Delete(PaperName);
        }
        /// <summary>
        /// 添加试卷信息
        /// </summary>
        /// <param name="PaperName">试卷名称</param>
        /// <param name="courseID">科目编号</param>
        public static void AddPaper(string PaperName, string courseID)
        {
            paper.Add(PaperName, courseID);
        }
        /// <summary>
        /// 获取试卷编号
        /// </summary>
        /// <param name="PaperName">试卷名称</param>
        /// <returns>int类型，返回整数类型的试卷编号</returns>
        public static int GetPaperID(string PaperName)
        {
            return paper.GetPaperID(PaperName);
        }
        /// <summary>
        /// 判断是否存在试卷
        /// </summary>
        /// <param name="PaperName">试卷名称</param>
        /// <returns>bool类型，不存在返回true，存在返回false值</returns>
        public static bool GetPaper(string PaperName)
        {
            return paper.GetPaper(PaperName);
        }
    }
}
