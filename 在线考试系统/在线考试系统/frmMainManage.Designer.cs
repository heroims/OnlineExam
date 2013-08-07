namespace 在线考试系统
{
    partial class frmMainManage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.题库管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQDB = new System.Windows.Forms.ToolStripMenuItem();
            this.定制试卷ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPSU = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPM = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCM = new System.Windows.Forms.ToolStripMenuItem();
            this.试卷管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUP = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUserManage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRoleManage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangePwd = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbPSU = new System.Windows.Forms.ToolStripButton();
            this.tsbUP = new System.Windows.Forms.ToolStripButton();
            this.tsbFS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.题库管理ToolStripMenuItem,
            this.定制试卷ToolStripMenuItem,
            this.试卷管理ToolStripMenuItem,
            this.tsmiUser,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(621, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 题库管理ToolStripMenuItem
            // 
            this.题库管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiQDB});
            this.题库管理ToolStripMenuItem.Name = "题库管理ToolStripMenuItem";
            this.题库管理ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.题库管理ToolStripMenuItem.Text = "题库管理";
            // 
            // tsmiQDB
            // 
            this.tsmiQDB.Name = "tsmiQDB";
            this.tsmiQDB.Size = new System.Drawing.Size(118, 22);
            this.tsmiQDB.Text = "题库管理";
            this.tsmiQDB.Click += new System.EventHandler(this.tsmiQDB_Click);
            // 
            // 定制试卷ToolStripMenuItem
            // 
            this.定制试卷ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPSU,
            this.tsmiPM,
            this.tsmiCM});
            this.定制试卷ToolStripMenuItem.Name = "定制试卷ToolStripMenuItem";
            this.定制试卷ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.定制试卷ToolStripMenuItem.Text = "定制试卷";
            // 
            // tsmiPSU
            // 
            this.tsmiPSU.Name = "tsmiPSU";
            this.tsmiPSU.Size = new System.Drawing.Size(118, 22);
            this.tsmiPSU.Text = "试卷定制";
            this.tsmiPSU.Click += new System.EventHandler(this.tsmiPSU_Click);
            // 
            // tsmiPM
            // 
            this.tsmiPM.Name = "tsmiPM";
            this.tsmiPM.Size = new System.Drawing.Size(118, 22);
            this.tsmiPM.Text = "试卷维护";
            this.tsmiPM.Click += new System.EventHandler(this.tsmiPM_Click);
            // 
            // tsmiCM
            // 
            this.tsmiCM.Name = "tsmiCM";
            this.tsmiCM.Size = new System.Drawing.Size(118, 22);
            this.tsmiCM.Text = "考试科目";
            this.tsmiCM.Click += new System.EventHandler(this.tsmiCM_Click);
            // 
            // 试卷管理ToolStripMenuItem
            // 
            this.试卷管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUP,
            this.tsmiFS});
            this.试卷管理ToolStripMenuItem.Name = "试卷管理ToolStripMenuItem";
            this.试卷管理ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.试卷管理ToolStripMenuItem.Text = "试卷管理";
            // 
            // tsmiUP
            // 
            this.tsmiUP.Name = "tsmiUP";
            this.tsmiUP.Size = new System.Drawing.Size(118, 22);
            this.tsmiUP.Text = "试卷评阅";
            this.tsmiUP.Click += new System.EventHandler(this.tsmiUP_Click);
            // 
            // tsmiFS
            // 
            this.tsmiFS.Name = "tsmiFS";
            this.tsmiFS.Size = new System.Drawing.Size(118, 22);
            this.tsmiFS.Text = "成绩管理";
            this.tsmiFS.Click += new System.EventHandler(this.tsmiFS_Click);
            // 
            // tsmiUser
            // 
            this.tsmiUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddUser,
            this.tsmiUserManage,
            this.tsmiRoleManage,
            this.tsmiChangePwd});
            this.tsmiUser.Name = "tsmiUser";
            this.tsmiUser.Size = new System.Drawing.Size(89, 20);
            this.tsmiUser.Text = "用户信息管理";
            // 
            // tsmiAddUser
            // 
            this.tsmiAddUser.Name = "tsmiAddUser";
            this.tsmiAddUser.Size = new System.Drawing.Size(118, 22);
            this.tsmiAddUser.Text = "添加用户";
            this.tsmiAddUser.Click += new System.EventHandler(this.tsmiAddUser_Click);
            // 
            // tsmiUserManage
            // 
            this.tsmiUserManage.Name = "tsmiUserManage";
            this.tsmiUserManage.Size = new System.Drawing.Size(118, 22);
            this.tsmiUserManage.Text = "用户管理";
            this.tsmiUserManage.Click += new System.EventHandler(this.tsmiUserManage_Click);
            // 
            // tsmiRoleManage
            // 
            this.tsmiRoleManage.Name = "tsmiRoleManage";
            this.tsmiRoleManage.Size = new System.Drawing.Size(118, 22);
            this.tsmiRoleManage.Text = "角色管理";
            this.tsmiRoleManage.Click += new System.EventHandler(this.tsmiRoleManage_Click);
            // 
            // tsmiChangePwd
            // 
            this.tsmiChangePwd.Name = "tsmiChangePwd";
            this.tsmiChangePwd.Size = new System.Drawing.Size(118, 22);
            this.tsmiChangePwd.Text = "更改密码";
            this.tsmiChangePwd.Click += new System.EventHandler(this.tsmiChangePwd_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem1,
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 帮助ToolStripMenuItem1
            // 
            this.帮助ToolStripMenuItem1.Name = "帮助ToolStripMenuItem1";
            this.帮助ToolStripMenuItem1.Size = new System.Drawing.Size(94, 22);
            this.帮助ToolStripMenuItem1.Text = "帮助";
            this.帮助ToolStripMenuItem1.Click += new System.EventHandler(this.帮助ToolStripMenuItem1_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPSU,
            this.tsbUP,
            this.tsbFS,
            this.toolStripSeparator1,
            this.tsbExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(621, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbPSU
            // 
            this.tsbPSU.Image = global::在线考试系统.Properties.Resources.mail5;
            this.tsbPSU.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPSU.Name = "tsbPSU";
            this.tsbPSU.Size = new System.Drawing.Size(73, 22);
            this.tsbPSU.Text = "试卷定制";
            this.tsbPSU.Click += new System.EventHandler(this.tsmiPSU_Click);
            // 
            // tsbUP
            // 
            this.tsbUP.Image = global::在线考试系统.Properties.Resources.mail4;
            this.tsbUP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUP.Name = "tsbUP";
            this.tsbUP.Size = new System.Drawing.Size(73, 22);
            this.tsbUP.Text = "试卷评阅";
            this.tsbUP.Click += new System.EventHandler(this.tsmiUP_Click);
            // 
            // tsbFS
            // 
            this.tsbFS.Image = global::在线考试系统.Properties.Resources.dc;
            this.tsbFS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFS.Name = "tsbFS";
            this.tsbFS.Size = new System.Drawing.Size(73, 22);
            this.tsbFS.Text = "考生成绩";
            this.tsbFS.Click += new System.EventHandler(this.tsmiFS_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = global::在线考试系统.Properties.Resources.close;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(49, 22);
            this.tsbExit.Text = "退出";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // frmMainManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 390);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMainManage";
            this.Text = "考试系统管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainManage_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 题库管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 定制试卷ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 试卷管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiUser;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbPSU;
        private System.Windows.Forms.ToolStripButton tsbUP;
        private System.Windows.Forms.ToolStripButton tsbFS;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiQDB;
        private System.Windows.Forms.ToolStripMenuItem tsmiPSU;
        private System.Windows.Forms.ToolStripMenuItem tsmiPM;
        private System.Windows.Forms.ToolStripMenuItem tsmiCM;
        private System.Windows.Forms.ToolStripMenuItem tsmiUP;
        private System.Windows.Forms.ToolStripMenuItem tsmiFS;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiUserManage;
        private System.Windows.Forms.ToolStripMenuItem tsmiRoleManage;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangePwd;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
    }
}