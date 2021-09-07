﻿using AccountingNote.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingNote.DBSource
{
    public class RoleManager
    {
        /// <summary> 取得所有角色清單 </summary>
        /// <returns></returns>
        public static List<Role> GetRoleList()
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query = context.Roles;
                    var list = query.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary> 用名稱取得角色 </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public static Role GetRoleByName(string roleName)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Roles
                         where item.RoleName == roleName
                         select item);

                    var obj = query.FirstOrDefault();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary> 用 id 取得角色 </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Role GetRole(Guid id)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Roles
                         where item.ID == id
                         select item);

                    var obj = query.FirstOrDefault();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary> 將使用者帳號對應角色 </summary>
        /// <param name="userID"></param>
        /// <param name="roleIDs"></param>
        public static void MappingUserAndRole(Guid userID, Guid[] roleIDs)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var currentRole =
                        (from item in context.UserRoles
                         where
                             item.UserInfoID == userID &&
                             roleIDs.Contains(item.RoleID)
                         select item.RoleID).ToList();

                    // 排除目前已對應的角色 id
                    if (currentRole.Count > 0)
                    {
                        roleIDs = roleIDs.Except(currentRole).ToArray();
                    }


                    foreach (Guid roleID in roleIDs)
                    {
                        UserRole ur = new UserRole()
                        {
                            ID = Guid.NewGuid(),
                            UserInfoID = userID,
                            RoleID = roleID,
                            IsGrant = true
                        };

                        context.UserRoles.Add(ur);
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }


        /// <summary> 是否被授權 </summary>
        /// <param name="userID"></param>
        /// <param name="roleIDs"></param>
        /// <returns></returns>
        public static bool IsGrant(Guid userID, Guid[] roleIDs)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var currentRole =
                        (from item in context.UserRoles
                         where
                             item.UserInfoID == userID &&
                             roleIDs.Contains(item.RoleID)
                         select item).ToList();

                    // 一、未設定到期、或尚未到期
                    // 二、尚未設定啟用或停用、或仍為啟用
                    var query =
                        from item in currentRole
                        where
                            ((item.EndDate == null) ||
                             (item.EndDate.HasValue && item.EndDate.Value > DateTime.Now)) &&
                            ((item.IsGrant == null) ||
                             (item.IsGrant.Value))
                        select item;

                    bool isGrant = query.Any();
                    return isGrant;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                throw;
            }
        }
    }
}
