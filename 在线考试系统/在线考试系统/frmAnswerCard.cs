using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 在线考试系统.Model;

namespace 在线考试系统
{
    public partial class frmAnswerCard : Form
    {
        Dictionary<string,UserAnswer> Answer=new Dictionary<string,UserAnswer>() ;//UserAnswer的键值对集合

        public frmAnswerCard(Dictionary<string, UserAnswer> ua)
        {
            InitializeComponent();
            Answer = ua;
        }

        /// <summary>
        /// 判断题目作答情况
        /// </summary>
        /// <param name="str">用户答案</param>
        /// <returns>string类型，返回字符串类型的作答情况</returns>
        private string ISNO(string str)
        {
            if (str=="")
            {
                return ".未答";
            }
            else
            {
                return ".已答";
            }
        }

        #region 答题卡题目界面初始化
        /// <summary>
        /// 答题卡题目界面初始化
        /// </summary>
        private void FillAnswerCard()
        {
            int x0 = 0;
            int y0 = 10;
            int x1 = 0;
            int y1 = 10;
            int x2 = 0;
            int y2 = 10;
            int x3 = 0;
            int y3 = 10;
            int x4 = 0;
            int y4 = 10;
            foreach (KeyValuePair<string, UserAnswer> a in Answer)//遍历用户答案信息
            {
                if (a.Value.Type == "singleProblem")
                {
                    Button btnsingle = new Button();
                    btnsingle.Name = a.Key;
                    btnsingle.Text = a.Key.Substring("singleProblem".Length, a.Key.Length - "singleProblem".Length);
                    btnsingle.Location = new Point(x0, y0);
                    btnsingle.Size = new Size(groupBox1.Width / 6, groupBox1.Height / 3);
                    x0 += groupBox1.Width / 6;
                    if (a.Value.Sign == 1)
                    {
                        btnsingle.BackColor = Color.Red;
                    }
                    if (x0 >= (groupBox1.Width - groupBox1.Width / 6))
                    {
                        x0 = 0;
                        y0 += groupBox1.Height / 3;
                    }
                    btnsingle.Text += ISNO(a.Value.Answer);
                    btnsingle.Click += new EventHandler(btn_Click);
                    groupBox1.Controls.Add(btnsingle);
                }
                if (a.Value.Type == "multiProblem")
                {
                    Button btnmulti = new Button();
                    btnmulti.Name = a.Key;
                    btnmulti.Text = a.Key.Substring("multiProblem".Length, a.Key.Length - "multiProblem".Length);
                    btnmulti.Location = new Point(x1, y1);
                    btnmulti.Size = new Size(groupBox2.Width / 6, groupBox2.Height / 3);
                    x1 += groupBox2.Width / 6;
                    if (a.Value.Sign == 1)
                    {
                        btnmulti.BackColor = Color.Red;
                    }
                    if (x1 >= (groupBox2.Width - groupBox2.Width / 6))
                    {
                        x1 = 0;
                        y1 += groupBox2.Height / 3;
                    }
                    btnmulti.Text += ISNO(a.Value.Answer);
                    btnmulti.Click += new EventHandler(btn_Click);
                    groupBox2.Controls.Add(btnmulti);
                }
                if (a.Value.Type == "judgeProblem")
                {
                    Button btnjudge = new Button();
                    btnjudge.Name = a.Key;
                    btnjudge.Text = a.Key.Substring("judgeProblem".Length, a.Key.Length - "judgeProblem".Length);
                    btnjudge.Location = new Point(x2, y2);
                    btnjudge.Size = new Size(groupBox3.Width / 6, groupBox3.Height / 3);
                    x2 += groupBox3.Width / 6;
                    if (a.Value.Sign == 1)
                    {
                        btnjudge.BackColor = Color.Red;
                    }
                    if (x2 >= (groupBox3.Width - groupBox3.Width / 6))
                    {
                        x2 = 0;
                        y2 += groupBox3.Height / 3;
                    }
                    btnjudge.Text += ISNO(a.Value.Answer);
                    btnjudge.Click += new EventHandler(btn_Click);
                    groupBox3.Controls.Add(btnjudge);
                }
                if (a.Value.Type == "fillBlankProblem")
                {
                    Button btnfillBlank = new Button();
                    btnfillBlank.Name = a.Key;
                    btnfillBlank.Text = a.Key.Substring("fillBlankProblem".Length, a.Key.Length - "fillBlankProblem".Length);
                    btnfillBlank.Location = new Point(x3, y3);
                    btnfillBlank.Size = new Size(groupBox4.Width / 6, groupBox4.Height / 3);
                    x3 += groupBox4.Width / 6;
                    if (a.Value.Sign == 1)
                    {
                        btnfillBlank.BackColor = Color.Red;
                    }
                    if (x3 >= (groupBox4.Width - groupBox4.Width / 6))
                    {
                        x3 = 0;
                        y3 += groupBox4.Height / 3;
                    }
                    btnfillBlank.Text += ISNO(a.Value.Answer);
                    btnfillBlank.Click += new EventHandler(btn_Click);
                    groupBox4.Controls.Add(btnfillBlank);
                }
                if (a.Value.Type == "questionProblem")
                {
                    Button btnquestion = new Button();
                    btnquestion.Name = a.Key;
                    btnquestion.Text = a.Key.Substring("questionProblem".Length, a.Key.Length - "questionProblem".Length);
                    btnquestion.Location = new Point(x4, y4);
                    btnquestion.Size = new Size(groupBox5.Width / 6, groupBox5.Height / 3);
                    x4 += groupBox5.Width / 6;
                    if (a.Value.Sign == 1)
                    {
                        btnquestion.BackColor = Color.Red;
                    }
                    if (x4 >= (groupBox5.Width - groupBox5.Width / 6))
                    {
                        x4 = 0;
                        y4 += groupBox5.Height / 3;
                    }
                    btnquestion.Text += ISNO(a.Value.Answer);
                    btnquestion.Click += new EventHandler(btn_Click);
                    groupBox5.Controls.Add(btnquestion);
                }
            }
        }
        #endregion

        private void frmAnswerCard_Load(object sender, EventArgs e)
        {
            FillAnswerCard();
        }

        public string title = "";//记录题目键值信息

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            title = btn.Name;
            this.Hide();
        }
    }
}
