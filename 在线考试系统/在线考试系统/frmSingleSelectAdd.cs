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
    public partial class frmSingleSelectAdd : Form
    {
        public frmSingleSelectAdd()
        {
            InitializeComponent();
        }

        private void frmSingleSelectAdd_Load(object sender, EventArgs e)
        {
            CourseBll.FillcboCourse(cboCourse);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboCourse.SelectedValue==null||txtTitle.Text==""||txtAnswerA.Text==""||txtAnswerB.Text==""||txtAnswerC.Text==""||txtAnswerD.Text=="")
            {
                MessageBox.Show("请输入完整的题目信息！");
            }
            else if (cboAnswer.Text=="")
            {
                MessageBox.Show("请选择正确答案！");
            }
            else
            {
                try
                {
                    SingleMultiProblem smp = new SingleMultiProblem(cboCourse.SelectedValue.ToString(), txtTitle.Text, txtAnswerA.Text, txtAnswerB.Text, txtAnswerC.Text, txtAnswerD.Text, cboAnswer.Text);
                    QuestionBll.AddsingleProblem(smp);
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
