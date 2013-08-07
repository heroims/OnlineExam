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
    public partial class frmStartExam : Form
    {
        string selectPaper;//试卷编号

        UserInfo User;//用户信息实体

        string oldTitleID = "";//题库题目号

        string TitleID = "1";//题目号

        Dictionary<string, UserAnswer> ua = new Dictionary<string, UserAnswer>();//用户答案键值对集合

        public frmStartExam(string str,UserInfo user)
        {
            selectPaper = str;
            User = user;
            InitializeComponent();
        }

        #region 用户答案初始化
        /// <summary>
        /// 用户答案初始化
        /// </summary>
        public void FillUa()
        {
            if (PaperDetailBll.GetQuestionCount(selectPaper, "singleProblem") != 0)
            {
                for (int i = 1; i <= PaperDetailBll.GetQuestionCount(selectPaper, "singleProblem"); i++)
                {
                    ua.Add("singleProblem" + i.ToString(), new UserAnswer(Convert.ToInt32(selectPaper), User.UserID, "singleProblem", DateTime.Now.ToString(), 0, m1, "", 0, "singleProblem" + i.ToString()));
                }
            }
            if (PaperDetailBll.GetQuestionCount(selectPaper, "multiProblem")!=0)
            {
                for (int i = 1; i <= PaperDetailBll.GetQuestionCount(selectPaper, "multiProblem"); i++)
                {
                    ua.Add("multiProblem" + i.ToString(), new UserAnswer(Convert.ToInt32(selectPaper), User.UserID, "multiProblem", DateTime.Now.ToString(), 0, m2, "", 0, "multiProblem" + i.ToString()));
                }
            }
            if (PaperDetailBll.GetQuestionCount(selectPaper, "judgeProblem")!=0)
            {
                for (int i = 1; i <= PaperDetailBll.GetQuestionCount(selectPaper, "judgeProblem"); i++)
                {
                    ua.Add("judgeProblem" + i.ToString(), new UserAnswer(Convert.ToInt32(selectPaper), User.UserID, "judgeProblem", DateTime.Now.ToString(), 0, m3, "", 0, "judgeProblem" + i.ToString()));
                }
            }
            if (PaperDetailBll.GetQuestionCount(selectPaper, "fillBlankProblem")!=0)
            {
                for (int i = 1; i <= PaperDetailBll.GetQuestionCount(selectPaper, "fillBlankProblem"); i++)
                {
                    ua.Add("fillBlankProblem" + i.ToString(), new UserAnswer(Convert.ToInt32(selectPaper), User.UserID, "fillBlankProblem", DateTime.Now.ToString(), 0, m4, "", 0, "fillBlankProblem" + i.ToString()));
                }
            }
            if (PaperDetailBll.GetQuestionCount(selectPaper, "questionProblem")!=0)
            {
                for (int i = 1; i <= PaperDetailBll.GetQuestionCount(selectPaper, "questionProblem"); i++)
                {
                    ua.Add("questionProblem" + i.ToString(), new UserAnswer(Convert.ToInt32(selectPaper), User.UserID, "questionProblem", DateTime.Now.ToString(), 0, m5, "", 0, "questionProblem" + i.ToString()));
                }
            }
        }
        #endregion

        #region 遍历用户答案
        /// <summary>
        /// 遍历用户答案
        /// </summary>
        /// <param name="key">答案主键</param>
        /// <returns>string类型，返回该用户string类型的答案</returns>
        private string Traversal(string key)
        {
            string answer = "";
            foreach (KeyValuePair<string, UserAnswer> a in ua)
            {
                if (a.Key == key)
                {
                    answer = a.Value.Answer;
                }
            }
            return answer;
        }
        #endregion

        #region 界面初始化
        int m1;//单选题每题分数
        int m2;//多选题每题分数
        int m3;//判断题每题分数
        int m4;//填空题每题分数
        int m5;//简答题每题分数
        /// <summary>
        /// 界面初始化
        /// </summary>
        private void StartReadQuestion()
        {
            timer1.Start();
            tslNo.Text = User.UserID;
            tslName.Text = User.UserName;
            PaperDetailBll.UserPaperFillDs(selectPaper);
            if (PaperDetailBll.sp!=null)
            {
                tsslblTime.Text = PaperDetailBll.sp[0].WriteTime;
                m1 = int.Parse(PaperDetailBll.sp[0].Mark);
                txtSingle.Text = PaperDetailBll.sp[0].Title;
                lblA.Text = PaperDetailBll.sp[0].AnswerA;
                lblB.Text = PaperDetailBll.sp[0].AnswerB;
                lblC.Text = PaperDetailBll.sp[0].AnswerC;
                lblD.Text = PaperDetailBll.sp[0].AnswerD;
                oldTitleID = PaperDetailBll.sp[0].TID;
            }
            else
            {
                m1 = 0;
                tslSingleDown.Enabled = false;
                rdoA.Enabled = false;
                rdoB.Enabled = false;
                rdoC.Enabled = false;
                rdoD.Enabled = false;
            }
            if (PaperDetailBll.mp != null)
            {
                tsslblTime.Text = PaperDetailBll.mp[0].WriteTime;
                m2 = int.Parse(PaperDetailBll.mp[0].Mark);
                txtMulti.Text = PaperDetailBll.mp[0].Title;
                lblAnswerA.Text = PaperDetailBll.mp[0].AnswerA;
                lblAnswerB.Text = PaperDetailBll.mp[0].AnswerB;
                lblAnswerC.Text = PaperDetailBll.mp[0].AnswerC;
                lblAnswerD.Text = PaperDetailBll.mp[0].AnswerD;
            }
            else 
            {
                m2 = 0;
                tslMultiDown.Enabled = false;
                ckbA.Enabled = false;
                ckbB.Enabled = false;
                ckbC.Enabled = false;
                ckbD.Enabled = false;
            }
            if (PaperDetailBll.jp != null)
            {
                tsslblTime.Text = PaperDetailBll.jp[0].WriteTime;
                m3 = int.Parse(PaperDetailBll.jp[0].Mark);
                txtJudge.Text = PaperDetailBll.jp[0].Title;
            }
            else 
            {
                m3 = 0;
                tslJudgeDown.Enabled = false;
                rdoRight.Enabled = false;
                rdoWrong.Enabled = false;
            }
            if (PaperDetailBll.fbp != null)
            {
                tsslblTime.Text = PaperDetailBll.fbp[0].WriteTime;
                m4 = int.Parse(PaperDetailBll.fbp[0].Mark);
                txtFrontTitle.Text = PaperDetailBll.fbp[0].FrontTitle;
                txtBackTitle.Text = PaperDetailBll.fbp[0].BackTitle;
            }
            else
            {
                m4 = 0;
                tslFillBlankDown.Enabled = false;
                txtAnswer.Enabled = false;
            }
            if (PaperDetailBll.qp != null)
            {
                tsslblTime.Text = PaperDetailBll.qp[0].WriteTime;
                m5 = int.Parse(PaperDetailBll.qp[0].Mark);
                txtTitle.Text = PaperDetailBll.qp[0].Title;
            }
            else
            {
                m5 = 0;
                tslQuestionDown.Enabled = false;
                txtQuestion.Enabled = false;
            }

        }
        private void frmStartExam_Load(object sender, EventArgs e)
        {
            StartReadQuestion();
            FillUa();
        }
        #endregion
     
        #region 显示用户答案
        /// <summary>
        /// 显示用户答案
        /// </summary>
        public void ReadAnswer()
        {
            PaperDetailBll.UserPaperFillDs(selectPaper);
            switch (tabConQustion.SelectedTab.Text)
            {

                case "单选题":
                    TitleID = tslblSingle.Text;
                    txtSingle.Text = PaperDetailBll.sp[Convert.ToInt32(TitleID)-1].Title;
                    oldTitleID = PaperDetailBll.sp[Convert.ToInt32(TitleID) - 1].TID;
                    lblA.Text = PaperDetailBll.sp[Convert.ToInt32(TitleID)-1].AnswerA;
                    lblB.Text = PaperDetailBll.sp[Convert.ToInt32(TitleID)-1].AnswerB;
                    lblC.Text = PaperDetailBll.sp[Convert.ToInt32(TitleID)-1].AnswerC;
                    lblD.Text = PaperDetailBll.sp[Convert.ToInt32(TitleID)-1].AnswerD;
                    if (Traversal("singleProblem" + TitleID) == "A")
                    {
                        rdoA.Checked = true;
                    }
                    else if(Traversal("singleProblem" + TitleID) == "B")
                    {
                        rdoB.Checked = true;
                    }
                    else if (Traversal("singleProblem" + TitleID) == "C")
                    {
                        rdoC.Checked = true;
                    }
                    else if (Traversal("singleProblem" + TitleID) == "D")
                    {
                        rdoD.Checked = true;
                    }
                    else
                    {
                        rdoA.Checked = false;
                        rdoB.Checked = false;
                        rdoC.Checked = false;
                        rdoD.Checked = false;
                    }
                    break;
                case "多选题":
                    TitleID = tslblMulti.Text;
                    txtMulti.Text = PaperDetailBll.mp[Convert.ToInt32(TitleID)-1].Title;
                    oldTitleID = PaperDetailBll.mp[Convert.ToInt32(TitleID) - 1].TID;
                    lblAnswerA.Text = PaperDetailBll.mp[Convert.ToInt32(TitleID)-1].AnswerA;
                    lblAnswerB.Text = PaperDetailBll.mp[Convert.ToInt32(TitleID)-1].AnswerB;
                    lblAnswerC.Text = PaperDetailBll.mp[Convert.ToInt32(TitleID)-1].AnswerC;
                    lblAnswerD.Text = PaperDetailBll.mp[Convert.ToInt32(TitleID)-1].AnswerD;
                    if (Traversal("multiProblem" + TitleID).IndexOf('A') != -1)
                    {
                        ckbA.Checked = true;
                    }
                    if (Traversal("multiProblem" + TitleID).IndexOf('B') != -1)
                    {
                        ckbA.Checked = true;
                    }
                    if (Traversal("multiProblem" + TitleID).IndexOf('C') != -1)
                    {
                        ckbA.Checked = true;
                    }
                    if (Traversal("multiProblem" + TitleID).IndexOf('D') != -1)
                    {
                        ckbA.Checked = true;
                    }
                    else
                    {
                        ckbA.Checked = false;
                        ckbB.Checked = false;
                        ckbC.Checked = false;
                        ckbD.Checked = false;
                    }
                    break;
                case "判断题":
                    TitleID = tslblJudge.Text;
                    txtJudge.Text = PaperDetailBll.jp[Convert.ToInt32(TitleID)-1].Title;
                    oldTitleID = PaperDetailBll.jp[Convert.ToInt32(TitleID) - 1].TID;
                    if (Traversal("judgeProblem" + TitleID)=="0")
                    {
                        rdoRight.Checked = true;
                    }
                    else if (Traversal("judgeProblem" + TitleID) == "1")
                    {
                        rdoWrong.Checked = true;
                    }
                    else
                    {
                        rdoRight.Checked = false;
                        rdoWrong.Checked = false;
                    }
                    break;
                case "填空题":
                    TitleID = tslblFillBlank.Text;
                    txtFrontTitle.Text = PaperDetailBll.fbp[Convert.ToInt32(TitleID)-1].FrontTitle;
                    txtBackTitle.Text = PaperDetailBll.fbp[Convert.ToInt32(TitleID)-1].BackTitle;
                    oldTitleID = PaperDetailBll.fbp[Convert.ToInt32(TitleID) - 1].TID;
                    if (Traversal("fillBlankProblem" + TitleID) != "" || Traversal("fillBlankProblem" + TitleID) != "NULL")
                    {
                        txtAnswer.Text = Traversal("fillBlankProblem" + TitleID);
                    }
                    break;
                case "简答题":
                    TitleID = tslblQuestion.Text;
                    txtTitle.Text = PaperDetailBll.qp[Convert.ToInt32(TitleID)-1].Title;
                    oldTitleID = PaperDetailBll.qp[Convert.ToInt32(TitleID) - 1].TID;
                    if (Traversal("questionProblem" + TitleID) != "" || Traversal("questionProblem" + TitleID) != "NULL")
                    {
                        txtQuestion.Text = Traversal("questionProblem" + TitleID);
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 考试计时
         int i = 0, j = 1;//记录时间的分和秒
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tsslalResidueMin.Text=="0"&&tsslalResidueSec.Text=="0")
            {
                timer1.Stop();
                MessageBox.Show("考试时间已结束！");
                this.Close();
            }
            else
            {
                if (i != 60)
                {
                    i += 1;
                }
                else
                {
                    i = 0;
                    j += 1;
                }
            }
            tsslblPassMin.Text = (j-1).ToString();
            tsslblPassSec.Text = i.ToString();
            tsslalResidueMin.Text = (Convert.ToInt32(tsslblTime.Text) - j).ToString();
            tsslalResidueSec.Text = (60 - i).ToString();
        }
        #endregion

        #region 试卷提交
        private void tslEnd_Click(object sender, EventArgs e)
        {
            if(tsslalResidueMin.Text!="0"&&tsslalResidueSec.Text!="0")
            {
                if (MessageBox.Show("是否提前交卷","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
                {
                    this.Close();
                }
            }
        }

        private void frmStartExam_FormClosing(object sender, FormClosingEventArgs e)
        {
            string date = DateTime.Now.Date.ToString();
            foreach (KeyValuePair<string,UserAnswer> a in ua)
            {
                a.Value.ExamTime = date;
            }
            UserAnswerBll.AddUserAnswer(ua);
        }
        #endregion

        #region 答题卡显示
        /// <summary>
        /// 答题卡显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbAnswer_Click(object sender, EventArgs e)
        {
            frmAnswerCard fac = new frmAnswerCard(ua);
            fac.ShowDialog();
            if (fac.title.IndexOf("singleProblem") != -1)
            {
                tabConQustion.SelectedTab = tabPage1;
                foreach (KeyValuePair<string, UserAnswer> a in ua)
                {
                    if (a.Key == fac.title)
                    {
                        tslblSingle.Text = fac.title.Substring("singleProblem".Length, fac.title.Length - "singleProblem".Length);
                        ReadAnswer();
                        if (tslblSingle.Text=="1")
                        {
                            tslSingleUp.Enabled = false;
                            tslSingleDown.Enabled = true;
                        }
                        if (tslblSingle.Text==PaperDetailBll.GetQuestionCount(selectPaper, "singleProblem").ToString())
                        {
                            tslSingleDown.Enabled = false;
                            tslSingleUp.Enabled = true;
                        }
                        if (tslblSingle.Text=="1"&&tslblSingle.Text==PaperDetailBll.GetQuestionCount(selectPaper, "singleProblem").ToString())
                        {
                            tslSingleUp.Enabled = false;
                            tslSingleDown.Enabled = false;
                        }
                        break;
                    }
                }
            }
            else if (fac.title.IndexOf("multiProblem") != -1)
            {
                tabConQustion.SelectedTab = tabPage2;
                foreach (KeyValuePair<string, UserAnswer> a in ua)
                {
                    if (a.Key == fac.title)
                    {
                        tslblMulti.Text = fac.title.Substring("multiProblem".Length, fac.title.Length - "multiProblem".Length);
                        ReadAnswer();
                        if (tslblMulti.Text == "1")
                        {
                            tslMultiUp.Enabled = false;
                            tslMultiDown.Enabled = true;
                        }
                        if (tslblMulti.Text == PaperDetailBll.GetQuestionCount(selectPaper, "multiProblem").ToString())
                        {
                            tslMultiDown.Enabled = false;
                            tslMultiUp.Enabled = true;
                        }
                        if (tslblMulti.Text == "1" && tslblMulti.Text == PaperDetailBll.GetQuestionCount(selectPaper, "multiProblem").ToString())
                        {
                            tslMultiUp.Enabled = false;
                            tslMultiDown.Enabled = false;
                        }
                        break;
                    }
                }
            }
            else if (fac.title.IndexOf("judgeProblem") != -1)
            {
                tabConQustion.SelectedTab = tabPage3;
                foreach (KeyValuePair<string, UserAnswer> a in ua)
                {
                    if (a.Key == fac.title)
                    {
                        tslblJudge.Text = fac.title.Substring("judgeProblem".Length, fac.title.Length - "judgeProblem".Length);
                        ReadAnswer();
                        if (tslblJudge.Text == "1")
                        {
                            tslJudgeUp.Enabled = false;
                            tslJudgeDown.Enabled = true;
                        }
                        if (tslblJudge.Text == PaperDetailBll.GetQuestionCount(selectPaper, "judgeProblem").ToString())
                        {
                            tslJudgeDown.Enabled = false;
                            tslJudgeUp.Enabled = true;
                        }
                        if (tslblJudge.Text == "1" && tslblJudge.Text == PaperDetailBll.GetQuestionCount(selectPaper, "judgeProblem").ToString())
                        {
                            tslJudgeUp.Enabled = false;
                            tslJudgeDown.Enabled = false;
                        }
                        break;
                    }
                }
            }
            else if (fac.title.IndexOf("fillBlankProblem") != -1)
            {
                tabConQustion.SelectedTab = tabPage4;
                foreach (KeyValuePair<string, UserAnswer> a in ua)
                {
                    if (a.Key == fac.title)
                    {
                        tslblFillBlank.Text = fac.title.Substring("fillBlankProblem".Length, fac.title.Length - "fillBlankProblem".Length);
                        ReadAnswer();
                        if (tslblFillBlank.Text == "1")
                        {
                            tslFillBlankUp.Enabled = false;
                            tslFillBlankDown.Enabled = true;
                        }
                        if (tslblFillBlank.Text == PaperDetailBll.GetQuestionCount(selectPaper, "fillBlankProblem").ToString())
                        {
                            tslFillBlankDown.Enabled = false;
                            tslFillBlankUp.Enabled = true;
                        }
                        if (tslblFillBlank.Text == "1" && tslblFillBlank.Text == PaperDetailBll.GetQuestionCount(selectPaper, "fillBlankProblem").ToString())
                        {
                            tslFillBlankUp.Enabled = false;
                            tslFillBlankDown.Enabled = false;
                        }
                        break;
                    }
                }
            }
            else if (fac.title.IndexOf("questionProblem") != -1)
            {
                tabConQustion.SelectedTab = tabPage5;
                foreach (KeyValuePair<string, UserAnswer> a in ua)
                {
                    if (a.Key == fac.title)
                    {
                        tslblQuestion.Text = fac.title.Substring("questionProblem".Length, fac.title.Length - "questionProblem".Length);
                        ReadAnswer();
                        if (tslblQuestion.Text == "1")
                        {
                            tslQuestionUp.Enabled = false;
                            tslQuestionDown.Enabled = true;
                        }
                        if (tslblQuestion.Text == PaperDetailBll.GetQuestionCount(selectPaper, "questionProblem").ToString())
                        {
                            tslQuestionDown.Enabled = false;
                            tslQuestionUp.Enabled = true;
                        }
                        if (tslblQuestion.Text == "1" && tslblQuestion.Text == PaperDetailBll.GetQuestionCount(selectPaper, "questionProblem").ToString())
                        {
                            tslQuestionUp.Enabled = false;
                            tslQuestionDown.Enabled = false;
                        }
                        break;
                    }
                }
            }
        }
        #endregion

        #region 检查 添加集合数据
        /// <summary>
        /// 检查用户答案信息
        /// </summary>
        private UserAnswer Check()
        {
            string str = "";
            switch (tabConQustion.SelectedTab.Text)
            {
                case "单选题":
                    str="singleProblem" + tslblSingle.Text;
                    break;
                case "多选题":
                    str="multiProblem" + tslblMulti.Text;
                    break;
                case "判断题":
                    str="judgeProblem" + tslblJudge.Text;
                    break;
                case "填空题":
                    str="fillBlankProblem" + tslblFillBlank.Text;
                    break;
                case "简答题":
                    str="questionProblem" + tslblQuestion.Text;
                    break;
                default:
                    break;
            }
            UserAnswer useranswer = null;
            foreach (KeyValuePair<string,UserAnswer> a in ua)
            {
                if (a.Key==str)
                {
                    useranswer=a.Value;
                }
            }
            return useranswer;
        }
        /// <summary>
        /// 添加用户答案信息
        /// </summary>
        /// <param name="answer">用户答案</param>
        private void Add(string answer)
        {
            int Sign = 0;
            if (ckbSign.Checked == true)
            {
                Sign = 1;
            }
            if (Check() != null)
            {
                switch (tabConQustion.SelectedTab.Text)
                {
                    case "单选题":
                        ua["singleProblem" + tslblSingle.Text] = new UserAnswer(Convert.ToInt32(selectPaper), User.UserID, "singleProblem", DateTime.Now.Date.ToString(), Convert.ToInt32(oldTitleID), m1, answer, Sign, "singleProblem" + tslblSingle.Text);
                        break;
                    case "多选题":
                        ua["multiProblem" + tslblMulti.Text] = new UserAnswer(Convert.ToInt32(selectPaper), User.UserID, "multiProblem", DateTime.Now.Date.ToString(), Convert.ToInt32(oldTitleID), m1, answer, Sign, "multiProblem" + tslblMulti.Text);
                        break;
                    case "判断题":
                        ua["judgeProblem" + tslblJudge.Text] = new UserAnswer(Convert.ToInt32(selectPaper), User.UserID, "judgeProblem", DateTime.Now.Date.ToString(), Convert.ToInt32(oldTitleID), m3, answer, Sign, "judgeProblem" + tslblJudge.Text);
                        break;
                    case "填空题":
                        ua["fillBlankProblem" + tslblFillBlank.Text] = new UserAnswer(Convert.ToInt32(selectPaper), User.UserID, "fillBlankProblem", DateTime.Now.Date.ToString(), Convert.ToInt32(oldTitleID), m4, answer, Sign, "fillBlankProblem" + tslblFillBlank.Text);
                        break;
                    case "简答题":
                        ua["questionProblem" + tslblQuestion.Text] = new UserAnswer(Convert.ToInt32(selectPaper), User.UserID, "questionProblem", DateTime.Now.Date.ToString(), Convert.ToInt32(oldTitleID), m5, answer, Sign, "questionProblem" + tslblQuestion.Text);
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        #region 翻页读取事件
        private void tslsSingleDown_Click(object sender, EventArgs e)
        {
            int count = PaperDetailBll.GetQuestionCount(selectPaper, "singleProblem");
            string answer = "";
            if (Convert.ToInt32(tslblSingle.Text) < count)
            {
                if (rdoA.Checked==false&&rdoB.Checked==false&&rdoC.Checked==false&&rdoD.Checked==false)
                {
                    answer = "";
                    Add(answer);
                }
                tslblSingle.Text = (Convert.ToInt32(tslblSingle.Text) + 1).ToString();
                tslSingleUp.Enabled = true;
            }
            if (Convert.ToInt32(tslblSingle.Text) == count)
            {
                tslSingleDown.Enabled = false;
            }
            ReadAnswer();
        }

        private void tslMultiDown_Click(object sender, EventArgs e)
        {
            int count = PaperDetailBll.GetQuestionCount(selectPaper, "multiProblem");
            string answer = "";
            if (Convert.ToInt32(tslblMulti.Text) < count)
            {
                if (ckbA.Checked == false && ckbB.Checked == false && ckbC.Checked == false && ckbD.Checked == false)
                {
                    answer = "";
                    Add(answer);
                }
                tslblMulti.Text = (Convert.ToInt32(tslblMulti.Text) + 1).ToString();
                tslMultiUp.Enabled = true;
            }
            if (Convert.ToInt32(tslblMulti.Text) == count)
            {
                tslMultiDown.Enabled = false;
            }
            ReadAnswer();
        }

        private void tslJudgeDown_Click(object sender, EventArgs e)
        {
            int count = PaperDetailBll.GetQuestionCount(selectPaper, "judgeProblem");
            string answer = "";
            if (Convert.ToInt32(tslblJudge.Text) < count)
            {
                if (rdoRight.Checked==false&&rdoWrong.Checked==false)
                {
                    answer = "";
                    Add(answer);
                }
                tslblJudge.Text = (Convert.ToInt32(tslblJudge.Text) + 1).ToString();
                tslJudgeUp.Enabled = true;
            }
            if (Convert.ToInt32(tslblJudge.Text) == count)
            {
                tslJudgeDown.Enabled = false;
            }
            ReadAnswer();
        }

        private void tslFillBlankDown_Click(object sender, EventArgs e)
        {
            int count = PaperDetailBll.GetQuestionCount(selectPaper, "fillBlankProblem");
            if (Convert.ToInt32(tslblFillBlank.Text) < count)
            {
                tslblFillBlank.Text = (Convert.ToInt32(tslblFillBlank.Text) + 1).ToString();
                tslFillBlankUp.Enabled = true;
            }
            if (Convert.ToInt32(tslblFillBlank.Text) == count)
            {
                tslFillBlankDown.Enabled = false;
            }
            Add(txtAnswer.Text);
            ReadAnswer();

        }

        private void tslQuestionDown_Click(object sender, EventArgs e)
        {
            int count = PaperDetailBll.GetQuestionCount(selectPaper, "questionProblem");
            if (Convert.ToInt32(tslblQuestion.Text) < count)
            {
                tslblQuestion.Text = (Convert.ToInt32(tslblQuestion.Text) + 1).ToString();
                tslQuestionUp.Enabled = true;
            }
            if (Convert.ToInt32(tslblQuestion.Text) == count)
            {
                tslQuestionDown.Enabled = false;
            }
            Add(txtQuestion.Text);
            ReadAnswer();
        }

        private void tslSingleUp_Click(object sender, EventArgs e)
        {
            string answer = "";
            if (Convert.ToInt32(tslblSingle.Text) > 1)
            {
                if (rdoA.Checked == false && rdoB.Checked == false && rdoC.Checked == false && rdoD.Checked == false)
                {
                    answer = "";
                    Add(answer);
                }
                tslblSingle.Text = (Convert.ToInt32(tslblSingle.Text) - 1).ToString();
                tslSingleDown.Enabled = true;
            }
            if (Convert.ToInt32(tslblSingle.Text) == 1)
            {
                tslSingleUp.Enabled = false;
            }
            ReadAnswer();
        }

        private void tslMultiUp_Click(object sender, EventArgs e)
        {
            string answer = "";
            if (Convert.ToInt32(tslblMulti.Text) > 1)
            {
                if (ckbA.Checked == false && ckbB.Checked == false && ckbC.Checked == false && ckbD.Checked == false)
                {
                    answer = "";
                    Add(answer);
                }
                tslblMulti.Text = (Convert.ToInt32(tslblMulti.Text) - 1).ToString();
                tslMultiDown.Enabled = true;
            }
            if (Convert.ToInt32(tslblMulti.Text) == 1)
            {
                tslMultiUp.Enabled = false;
            }
            ReadAnswer();
        }

        private void tslJudgeUp_Click(object sender, EventArgs e)
        {
            string answer = "";
            if (Convert.ToInt32(tslblJudge.Text) > 1)
            {
                if (rdoRight.Checked == false && rdoWrong.Checked == false)
                {
                    answer = "";
                    Add(answer);
                }
                tslblJudge.Text = (Convert.ToInt32(tslblJudge.Text) - 1).ToString();
                tslJudgeDown.Enabled = true;
            }
            if (Convert.ToInt32(tslblJudge.Text) == 1)
            {
                tslJudgeUp.Enabled = false;
            }
            ReadAnswer();
        }

        private void tslFillBlankUp_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tslblFillBlank.Text) > 1)
            {
                tslblFillBlank.Text = (Convert.ToInt32(tslblFillBlank.Text) - 1).ToString();
                tslFillBlankDown.Enabled = true;
            }
            if (Convert.ToInt32(tslblFillBlank.Text) == 1)
            {
                tslFillBlankUp.Enabled = false;
            }
            Add(txtAnswer.Text);
            ReadAnswer();
        }

        private void tslQuestionUp_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tslblQuestion.Text) > 1)
            {
                tslblQuestion.Text = (Convert.ToInt32(tslblQuestion.Text) - 1).ToString();
                tslQuestionDown.Enabled = true;
            }
            if (Convert.ToInt32(tslblQuestion.Text) == 1)
            {
                tslQuestionUp.Enabled = false;
            }
            Add(txtQuestion.Text);
            ReadAnswer();
        }

        #endregion

        #region 答题保存事件
        private void rdoA_Click(object sender, EventArgs e)
        {
            Add(((RadioButton)sender).Text);
        }

        private void rdoB_Click(object sender, EventArgs e)
        {
            Add(((RadioButton)sender).Text);
        }

        private void rdoC_Click(object sender, EventArgs e)
        {
            Add(((RadioButton)sender).Text);
        }

        private void rdoD_Click(object sender, EventArgs e)
        {
            Add(((RadioButton)sender).Text);
        }

        private void rdoRight_Click(object sender, EventArgs e)
        {
            Add("0");
        }

        private void rdoWrong_Click(object sender, EventArgs e)
        {
            Add("1");
        } 
        
        private void txtAnswer_MouseLeave(object sender, EventArgs e)
        {
            Add(((TextBox)sender).Text);
        }

        private void txtQuestion_MouseLeave(object sender, EventArgs e)
        {
            Add(((TextBox)sender).Text);
        }  
        
        private void ckbA_Click(object sender, EventArgs e)
        {
            string answer = "";
            if (ckbA.Checked == true)
            {
                answer += "A";
            }
            if (ckbB.Checked == true)
            {
                answer += "B";
            }
            if (ckbC.Checked == true)
            {
                answer += "C";
            }
            if (ckbD.Checked == true)
            {
                answer += "D";
            }
            else
            {
                answer = "";
            }
            Add(answer);
        }

        #endregion

        #region 模糊标记保存事件
        /// <summary>
        /// 模糊标记保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckbSign_Click(object sender, EventArgs e)
        {
            int Sign = 0;
            if (ckbSign.Checked == true)
            {
                Sign = 1;
            }
            if (Check() != null)
            {
                switch (tabConQustion.SelectedTab.Text)
                {
                    case "单选题":
                        ua["singleProblem" + tslblSingle.Text].Sign = Sign;
                        break;
                    case "多选题":
                        ua["multiProblem" + tslblMulti.Text].Sign = Sign;
                        break;
                    case "判断题":
                        ua["judgeProblem" + tslblJudge.Text].Sign = Sign;
                        break;
                    case "填空题":
                        ua["fillBlankProblem" + tslblFillBlank.Text].Sign = Sign;
                        break;
                    case "简答题":
                        ua["questionProblem" + tslblQuestion.Text].Sign = Sign;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (tabConQustion.SelectedTab.Text)
                {
                    case "单选题":
                        ua.Add("singleProblem" + tslblSingle.Text, new UserAnswer(Convert.ToInt32(selectPaper), User.UserID, "singleProblem", DateTime.Now.ToString(), Convert.ToInt32(oldTitleID), m1, "", Sign, "singleProblem" + tslblSingle.Text));
                        break;
                    case "多选题":
                        ua.Add("multiProblem" + tslblMulti.Text, new UserAnswer(Convert.ToInt32(selectPaper), User.UserID, "multiProblem", DateTime.Now.ToString(), Convert.ToInt32(oldTitleID), m2, "", Sign, "multiProblem" + tslblMulti.Text));
                        break;
                    case "判断题":
                        ua.Add("judgeProblem" + tslblJudge.Text, new UserAnswer(Convert.ToInt32(selectPaper), User.UserID, "judgeProblem", DateTime.Now.ToString(), Convert.ToInt32(oldTitleID), m3, "", Sign, "judgeProblem" + tslblJudge.Text));
                        break;
                    case "填空题":
                        ua.Add("fillBlankProblem" + tslblFillBlank.Text, new UserAnswer(Convert.ToInt32(selectPaper), User.UserID, "fillBlankProblem", DateTime.Now.ToString(), Convert.ToInt32(oldTitleID), m4, "", Sign, "fillBlankProblem" + tslblFillBlank.Text));
                        break;
                    case "简答题":
                        ua.Add("questionProblem" + tslblQuestion.Text, new UserAnswer(Convert.ToInt32(selectPaper), User.UserID, "questionProblem", DateTime.Now.ToString(), Convert.ToInt32(oldTitleID), m5, "", Sign, "questionProblem" + tslblQuestion.Text));
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion


    }
}
