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
    public partial class frmUserManage : Form
    {
        public frmUserManage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 添加表头
        /// </summary>
        private void getcolumn()
        {
            string[] str = { "用户编号","用户姓名","角色"};
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].HeaderText = str[i];
            }
        }
        #region 添加 删除 修改事件
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            frmAddUser fau = new frmAddUser(0, "");
            fau.ShowDialog();
            dataGridView1.DataSource = UserBll.UserFill().Tables[0];
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                if (MessageBox.Show("是否删除记录？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        int rowIndex = dataGridView1.CurrentCell.RowIndex;
                        dataGridView1.Rows.RemoveAt(rowIndex);
                        UserBll.UserDelete();
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

        private void tsbSave_Click(object sender, EventArgs e)
        {
            frmAddUser fau = new frmAddUser(1, dataGridView1.CurrentRow.Cells[0].Value.ToString());
            fau.ShowDialog();
            dataGridView1.DataSource = UserBll.UserFill().Tables[0];
        }
        #endregion

        private void frmUserManage_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = UserBll.UserFill().Tables[0];
            getcolumn();
        }


        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
