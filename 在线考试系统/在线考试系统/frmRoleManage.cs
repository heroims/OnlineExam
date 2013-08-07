using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 在线考试系统.Bll;
namespace 在线考试系统
{
    public partial class frmRoleManage : Form
    {
        public frmRoleManage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 添加表头
        /// </summary>
        private void getcolumn()
        {
            string[] str = { "编号","角色" };
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].HeaderText = str[i];
            }
        }

        private void tsbSetRights_Click(object sender, EventArgs e)
        {
            frmSetRights fsr = new frmSetRights(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            fsr.Show();
        }

        private void frmRoleManage_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = RoleBll.RoleFillDs().Tables[0];
            getcolumn();
        }

        #region 添加 删除事件
        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell!=null)
            {
                if (MessageBox.Show("是否删除记录？","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
                {
                    try
                    {
                        RoleBll.DelRole(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        dataGridView1.DataSource = RoleBll.RoleFillDs().Tables[0];
                        getcolumn();
                        MessageBox.Show("删除成功！");
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("删除失败！" + ee);
                        throw;
                    }
                }
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            if (tsbtxtRoleName.Text == "")
            {
                MessageBox.Show("请输入要添加的角色名称！");
            }
            else
            {
                if (RoleBll.GetRole(tsbtxtRoleName.Text))
                {
                    try
                    {
                        RoleBll.AddRole(tsbtxtRoleName.Text);
                        dataGridView1.DataSource = RoleBll.RoleFillDs().Tables[0];
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
                    MessageBox.Show("角色已存在！");
                }
            }
        }
        #endregion

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
