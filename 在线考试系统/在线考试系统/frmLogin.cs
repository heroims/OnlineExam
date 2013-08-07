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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void labExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region 重置 登录事件
        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labClear_Click(object sender, EventArgs e)
        {
            txtUserID.Clear();
            txtUserPwd.Clear();
        }
        int i = 3;
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labLogin_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text==""||txtUserPwd.Text=="")
            {
                MessageBox.Show("请输入用户或密码！");
            }
            else
            {
                UserInfo User = new UserInfo(txtUserID.Text, txtUserPwd.Text);
                try
                {
                    if (UserBll.UserISNO(User) == 1)
                    {
                        frmStudentExam fse = new frmStudentExam(User);
                        User.UserName = UserBll.GetUserName(txtUserID.Text);
                        fse.Show();
                    }
                    else if (UserBll.UserISNO(User) == 2||UserBll.UserISNO(User)==3)
                    {
                        User.RoleId = UserBll.UserISNO(User);
                        User.UserName = UserBll.GetUserName(txtUserID.Text);
                        frmMainManage fmm = new frmMainManage(User);
                        fmm.Show();
                    }
                    else
                    {
                        MessageBox.Show("密码或用户名错误！");
                        i -= 1;
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    throw;
                }            
            }
            if (i==0)
            {
                this.Close();
            }
        }
        #endregion
    }
}
