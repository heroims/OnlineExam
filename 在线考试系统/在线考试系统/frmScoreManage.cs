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
    public partial class frmScoreManage : Form
    {
        public frmScoreManage()
        {
            InitializeComponent();
        }

        private void frmScoreManage_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource= ScoreBll.ScoreFillDs("").Tables[0];
            getcolumn();
            PaperBll.FillcboPaper(tscboPaper.ComboBox);
        }
        /// <summary>
        /// 添加表头
        /// </summary>
        public void getcolumn()
        {
            string[] str = { "用户编号", "用户名称", "试卷编号", "成绩", "考试时间", "评阅时间" };
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].HeaderText = str[i];
            }
        }

        #region 查询 删除事件
        private void tsbtnSerch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ScoreBll.ScoreFillDs(tscboPaper.ComboBox.SelectedValue.ToString()).Tables[0];
            getcolumn();
        }

        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                if (MessageBox.Show("是否删除记录？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        ScoreBll.ScoreDel(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                        MessageBox.Show("删除成功");
                        dataGridView1.DataSource = ScoreBll.ScoreFillDs("").Tables[0];
                        getcolumn();
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("删除失败！" + ee);
                        throw;
                    }
                }
            }
        }
        #endregion

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
