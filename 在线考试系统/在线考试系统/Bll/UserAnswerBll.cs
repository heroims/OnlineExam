using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using 在线考试系统.Dal;
using 在线考试系统.Model;
namespace 在线考试系统.Bll
{
    class UserAnswerBll
    {
        static UserAnswerDal uab = new UserAnswerDal();
        /// <summary>
        /// 获取用户答题答案信息
        /// </summary>
        /// <returns>DataSet类型，返回用户答题答案信息数据集</returns>
        public static DataSet UserAnswerFillDs()
        {
            return uab.FillDs();
        }
        /// <summary>
        /// 删除用户答题答案信息
        /// </summary>
        /// <param name="UserName">用户名称</param>
        public static void UserAnswerDelete(string UserName,string date)
        {
            uab.Delete(UserName,date);
        }
        /// <summary>
        /// 获取用户答对的单选题，多选题，填空题，判断题各题总分
        /// </summary>
        /// <param name="userID">用户编号</param>
        /// <returns>UserAnswer类型，返回用户答案实体集</returns>
        public static UserAnswer GetUserAnswer(string userID,string date,string paperID) 
        {
            UserAnswer answer = uab.GetUserAnswer(userID, date, paperID);
            answer.SingleProblem = uab.singleProblemSum(userID, date, paperID);
            answer.MultiProblem = uab.multiProblemSum(userID, date, paperID);
            answer.JudgeProblem = uab.judgeProblemSum(userID, date, paperID);
            answer.FillBlankProblem = uab.fillBlankProblemSum(userID, date, paperID);
            return answer;
        }
        /// <summary>
        /// 添加用户答案信息
        /// </summary>
        /// <param name="UA">用户答案实体集的键值对集合</param>
        public static void AddUserAnswer(Dictionary<string,UserAnswer> UA)
        {
            foreach (KeyValuePair<string,UserAnswer> a in UA)
            {
                uab.AddUserAnswer(a);
            }
        }
        /// <summary>
        /// 获取用户简答题答案信息临时表
        /// </summary>
        /// <param name="userID">用户编号</param>
        /// <returns>DataSet类型，返回用户简答题答案信息临时表数据集</returns>
        public static DataSet QuestionFillDs(string userID, string date,string paperID)
        {
            return uab.QuestionFillDs(userID, date, paperID);
        }
        /// <summary>
        /// 评定并获取简答题总分
        /// </summary>
        /// <returns>int类型，返回整数类型的简答题总分</returns>
        public static int QuestionSum()
        {
            return uab.QuestionSum();
        }
        /// <summary>
        /// 删除用户简答题信息临时表
        /// </summary>
        public static void QuestionDrop()
        {
            uab.QuestionDrop();
        }
    }
}
