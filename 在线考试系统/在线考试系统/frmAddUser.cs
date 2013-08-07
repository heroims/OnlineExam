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
    public partial class frmAddUser : Form
    {
        int AddSave;//判断保存修改的字段
        string UserID;//用户编号
        #region 判断保存或删除
        /// <summary>
        /// 判断保存或删除的函数
        /// </summary>
        private void AddORSave()
        {
            if (AddSave == 0)
            {
                if (txtID.Text == "" || txtName.Text == "" || txtPwd.Text == "" || cobRole.SelectedValue == null)
                {
                    MessageBox.Show("请填写完整的用户信息！");
                }
                else
                {
                    if (UserBll.GetUser(txtID.Text))
                    {
                        try
                        {
                            UserInfo user = new UserInfo(txtID.Text, txtPwd.Text, txtName.Text, Convert.ToInt32(cobRole.SelectedValue));
                            UserBll.UserInsert(user);
                            MessageBox.Show("添加成功！");
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show("添加失败！" + ee);
                            throw;
                        }
                    }
                    else
                    {
                        MessageBox.Show("用户已存在！");
                    }
                }
            }
            else
            {
                if (txtID.Text == "" || txtName.Text == "" || txtPwd.Text == "" || cobRole.SelectedValue == null)
                {
                    MessageBox.Show("请填写完整的用户信息！");
                }
                else
                {
                    if (UserBll.GetUser(txtID.Text))
                    {
                        try
                        {
                            UserInfo user = new UserInfo(txtID.Text, txtPwd.Text, txtName.Text, Convert.ToInt32(cobRole.SelectedValue));
                            UserBll.UserInsert(user);
                            MessageBox.Show("修改成功！");
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show("修改失败！" + ee);
                            throw;
                        }
                    }
                    else
                    {
                        MessageBox.Show("用户已存在！");
                    }
                }
            }
        }
        #endregion

        public frmAddUser(int i,string str)
        {
            UserID = str;
            AddSave = i;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            AddORSave();
        }
        /// <summary>
        /// 绑定ComboBox的函数
        /// </summary>
        private void FillCob()
        {
            cobRole.ValueMember = "RoleID";
            cobRole.DisplayMember = "RoleName";
            cobRole.DataSource = RoleBll.RoleFillDs("").Tables[0];
            if (AddSave == 1)
            {
                btnOK.Text = "修改";
                UserInfo User = UserBll.UserRead(UserID);
                txtID.Text = User.UserID;
                txtName.Text = User.UserName;
                txtPwd.Text = User.UserPwd;
                cobRole.SelectedValue = User.RoleId;
            }
        }
        private void frmAddUser_Load(object sender, EventArgs e)
        {
            FillCob();
        }
    }
}
