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
    public partial class frmMultiSelectAdd : Form
    {
        public frmMultiSelectAdd()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMultiSelectAdd_Load(object sender, EventArgs e)
        {
            CourseBll.FillcboCourse(cboCourse);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboCourse.SelectedValue==null||txtTitle.Text==""||txtAnswerA.Text==""||txtAnswerB.Text==""||txtAnswerC.Text==""||txtAnswerD.Text=="")
            {
                MessageBox.Show("请输入完整的题目信息！");
            }
            else if (ckbA.Checked == false && ckbB.Checked == false && ckbC.Checked == false && ckbD.Checked == false)
            {
                MessageBox.Show("请选择正确答案！");
            }
            else
            {
                string answer = "";
                if (ckbA.Checked == true)
                {
                    answer += "A";
                }
                if (ckbB.Checked == true)
                {
                    answer += "B";
                }
                if (ckbC.Checked == true)
                {
                    answer += "C";
                }
                if (ckbD.Checked == true)
                {
                    answer += "D";
                }
                try
                {
                    SingleMultiProblem smp = new SingleMultiProblem(cboCourse.SelectedValue.ToString(), txtTitle.Text, txtAnswerA.Text, txtAnswerB.Text, txtAnswerC.Text, txtAnswerD.Text, answer);
                    QuestionBll.AddmultiProblem(smp);
                    MessageBox.Show("添加成功！");
                    this.Close();
                }
                catch (Exception ee)
                {
                    MessageBox.Show("添加失败！"+ee);
                    throw;
                }
            }
        }
    }
}
