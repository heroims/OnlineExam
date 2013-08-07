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
    public partial class frmFindScore : Form
    {
        string UserID = "";
        public frmFindScore(string str)
        {
            UserID = str;
            InitializeComponent();
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
            if (txtSerch.Text == "")
            { 
                MessageBox.Show("请输入查询内容！");
            }
            else
            {
                if (cboSerch.SelectedText == "请选择查询条件")
                {
                    MessageBox.Show("请选择查询条件！");
                }
                else if (cboSerch.SelectedText == "考试时间")
                {
                    dataGridView1.DataSource = ScoreBll.UserScoreFillDs(txtSerch.Text, "ExamTime", UserID).Tables[0];
                }
                else if (cboSerch.SelectedText == "试卷名称")
                {
                    dataGridView1.DataSource = ScoreBll.UserScoreFillDs(txtSerch.Text, "PaperID", UserID).Tables[0];
                }
            }
        }
    }
}
