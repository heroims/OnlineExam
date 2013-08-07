using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using 在线考试系统.Dal;
using 在线考试系统.Model;
namespace 在线考试系统.Bll
{
    class RoleBll
    {
        static RoleDal role = new RoleDal();
        /// <summary>
        /// 获取角色授权信息数据集
        /// </summary>
        /// <param name="RoleID">角色编号</param>
        /// <returns>DataSet类型，表示角色授权信息数据集</returns>
        public static DataSet RoleFillDs(string RoleID)
        {
            return role.FillDs(RoleID);
        }
        public static DataSet RoleFillDs()
        {
            return role.FillDs();
        }
        /// <summary>
        /// 更新角色授权信息
        /// </summary>
        public static void RoleUpdate()
        {
            role.Update();
        }
        /// <summary>
        /// 添加用户角色
        /// </summary>
        /// <param name="RoleName">角色名称</param>
        public static void AddRole(string RoleName)
        {
            role.AddRole(RoleName);
        }
        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="RoleID">角色编号</param>
        public static void DelRole(string RoleID)
        {
            role.DeleteRole(RoleID);
        }
        /// <summary>
        /// 判断是否存在角色
        /// </summary>
        /// <param name="RoleName">角色名称</param>
        /// <returns>bool类型，不存在返回true，存在返回false值</returns>
        public static bool GetRole(string RoleName)
        {
            return role.GetRole(RoleName);
        }
        /// <summary>
        /// 获取角色信息实体
        /// </summary>
        /// <param name="RoleID">角色编号</param>
        /// <returns>Role类型，返回角色信息实体</returns>
        public static Role GetRoleHasDuty(int RoleID)
        {
            return role.GetRoleHasDuty(RoleID);
        }
    }
}
