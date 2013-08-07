using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 在线考试系统.Model;
using 在线考试系统.Bll;
namespace 在线考试系统
{
    public partial class frmUserPaper : Form
    {
        string UserID;//用户编号
        string Date;//做题日期
        string PaperID;//试卷编号
        public frmUserPaper(string str,string date,string paperID)
        {
            UserID = UserBll.GetUserID(str);
            Date = date;
            PaperID = paperID;
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        UserAnswer answer;//用户答案信息实体

        /// <summary>
        /// 添加表头
        /// </summary>
        private void getcolumn()
        {
            string[] str = { "序号", "题目", "答案", "参考答案", "得分" };
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].HeaderText = str[i];
            }
        }

        private void frmUserPaper_Load(object sender, EventArgs e)
        {
            answer = UserAnswerBll.GetUserAnswer(UserID, Date, PaperID);
            lblPaper.Text = answer.PaperName;
            lblTime.Text = answer.ExamTime;
            txtSingleProblem.Text = answer.SingleProblem.ToString();
            txtMultiProblem.Text = answer.MultiProblem.ToString();
            txtJudgeProblem.Text = answer.JudgeProblem.ToString();
            txtFillBlankProblem.Text = answer.FillBlankProblem.ToString();
            dataGridView1.DataSource = UserAnswerBll.QuestionFillDs(UserID, Date, PaperID).Tables[0];
            getcolumn();
        }
        
        /// <summary>
        /// 统计简答题总分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuestionSum_Click(object sender, EventArgs e)
        {
            txtQuestion.Text = UserAnswerBll.QuestionSum().ToString();
            txtSum.Text = (Convert.ToInt32(txtSingleProblem.Text) + Convert.ToInt32(txtMultiProblem.Text)  + Convert.ToInt32(txtJudgeProblem.Text) + Convert.ToInt32(txtFillBlankProblem.Text) + Convert.ToInt32(txtQuestion.Text)).ToString();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSum.Text!="")
            {
                Score score = new Score();
                score.PaperID = ScoreBll.GetPaperID(lblPaper.Text);
                score.ExamTime = Convert.ToDateTime(lblTime.Text);
                score.JudgeTime = DateTime.Now;
                score.Score0 = Convert.ToDouble(txtSum.Text);
                score.UserID = UserID;
                ScoreBll.ScoreAdd(score);
                MessageBox.Show("保存成功！");
                this.Close();
            }
            else
            {
                MessageBox.Show("请计算总分！");
            }
        }

        private void frmUserPaper_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserAnswerBll.QuestionDrop();
        }
    }
}
