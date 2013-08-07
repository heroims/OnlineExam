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
    public partial class frmMainManage : Form
    {
        UserInfo User;//用户实体

        public frmMainManage(UserInfo user)
        {
            User = user;
            InitializeComponent();
        }

        #region 界面初始化获取用户权限
        /// <summary>
        /// 界面初始化获取用户权限
        /// </summary>
        private void GetRoleHasDuty()
        {
            Role role = RoleBll.GetRoleHasDuty(User.RoleId);
            if (role.UserManage == 0)
            {
                tsmiAddUser.Enabled = false;
                tsmiUserManage.Enabled = false;
            }
            if (role.Role1 == 0)
            {
                tsmiRoleManage.Enabled = false;
            }
            if (role.UserScore == 0)
            {
                tsmiFS.Enabled = false;
                tsbFS.Enabled = false;
            }
            if (role.CourseManage == 0)
            {
                tsmiCM.Enabled = false;
            }
            if (role.PaperSetup == 0)
            {
                tsmiPSU.Enabled = false;
                tsbPSU.Enabled = false;
            }
            if (role.PaperLists == 0)
            {
                tsmiPM.Enabled = false;
            }
            if (role.UserPaperList == 0)
            {
                tsmiUP.Enabled = false;
                tsbUP.Enabled = false;
            }
            if (role.QuestionManage == 0)
            {
                MessageBox.Show(role.QuestionManage.ToString());
                tsmiQDB.Enabled = false;
            }
        }
        #endregion

        #region 进入各种窗口
        private void tsmiRoleManage_Click(object sender, EventArgs e)
        {
            frmRoleManage frm = new frmRoleManage();
            frm.Show();
        }

        private void tsmiChangePwd_Click(object sender, EventArgs e)
        {
            frmChangePwd fcp = new frmChangePwd(User);
            fcp.Show();
        }
 
        private void frmMainManage_Load(object sender, EventArgs e)
        {
            GetRoleHasDuty();
        }

        private void tsmiAddUser_Click(object sender, EventArgs e)
        {
            frmAddUser fau = new frmAddUser(0,"");
            fau.Show();
        }

        private void tsmiUserManage_Click(object sender, EventArgs e)
        {
            frmUserManage fum = new frmUserManage();
            fum.Show();
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiQDB_Click(object sender, EventArgs e)
        {
            frmQuestionDataBase fqdb = new frmQuestionDataBase();
            fqdb.Show();
        }

        private void tsmiPSU_Click(object sender, EventArgs e)
        {
            frmPaperSetUp fpsu = new frmPaperSetUp();
            fpsu.Show();
        }

        private void tsmiPM_Click(object sender, EventArgs e)
        {
            frmPaperManage fpm = new frmPaperManage();
            fpm.Show();
        }

        private void tsmiCM_Click(object sender, EventArgs e)
        {
            frmCourseManage fcm = new frmCourseManage();
            fcm.Show();
        }

        private void tsmiUP_Click(object sender, EventArgs e)
        {
            frmUserPaperList fupl = new frmUserPaperList();
            fupl.Show();
        }

        private void tsmiFS_Click(object sender, EventArgs e)
        {
            frmScoreManage fsm = new frmScoreManage();
            fsm.Show();
        }
        #endregion

        private void 帮助ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "help.chm");
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("神马考试管理系统1.0版","关于", MessageBoxButtons.OK);
        }
    }
}
