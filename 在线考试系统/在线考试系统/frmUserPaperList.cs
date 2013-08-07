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
    public partial class frmUserPaperList : Form
    {
        public frmUserPaperList()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 添加表头
        /// </summary>
        private void getcolumn()
        {
            string[] str = { "序号", "用户姓名", "考试时间","试卷编号" };
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].HeaderText = str[i];
            }
        }

        private void frmUserPaperList_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = UserAnswerBll.UserAnswerFillDs().Tables[0];
            dataGridView1.Columns[3].Visible = false;
            getcolumn();
        }

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbtnUserPaper_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                frmUserPaper fup = new frmUserPaper(dataGridView1.CurrentRow.Cells[1].Value.ToString(), dataGridView1.CurrentRow.Cells[2].Value.ToString(), dataGridView1.CurrentRow.Cells[3].Value.ToString());
                fup.Show();
            }
            else
            {
                MessageBox.Show("请选择评阅用户！");
            }
        }

        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell!=null)
            {
                if (MessageBox.Show("是否删除记录","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
                {
                    try
                    {
                        UserAnswerBll.UserAnswerDelete(dataGridView1.CurrentRow.Cells[1].Value.ToString(),dataGridView1.CurrentRow.Cells[2].ToString());
                        dataGridView1.DataSource = UserAnswerBll.UserAnswerFillDs().Tables[0];
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
    }
}
