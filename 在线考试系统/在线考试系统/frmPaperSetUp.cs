using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 在线考试系统.Bll;
using 在线考试系统.Model;
namespace 在线考试系统
{
    public partial class frmPaperSetUp : Form
    {
        public frmPaperSetUp()
        {
            InitializeComponent();
        }

        private void frmPaperSetUp_Load(object sender, EventArgs e)
        {
            CourseBll.FillcboCourse(cboCourse);
        }

        List<PaperDetail> pd = new List<PaperDetail>();//试卷详细信息实体集

        #region 随机生成试卷编号
        /// <summary>
        /// 随机生成试卷编号
        /// </summary>
        /// <param name="count">随机数范围</param>
        /// <param name="random">随机数的个数</param>
        /// <returns>返回int类型的泛型数组</returns>
        private List<int> num(int count, int random)
        {
            List<int> list = new List<int>();//
            for (int i = 1; i <= count; i++)
            {
                list.Add(i);
            }

            List<int> result = new List<int>();
            for (; result.Count < random; )
            {
                Random r = new Random();
                int n = r.Next(1, count);
                if (n < list.Count)
                {
                    result.Add(list[n]);
                    list.Remove(list[n]);
                }
            }
            return result;
        }
        #endregion

        #region 选择 添加 打印试题
        private void btnOK_Click(object sender, EventArgs e)
        {
                if (txtTime.Text == "")
                {
                    MessageBox.Show("请输入考试时间！");
                }
                else
                {
                    if (ckbSingleProblem.Checked == true)
                    {
                        if (txtSingleMark.Text == "" || txtSingleCount.Text == "")
                        {
                            MessageBox.Show("请输入单选题详细信息！");
                        }
                        else
                        {
                            if (Convert.ToInt32(txtSingleCount.Text) < QuestionBll.singleCount(cboCourse.SelectedValue.ToString()))
                            {
                                List<int> count = num(QuestionBll.singleCount(cboCourse.SelectedValue.ToString()), Convert.ToInt32(txtSingleCount.Text));
                                for (int i = 0; i < Convert.ToInt32(txtSingleCount.Text); i++)
                                {
                                    pd.Add(new PaperDetail(PaperBll.GetPaperID(txtPaperName.Text), "singleProblem", count[i], Convert.ToInt32(txtSingleMark.Text), Convert.ToInt32(txtTime.Text)));
                                }
                            }
                            else
                            {
                                MessageBox.Show("题库题目不足！");
                            }
                        }
                    }
                    if (ckbMultiProblem.Checked == true)
                    {
                        if (txtMultiCount.Text == "" || txtMultiMark.Text == "")
                        {
                            MessageBox.Show("请输入多选题详细信息！");
                        }
                        else
                        {
                            if (Convert.ToInt32(txtMultiCount.Text) < QuestionBll.multiCount(cboCourse.SelectedValue.ToString()))
                            {
                                List<int> count = num(QuestionBll.multiCount(cboCourse.SelectedValue.ToString()), Convert.ToInt32(txtMultiCount.Text));
                                for (int i = 0; i <Convert.ToInt32(txtMultiCount.Text); i++)
                                {
                                    pd.Add(new PaperDetail(PaperBll.GetPaperID(txtPaperName.Text), "multiProblem", count[i], Convert.ToInt32(txtMultiMark.Text), Convert.ToInt32(txtTime.Text)));
                                }
                            }
                            else
                            {
                                MessageBox.Show("题库题目不足！");
                            }
                        }
                    }
                    if (ckbFillBlankProblem.Checked == true)
                    {
                        if (txtFillBlankCount.Text == "" || txtFillBlankMark.Text == "")
                        {
                            MessageBox.Show("请输入填空题详细信息！");
                        }
                        else
                        {
                            if (Convert.ToInt32(txtFillBlankCount.Text) < QuestionBll.fillBlankCount(cboCourse.SelectedValue.ToString()))
                            {
                                List<int> count = num(QuestionBll.fillBlankCount(cboCourse.SelectedValue.ToString()), Convert.ToInt32(txtFillBlankCount.Text));
                                for (int i = 0; i < Convert.ToInt32(txtSingleCount.Text); i++)
                                {
                                    pd.Add(new PaperDetail(PaperBll.GetPaperID(txtPaperName.Text), "fillBlankProblem", count[i], Convert.ToInt32(txtFillBlankMark.Text), Convert.ToInt32(txtTime.Text)));
                                }
                            }
                            else
                            {
                                MessageBox.Show("题库题目不足！");
                            }
                        }
                    }
                    if (ckbJudgeProblem.Checked == true)
                    {
                        if (txtJudgeCount.Text == "" || txtJudgeMark.Text == "")
                        {
                            MessageBox.Show("请输入判断题详细信息！");
                        }
                        else
                        {
                            if (Convert.ToInt32(txtJudgeCount.Text) < QuestionBll.judgeCount(cboCourse.SelectedValue.ToString()))
                            {
                                List<int> count = num(QuestionBll.judgeCount(cboCourse.SelectedValue.ToString()), Convert.ToInt32(txtJudgeCount.Text));
                                for (int i = 0; i < Convert.ToInt32(txtJudgeCount.Text); i++)
                                {
                                    pd.Add(new PaperDetail(PaperBll.GetPaperID(txtPaperName.Text), "judgeProblem", count[i], Convert.ToInt32(txtJudgeMark.Text), Convert.ToInt32(txtTime.Text)));
                                }
                            }
                            else
                            {
                                MessageBox.Show("题库题目不足！");
                            }
                        }
                    }
                    if (ckbQuestionProblem.Checked == true)
                    {
                        if (txtQuestionCount.Text == "" || txtQuestionMark.Text == "")
                        {
                            MessageBox.Show("请输入简答题详细信息！");
                        }
                        else
                        {
                            if (Convert.ToInt32(txtQuestionCount.Text) < QuestionBll.questionCount(cboCourse.SelectedValue.ToString()))
                            {
                                List<int> count = num(QuestionBll.questionCount(cboCourse.SelectedValue.ToString()), Convert.ToInt32(txtQuestionCount.Text));
                                for (int i = 0; i < Convert.ToInt32(txtQuestionCount.Text); i++)
                                {
                                    pd.Add(new PaperDetail(PaperBll.GetPaperID(txtPaperName.Text), "questionProblem", count[i], Convert.ToInt32(txtQuestionMark.Text), Convert.ToInt32(txtTime.Text)));
                                }
                            }
                            else
                            {
                                MessageBox.Show("题库题目不足！");
                            }
                        }
                    }
                    if (ckbSingleProblem.Checked == false && ckbQuestionProblem.Checked == false && ckbMultiProblem.Checked == false && ckbJudgeProblem.Checked == false && ckbFillBlankProblem.Checked == false)
                    {
                        MessageBox.Show("请选择试题！");
                    }
                    dataGridView1.DataSource = PaperDetailBll.PaperDetailFillDs(pd,"questionProblem").Tables[0];
                    dataGridView2.DataSource = PaperDetailBll.PaperDetailFillDs(pd,"singleProblem").Tables[0];
                    dataGridView3.DataSource = PaperDetailBll.PaperDetailFillDs(pd,"multiProblem").Tables[0];
                    dataGridView4.DataSource = PaperDetailBll.PaperDetailFillDs(pd,"judgeProblem").Tables[0];
                    dataGridView5.DataSource = PaperDetailBll.PaperDetailFillDs(pd,"fillBlankProblem").Tables[0];
                }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ckbSingleProblem.Checked == false && ckbQuestionProblem.Checked == false && ckbMultiProblem.Checked != false && ckbJudgeProblem.Checked == false && ckbFillBlankProblem.Checked == false)
            {
                MessageBox.Show("请选择试题！");
            }
            else
            {
                if (PaperBll.GetPaper(txtPaperName.Text))
                {
                    if (txtTime.Text == "")
                    {
                        MessageBox.Show("请输入考试时间！");
                    }
                    else
                    {
                        try
                        {
                            PaperBll.AddPaper(txtPaperName.Text,cboCourse.SelectedValue.ToString());
                            PaperDetailBll.PaperDetailAdd(pd);
                            PrintXPS();
                            MessageBox.Show("添加成功！");
                            this.Close();
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show("添加失败！" + ee);
                            throw;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("试卷名已存在！");
                }
            }
        }
        /// <summary>
        /// 试卷打印对话框
        /// </summary>
        private void PrintXPS()
        {
            if (MessageBox.Show("是否打印试卷","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                printDialog1.ShowDialog();
                printPreviewDialog1.Document = this.printDocument1;
                printPreviewDialog1.ShowDialog();
            }
        }
        #endregion

        /// <summary>
        /// 限定输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        #region 绘制打印试卷
        /// <summary>
        /// 绘制打印试卷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DataSet ds = PaperDetailBll.PaperFillDs(txtPaperName.Text);
            int r = 0;
            int c = 20;
            r += 120;
            e.Graphics.DrawString(txtPaperName.Text, new Font("宋体", 30, FontStyle.Regular), Brushes.Black, r, c);
            c += 40;
            r = 0;
            if (ckbSingleProblem.Checked == true)
            {
                e.Graphics.DrawString("单选题", new Font("宋体", 15, FontStyle.Regular), Brushes.Black, r, c);
                c += 20;
                e.Graphics.DrawString("题目", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("A项", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("B项", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("C项", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("D项", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("题目选项", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("做卷时间", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("题目分数", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                r = 0;
                c += 20;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {

                        e.Graphics.DrawString(ds.Tables[0].Rows[i][j].ToString(), new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                        r = r + 60;

                    }
                    r = 0;
                    c += 20;
                }
            }
            if (ckbMultiProblem.Checked == true)
            {
                e.Graphics.DrawString("多选题", new Font("宋体", 15, FontStyle.Regular), Brushes.Black, r, c);
                c += 20;
                e.Graphics.DrawString("题目", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("A项", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("B项", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("C项", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("D项", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("题目选项", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("做卷时间", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("题目分数", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                r = 0;
                c += 20;
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {

                    for (int j = 0; j < ds.Tables[1].Columns.Count; j++)
                    {

                        e.Graphics.DrawString(ds.Tables[1].Rows[i][j].ToString(), new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                        r = r + 60;

                    }
                    r = 0;
                    c += 20;
                }
            }
            if (ckbJudgeProblem.Checked == true)
            {
                e.Graphics.DrawString("判断题", new Font("宋体", 15, FontStyle.Regular), Brushes.Black, r, c);
                c += 20;
                e.Graphics.DrawString("题目", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("答案", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("题目选项", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("做卷时间", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("题目分数", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                r = 0;
                c += 20;
                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                {

                    for (int j = 0; j < ds.Tables[2].Columns.Count; j++)
                    {

                        e.Graphics.DrawString(ds.Tables[2].Rows[i][j].ToString(), new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                        r = r + 60;

                    }
                    r = 0;
                    c += 20;
                }
            }
            if (ckbFillBlankProblem.Checked == true)
            {
                e.Graphics.DrawString("填空题", new Font("宋体", 15, FontStyle.Regular), Brushes.Black, r, c);
                c += 20;
                e.Graphics.DrawString("前描述", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("后描述", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("答案", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("题目选项", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("做卷时间", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("题目分数", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                r = 0;
                c += 20;
                for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                {

                    for (int j = 0; j < ds.Tables[3].Columns.Count; j++)
                    {

                        e.Graphics.DrawString(ds.Tables[3].Rows[i][j].ToString(), new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                        r = r + 60;

                    }
                    r = 0;
                    c += 20;
                }
            }
            if (ckbQuestionProblem.Checked == true)
            {
                e.Graphics.DrawString("简答题", new Font("宋体", 15, FontStyle.Regular), Brushes.Black, r, c);
                c += 20;
                e.Graphics.DrawString("题目", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("答案", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("题目选项", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("做卷时间", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                e.Graphics.DrawString("题目分数", new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                r = r + 60;
                r = 0;
                c += 20;
                for (int i = 0; i < ds.Tables[4].Rows.Count; i++)
                {

                    for (int j = 0; j < ds.Tables[4].Columns.Count; j++)
                    {

                        e.Graphics.DrawString(ds.Tables[4].Rows[i][j].ToString(), new Font("宋体", 10, FontStyle.Regular), Brushes.Black, r, c);
                        r = r + 60;

                    }
                    r = 0;
                    c += 20;
                }
            }
        }
        #endregion
        private void frmPaperSetUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            PaperDetailBll.DropPaper();
        }
    }
}
