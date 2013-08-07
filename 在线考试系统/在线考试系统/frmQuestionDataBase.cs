using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 在线考试系统.Bll;
namespace 在线考试系统
{
    public partial class frmQuestionDataBase : Form
    {
        public frmQuestionDataBase()
        {
            InitializeComponent();
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region 添加 删除事件
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            switch (tabConQustion.SelectedTab.Text)
            {
                case "单选题":
                    frmSingleSelectAdd fssa = new frmSingleSelectAdd();
                    fssa.ShowDialog();
                    dataGridView1.DataSource = QuestionBll.QuestionFillDs().Tables[0];
                    break;
                case "多选题":
                    frmMultiSelectAdd fmsa = new frmMultiSelectAdd();
                    fmsa.ShowDialog();
                    dataGridView2.DataSource = QuestionBll.QuestionFillDs().Tables[1];
                    break;
                case "判断题":
                    frmJudgeAdd fja = new frmJudgeAdd();
                    fja.ShowDialog();
                    dataGridView3.DataSource = QuestionBll.QuestionFillDs().Tables[2];
                    break;
                case "填空题":
                    frmFillBlankAdd ffba = new frmFillBlankAdd();
                    ffba.ShowDialog();
                    dataGridView4.DataSource = QuestionBll.QuestionFillDs().Tables[3];
                    break;
                case "问答题":
                    frmQuestionAdd fqa = new frmQuestionAdd();
                    fqa.ShowDialog();
                    dataGridView5.DataSource = QuestionBll.QuestionFillDs().Tables[4];
                    break;
                default:
                    break;
            }
        }
        
        private void tsbDel_Click(object sender, EventArgs e)
        {
            string Question = tabConQustion.SelectedTab.Text;
            switch (Question)
            {
                case "单选题":
                    QuestionBll.Delete(dataGridView1, Question);
                    dataGridView1.DataSource = QuestionBll.QuestionFillDs().Tables[0];
                    break;
                case "多选题":
                    QuestionBll.Delete(dataGridView2, Question);
                    dataGridView2.DataSource = QuestionBll.QuestionFillDs().Tables[1];
                    break;
                case "判断题":
                    QuestionBll.Delete(dataGridView3, Question);
                    dataGridView3.DataSource = QuestionBll.QuestionFillDs().Tables[2];
                    break;
                case "填空题":
                    QuestionBll.Delete(dataGridView4, Question);
                    dataGridView4.DataSource = QuestionBll.QuestionFillDs().Tables[3];
                    break;
                case "问答题":
                    QuestionBll.Delete(dataGridView5, Question);
                    dataGridView5.DataSource = QuestionBll.QuestionFillDs().Tables[4];
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void tabConQustion_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabConQustion.SelectedTab.Text)
            {
                case "单选题":
                    dataGridView1.DataSource = QuestionBll.QuestionFillDs().Tables[0];
                    break;
                case "多选题":
                    dataGridView2.DataSource = QuestionBll.QuestionFillDs().Tables[1];
                    break;
                case "判断题":
                    dataGridView3.DataSource = QuestionBll.QuestionFillDs().Tables[2];
                    break;
                case "填空题":
                    dataGridView4.DataSource = QuestionBll.QuestionFillDs().Tables[3];
                    break;
                case "问答题":
                    dataGridView5.DataSource = QuestionBll.QuestionFillDs().Tables[4];
                    break;
                default:
                    break;
            }
        }

        private void frmQustionDataBase_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = QuestionBll.QuestionFillDs().Tables[0];
            dataGridView2.DataSource = QuestionBll.QuestionFillDs().Tables[1];
            dataGridView3.DataSource = QuestionBll.QuestionFillDs().Tables[2];
            dataGridView4.DataSource = QuestionBll.QuestionFillDs().Tables[3];
            dataGridView5.DataSource = QuestionBll.QuestionFillDs().Tables[4];
        }
    }
}