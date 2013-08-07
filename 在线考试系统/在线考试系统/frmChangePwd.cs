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
    public partial class frmChangePwd : Form
    {
        UserInfo User;
        public frmChangePwd(UserInfo user)
        {
            InitializeComponent();
            User = user;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOldPwd.Text==User.UserPwd)
                {
                    User.UserPwd = txtNewPwd.Text;
                    UserBll.UserPwdUpdate(User);
                    MessageBox.Show("修改成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("密码输入错误！");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("修改失败！" + ee.Message);
                throw;
            }
        }
    }
}
