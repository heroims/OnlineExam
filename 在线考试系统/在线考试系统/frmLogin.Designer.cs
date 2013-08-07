namespace 在线考试系统
{
    partial class frmLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtUserPwd = new System.Windows.Forms.TextBox();
            this.labLogin = new System.Windows.Forms.Label();
            this.labClear = new System.Windows.Forms.Label();
            this.labExit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(81, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "登录用户：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(81, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "登录密码：";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(163, 60);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(100, 21);
            this.txtUserID.TabIndex = 2;
            // 
            // txtUserPwd
            // 
            this.txtUserPwd.Location = new System.Drawing.Point(163, 96);
            this.txtUserPwd.Name = "txtUserPwd";
            this.txtUserPwd.PasswordChar = '*';
            this.txtUserPwd.Size = new System.Drawing.Size(100, 21);
            this.txtUserPwd.TabIndex = 3;
            // 
            // labLogin
            // 
            this.labLogin.AutoSize = true;
            this.labLogin.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labLogin.Image = ((System.Drawing.Image)(resources.GetObject("labLogin.Image")));
            this.labLogin.Location = new System.Drawing.Point(68, 140);
            this.labLogin.Name = "labLogin";
            this.labLogin.Size = new System.Drawing.Size(59, 19);
            this.labLogin.TabIndex = 4;
            this.labLogin.Text = "     ";
            this.labLogin.Click += new System.EventHandler(this.labLogin_Click);
            // 
            // labClear
            // 
            this.labClear.AutoSize = true;
            this.labClear.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labClear.Image = global::在线考试系统.Properties.Resources.清空按钮;
            this.labClear.Location = new System.Drawing.Point(151, 140);
            this.labClear.Name = "labClear";
            this.labClear.Size = new System.Drawing.Size(59, 19);
            this.labClear.TabIndex = 5;
            this.labClear.Text = "     ";
            this.labClear.Click += new System.EventHandler(this.labClear_Click);
            // 
            // labExit
            // 
            this.labExit.AutoSize = true;
            this.labExit.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labExit.Image = global::在线考试系统.Properties.Resources.退出按钮;
            this.labExit.Location = new System.Drawing.Point(234, 140);
            this.labExit.Name = "labExit";
            this.labExit.Size = new System.Drawing.Size(59, 19);
            this.labExit.TabIndex = 6;
            this.labExit.Text = "     ";
            this.labExit.Click += new System.EventHandler(this.labExit_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::在线考试系统.Properties.Resources.登录界面背景;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(352, 211);
            this.Controls.Add(this.labExit);
            this.Controls.Add(this.labClear);
            this.Controls.Add(this.labLogin);
            this.Controls.Add(this.txtUserPwd);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "考试登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtUserPwd;
        private System.Windows.Forms.Label labLogin;
        private System.Windows.Forms.Label labClear;
        private System.Windows.Forms.Label labExit;
    }
}

