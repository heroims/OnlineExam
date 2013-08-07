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
    public partial class frmJudgeAdd : Form
    {
        public frmJudgeAdd()
        {
            InitializeComponent();
        }

        private void frmJudgeAdd_Load(object sender, EventArgs e)
        {
            CourseBll.FillcboCourse(cboCourse);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string RightWrong="False";
            if (cboCourse.SelectedValue==null||txtTitle.Text=="")
            {
                MessageBox.Show("请输入完整的题目信息！");
            }
            else if (rdoRight.Checked == false && rdoWrong.Checked == false)
            {
                MessageBox.Show("请选择正确答案！");
            }
            else
            {
                if (rdoRight.Checked == true)
                {
                    RightWrong = "True";
                }
                try
                {
                    JudgeQuestionProblem jqp = new JudgeQuestionProblem(cboCourse.SelectedValue.ToString(), txtTitle.Text, RightWrong);
                    QuestionBll.AddjudgeProblem(jqp);
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
    }
}
