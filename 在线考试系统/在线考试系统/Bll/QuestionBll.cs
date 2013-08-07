using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using 在线考试系统.Dal;
using 在线考试系统.Model;
namespace 在线考试系统.Bll
{
    class QuestionBll
    {
        static QuestionDal question=new QuestionDal();
        /// <summary>
        /// 更新题库信息
        /// </summary>
        public static void QuestionUpdate()
        {
            question.Update();
        }
        /// <summary>
        /// 获取题库信息
        /// </summary>
        /// <returns>DataSet类型，返回单选题，多选题，判断题，填空题，简答题的数据集</returns>
        public static DataSet QuestionFillDs()
        {
            return question.FillDs();
        }
        /// <summary>
        /// 获取填空题个数
        /// </summary>
        /// <param name="courseID">科目编号</param>
        /// <returns>int类型，返回整数类型填空题个数</returns>
        public static int fillBlankCount(string courseID)
        {
            return question.fillBlankCount(courseID);
        }
        /// <summary>
        /// 获取单选题个数
        /// </summary>
        /// <param name="courseID">科目编号</param>
        /// <returns>int类型，返回整数类型单选题个数</returns>
        public static int singleCount(string courseID)
        {
            return question.singleCount(courseID);
        }
        /// <summary>
        /// 获取多选题个数
        /// </summary>
        /// <param name="courseID">科目编号</param>
        /// <returns>int类型，返回整数类型多选题个数</returns>
        public static int multiCount(string courseID)
        {
            return question.multiCount(courseID);
        }
        /// <summary>
        /// 获取判断题个数
        /// </summary>
        /// <param name="courseID">科目编号</param>
        /// <returns>int类型，返回整数类型判断题个数/returns>
        public static int judgeCount(string courseID)
        {
            return question.judgeCount(courseID);
        }
        /// <summary>
        /// 获取简答题个数
        /// </summary>
        /// <param name="courseID">科目编号</param>
        /// <returns>int类型，返回整数类型简答题个数</returns>
        public static int questionCount(string courseID)
        {
            return question.questionCount(courseID);
        }
        /// <summary>
        /// 添加填空题信息
        /// </summary>
        /// <param name="fbp">填空题实体集</param>
        public static void AddfillBlankProblem(fillBlankProblem fbp)
        {
            question.AddfillBlankProblem(fbp);
        }
        /// <summary>
        /// 添加单选题信息
        /// </summary>
        /// <param name="smp">选择题实体集</param>
        public static void AddsingleProblem(SingleMultiProblem smp)
        {
            question.AddsingleProblem(smp);
        }
        /// <summary>
        /// 添加多选题信息
        /// </summary>
        /// <param name="smp">选择题实体集</param>
        public static void AddmultiProblem(SingleMultiProblem smp)
        {
            question.AddmultiProblem(smp);
        }
        /// <summary>
        /// 添加判断题信息
        /// </summary>
        /// <param name="jqp">判断题实体集</param>
        public static void AddjudgeProblem(JudgeQuestionProblem jqp)
        {
            question.AddjudgeProblem(jqp);
        }
        /// <summary>
        /// 添加简答题信息
        /// </summary>
        /// <param name="jqp">判断题实体集</param>
        public static void AddquestionProblem(JudgeQuestionProblem jqp)
        {
            question.AddquestionProblem(jqp);
        }
        /// <summary>
        /// 删除题目信息
        /// </summary>
        /// <param name="dgv">显示数据</param>
        /// <param name="Question">题目类型</param>
        public static void Delete(DataGridView dgv, string Question)
        {
            if (dgv.CurrentCell != null)
            {
                if (MessageBox.Show("是否删除记录！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        switch (Question)
                        {
                            case "单选题":
                                question.DeletesingleProblem(dgv.CurrentRow.Cells[0].Value.ToString());
                                break;
                            case "多选题":
                                question.DeletemultiProblem(dgv.CurrentRow.Cells[0].Value.ToString());
                                break;
                            case "判断题":
                                question.DeletejudgeProblem(dgv.CurrentRow.Cells[0].Value.ToString());
                                break;
                            case "填空题":
                                question.DeletefillBlankProblem(dgv.CurrentRow.Cells[0].Value.ToString());
                                break;
                            case "问答题":
                                question.DeletequestionProblem(dgv.CurrentRow.Cells[0].Value.ToString());
                                break;
                            default:
                                break;
                        }
                        MessageBox.Show("删除成功！");
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("删除失败！" + ee);
                        throw;
                    }
                }
            }
        }
    }
}
