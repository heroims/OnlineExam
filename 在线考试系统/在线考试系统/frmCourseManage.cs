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
    public partial class frmCourseManage : Form
    {
        public frmCourseManage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 添加表头
        /// </summary>
        private void getcolumn()
        {
            string[] str = { "序号", "科目" };
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].HeaderText = str[i];
            }
        }
        private void frmCourseManage_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CourseBll.CourseFillDs().Tables[0];
            getcolumn();
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region 添加 删除事件
        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                if (MessageBox.Show("是否删除记录？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        CourseBll.CourseDel(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        MessageBox.Show("删除成功！");
                        dataGridView1.DataSource = CourseBll.CourseFillDs().Tables[0];
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

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            if (txtCourseName.Text == "")
            {
                MessageBox.Show("请输入科目名称！");
            }
            else
            {
                if (CourseBll.GetCourse(txtCourseName.Text))
                {
                    try
                    {
                        CourseBll.CourseAdd(txtCourseName.Text);
                        dataGridView1.DataSource = CourseBll.CourseFillDs().Tables[0];
                        getcolumn();
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
                    MessageBox.Show("科目已存在！");
                }
            }
        }
        #endregion
    }
}
