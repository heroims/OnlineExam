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
    public partial class frmSelectPaper : Form
    {
        public frmSelectPaper()
        {
            InitializeComponent();
        }

        private void frmSelectPaper_Load(object sender, EventArgs e)
        {
            PaperBll.FillcboPaper(cboPaper);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string str="";
        private void btnOK_Click(object sender, EventArgs e)
        {
            str = cboPaper.SelectedValue.ToString();
            this.Close();
        }
    }
}
