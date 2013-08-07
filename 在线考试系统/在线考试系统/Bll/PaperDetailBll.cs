using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using 在线考试系统.Model;
using 在线考试系统.Dal;
namespace 在线考试系统.Bll
{
    class PaperDetailBll
    { 
        static PaperDetailDal pdd = new PaperDetailDal();
        public static List<fillBlankProblem> fbp = null;
        public static List<SingleMultiProblem> sp = null;
        public static List<SingleMultiProblem> mp = null;
        public static List<JudgeQuestionProblem> jp = null;
        public static List<JudgeQuestionProblem> qp = null;

        /// <summary>
        /// 添加试卷定制信息
        /// </summary>
        /// <param name="pd">试卷详细信息实体集的泛型集合</param>
        public static void PaperDetailAdd(List<PaperDetail> pd)
        {
            pdd.Add(pd);
        }
        /// <summary>
        /// 获取试卷临时详细信息
        /// </summary>
        /// <param name="Type">试题类型</param>
        /// <returns>DataSet类型，返回试卷临时详细信息数据集</returns>
        public static DataSet PaperDetailFillDs(List<PaperDetail> pd,string Type)
        {
            return pdd.FillDs(pd,Type);
        }
         /// <summary>
        /// 删除试卷临时详细信息
        /// </summary>
        public static void DropPaper()
        {
            pdd.DropPaper();
        }

        /// <summary>
        /// 获取用户使用的试卷详细信息
        /// </summary>
        /// <param name="PaperID">试卷编号</param>
        /// <param name="TitleID">题号</param>
        /// <returns>DataSet类型，返回用户使用的试卷试题详细信息的数据集</returns>
        public static void UserPaperFillDs(string PaperID)
        {
            if (pdd.UserPaper(PaperID).Tables[0].Rows.Count != 0)
            {
                sp = new List<SingleMultiProblem>();
                foreach (DataRow a in pdd.UserPaper(PaperID).Tables[0].Rows)
                {
                    sp.Add(new SingleMultiProblem(a.ItemArray[0].ToString(), a.ItemArray[1].ToString(), a.ItemArray[2].ToString(), a.ItemArray[3].ToString(), a.ItemArray[4].ToString(), a.ItemArray[5].ToString(), a.ItemArray[6].ToString(), a.ItemArray[7].ToString(), a.ItemArray[8].ToString()));
                }
            }
            if (pdd.UserPaper(PaperID).Tables[1].Rows.Count != 0)
            {
                mp = new List<SingleMultiProblem>();
                foreach (DataRow a in pdd.UserPaper(PaperID).Tables[1].Rows)
                {
                    mp.Add(new SingleMultiProblem(a.ItemArray[0].ToString(), a.ItemArray[1].ToString(), a.ItemArray[2].ToString(), a.ItemArray[3].ToString(), a.ItemArray[4].ToString(), a.ItemArray[5].ToString(), a.ItemArray[6].ToString(), a.ItemArray[7].ToString(), a.ItemArray[8].ToString()));
                }
            }
            if (pdd.UserPaper(PaperID).Tables[2].Rows.Count != 0)
            {
                jp=new List<JudgeQuestionProblem>();
                foreach (DataRow a in pdd.UserPaper(PaperID).Tables[2].Rows)
                {
                    jp.Add(new JudgeQuestionProblem(a.ItemArray[0].ToString(), a.ItemArray[1].ToString(), a.ItemArray[2].ToString(), a.ItemArray[3].ToString(), a.ItemArray[4].ToString()));
                }
            }
            if (pdd.UserPaper(PaperID).Tables[3].Rows.Count != 0)
            {
                fbp = new List<fillBlankProblem>();
                foreach (DataRow a in pdd.UserPaper(PaperID).Tables[3].Rows)
                {
                    fbp.Add(new fillBlankProblem(a.ItemArray[0].ToString(), a.ItemArray[1].ToString(), a.ItemArray[2].ToString(), a.ItemArray[3].ToString(), a.ItemArray[4].ToString(), a.ItemArray[5].ToString()));
                }
            } 
            if (pdd.UserPaper(PaperID).Tables[4].Rows.Count != 0)
            {
                qp = new List<JudgeQuestionProblem>();
                foreach (DataRow a in pdd.UserPaper(PaperID).Tables[4].Rows)
                {
                    qp.Add(new JudgeQuestionProblem(a.ItemArray[0].ToString(), a.ItemArray[1].ToString(), a.ItemArray[2].ToString(), a.ItemArray[3].ToString(), a.ItemArray[4].ToString()));
                }
            }
        }
        /// <summary>
        /// 获取打印的试卷详细信息
        /// </summary>
        /// <param name="PaperID">试卷编号</param>
        /// <returns>DataSet类型，返回用户使用的试卷试题详细信息的数据集</returns>
        public static DataSet PaperFillDs(string PaperID)
        {
            return pdd.UserPaperFillDs(PaperID);
        }
        /// <summary>
        /// 获取题目个数
        /// </summary>
        /// <param name="PaperID">试卷编号</param>
        /// <param name="Type">考题类型</param>
        /// <returns>int类型，返回整数类型的题目个数</returns>
        public static int GetQuestionCount(string PaperID, string Type) 
        {
            return pdd.GetQuestionCount(PaperID, Type);
        }
    }
}
