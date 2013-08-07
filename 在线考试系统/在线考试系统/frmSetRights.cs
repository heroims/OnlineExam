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
    public partial class frmSetRights : Form
    {
        static string RoleID;
        public frmSetRights(string str)
        {
            RoleID = str;
            InitializeComponent();
        }

        DataSet ds;
        /// <summary>
        /// 添加表头
        /// </summary>
        private void getcolumn()
        {
            string[] str = { "编号", "角色","用户信息管理", "考试科目管理", "试卷制定", "试卷评阅", "角色管理", "管理试卷", "成绩管理", "题库管理" };
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].HeaderText = str[i];
            }
        }

        private void frmSetRights_Load(object sender, EventArgs e)
        {
            ds = RoleBll.RoleFillDs(RoleID);
            dataGridView1.DataSource = ds.Tables[0];
            getcolumn();
        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null;
            if (ds.HasChanges())
            {
                try
                {
                    RoleBll.RoleUpdate();
                    MessageBox.Show("授权成功！");
                }
                catch (Exception ee)
                {
                    MessageBox.Show("授权失败！" + ee);
                    throw;
                }                
            }
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
