using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 在线考试系统.Model;
namespace 在线考试系统
{
    public partial class frmStudentExam : Form
    {
        
        public frmStudentExam(UserInfo user)
        {
            InitializeComponent();
            User = user;
        }

        UserInfo User;//用户信息实体

        private void 选择试卷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSelectPaper fsp = new frmSelectPaper();
            fsp.ShowDialog();
            selectPaper = fsp.str;
            fsp.Close();
        }

        string selectPaper="";//试卷类型

        private void 开始考试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectPaper == "")
            {
                MessageBox.Show("请选择试卷！");
            }
            else
            {
                frmStartExam fse = new frmStartExam(selectPaper,User);
                fse.ShowDialog();
            }
        }

        private void 查询成绩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFindScore ffs = new frmFindScore(User.UserID);
            ffs.ShowDialog();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePwd fcp = new frmChangePwd(User);
            fcp.Show();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 帮助ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "help.chm");
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("神马考试系统1.0版", "关于", MessageBoxButtons.OK);
        }
    }
}
