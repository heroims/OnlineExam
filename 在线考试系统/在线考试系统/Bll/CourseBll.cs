using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using 在线考试系统.Dal;
using System.Windows.Forms;
namespace 在线考试系统.Bll
{
    class CourseBll
    {
        static CourseDal course = new CourseDal();
        /// <summary>
        /// 获取科目信息
        /// </summary>
        /// <returns>DataSet类型，返回科目信息数据集</returns>
        public static DataSet CourseFillDs()
        {
            return course.FillDs();
        }
        /// <summary>
        /// 添加科目信息
        /// </summary>
        /// <param name="CName">string类型，表示科目名称</param>
        public static void CourseAdd(string CName)
        {
            course.AddCou(CName);
        }
        /// <summary>
        /// 删除科目信息
        /// </summary>
        /// <param name="courseID">科目编号</param>
        public static void CourseDel(string courseID)
        {
            course.DeleteCou(courseID);
        }
        /// <summary>
        /// 绑定ComboBox
        /// </summary>
        /// <param name="cbo">将要绑定的ComboBox</param>
        public static void FillcboCourse(ComboBox cbo)
        {
            cbo.ValueMember = "courseID";
            cbo.DisplayMember = "courseName";
            cbo.DataSource = CourseFillDs().Tables[0];
        }
        /// <summary>
        /// 判断是否存在科目
        /// </summary>
        /// <param name="courseName">科目名称</param>
        /// <returns>bool类型，不存在返回true，存在返回false值</returns>
        public static bool GetCourse(string courseName)
        {
            return course.GetCourse(courseName);
        }
    }
}
