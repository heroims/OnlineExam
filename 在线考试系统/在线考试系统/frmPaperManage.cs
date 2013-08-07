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
    public partial class frmPaperManage : Form
    {
        public frmPaperManage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 添加表头
        /// </summary>
        private void getcolumn()
        {
            string[] str = { "考试科目", "试卷名称", "试卷状态" };
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].HeaderText = str[i];
            }
        }

        private void frmPaperManage_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = PaperBll.PaperFillDs().Tables[1];
            getcolumn();
        }

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell!=null)
            {
                if (MessageBox.Show("是否删除信息？","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
                {
                    try
                    {
                        PaperBll.DelPaper(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                        dataGridView1.DataSource = PaperBll.PaperFillDs().Tables[1];
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
