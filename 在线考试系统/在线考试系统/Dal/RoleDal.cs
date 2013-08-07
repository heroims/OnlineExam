using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using 在线考试系统.Model;
namespace 在线考试系统.Dal
{
    class RoleDal
    {
        SqlHelp SH = new SqlHelp();
        /// <summary>
        /// 获取角色授权信息数据集
        /// </summary>
        /// <param name="RoleID">角色编号</param>
        /// <returns>DataSet类型，表示角色授权信息数据集</returns>
        public DataSet FillDs(string RoleID)
        {
            string str = "select RoleID,RoleName,HasDuty_userManage,HasDuty_courseManage,HasDuty_paperSetup,HasDuty_userPaperList,HasDuty_Role,HasDuty_paperLists,HasDuty_userScore,HasDuty_QuestionManage from Role where RoleID=@RoleID";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@RoleID", RoleID);
            return SH.SqlFillDs();
        }
        public DataSet FillDs()
        {
            string str = "select RoleID,RoleName from Role";
            SH.SqlCom(str, CommandType.Text);
            return SH.SqlFillDs();
        }
        /// <summary>
        /// 更新角色授权信息
        /// </summary>
        public void Update()
        {
            SH.SqlUpdate();
        }
        /// <summary>
        /// 添加用户角色
        /// </summary>
        /// <param name="RoleName">角色名称</param>
        public void AddRole(string RoleName)
        {
            string str = "select count(*)from Role";
            SH.SqlCom(str, CommandType.Text);
            string RoleID =((int) SH.SqlES()+1).ToString();
            str = "insert Role(RoleID,RoleName) values(@RoleID,@RoleName)";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@RoleName", RoleName);
            SH.SqlPar("@RoleID", RoleID);
            SH.SqlENQ();
        }
        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="RoleID">角色编号</param>
        public void DeleteRole(string RoleID)
        {
            string str = "delete Role where RoleID=@RoleID";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("RoleID", RoleID);
            SH.SqlENQ();
            str = "update Role set RoleID-=1 where RoleID>@RoleID";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("RoleID", RoleID);
            SH.SqlENQ();
        }
        /// <summary>
        /// 判断是否存在角色
        /// </summary>
        /// <param name="RoleName">角色名称</param>
        /// <returns>bool类型，不存在返回true，存在返回false值</returns>
        public bool GetRole(string RoleName)
        {
            string str = "select count(*) from Role where RoleName=@RoleName";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@RoleName", RoleName);
            if ((int)SH.SqlES()==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取角色信息实体
        /// </summary>
        /// <param name="RoleID">角色编号</param>
        /// <returns>Role类型，返回角色信息实体</returns>
        public Role GetRoleHasDuty(int RoleID)
        {
            Role role = new Role();
            string str = "select RoleID, CONVERT(int,HasDuty_userManage) HasDuty_userManage,CONVERT(int,HasDuty_Role) HasDuty_Role,CONVERT(int,HasDuty_userScore) HasDuty_userScore,CONVERT(int,HasDuty_courseManage) HasDuty_courseManage,CONVERT(int,HasDuty_paperSetup) HasDuty_paperSetup,CONVERT(int,HasDuty_paperLists) HasDuty_paperLists,CONVERT(int,HasDuty_userPaperList) HasDuty_userPaperList,CONVERT(int,HasDuty_QuestionManage) HasDuty_QuestionManage from Role where RoleID=@RoleID";
            SH.SqlCom(str, CommandType.Text);
            SH.SqlPar("@RoleID", RoleID.ToString());
            DataSet ds = SH.SqlFillDs();
            role.RoleID = (int)ds.Tables[0].Rows[0].ItemArray[0];
            role.UserManage = (int)ds.Tables[0].Rows[0].ItemArray[1];
            role.Role1 = (int)ds.Tables[0].Rows[0].ItemArray[2];
            role.UserScore = (int)ds.Tables[0].Rows[0].ItemArray[3];
            role.CourseManage = (int)ds.Tables[0].Rows[0].ItemArray[4];
            role.PaperSetup = (int)ds.Tables[0].Rows[0].ItemArray[5];
            role.PaperLists = (int)ds.Tables[0].Rows[0].ItemArray[6];
            role.UserPaperList = (int)ds.Tables[0].Rows[0].ItemArray[7];
            role.QuestionManage = (int)ds.Tables[0].Rows[0].ItemArray[8];
            return role;
        }
    }
}
