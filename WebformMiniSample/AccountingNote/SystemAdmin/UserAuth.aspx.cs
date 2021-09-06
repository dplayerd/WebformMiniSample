﻿using AccountingNote.DBSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.SystemAdmin
{
    public partial class UserAuth : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)                           // 可能是按鈕跳回本頁，所以要判斷 postback
            {
                string userIDText = Request.QueryString["ID"];

                if (string.IsNullOrWhiteSpace(userIDText))
                    return;

                Guid userID = Guid.Parse(userIDText);
                var mUser = UserInfoManager.GetUserInfo(userID);

                if (mUser == null)                             // 如果帳號不存在，導至使用者管理
                {
                    Response.Redirect("UserList.aspx");
                    return;
                }

                this.ltAccount.Text = mUser.Account;


                this.ckbRoleList.DataSource = RoleManager.GetRoleList();
                this.ckbRoleList.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<string> willSaveIDList = new List<string>();

            foreach (ListItem li in this.ckbRoleList.Items)
            {
                if (li.Selected)
                    willSaveIDList.Add(li.Value);
            }

            if (willSaveIDList.Count == 0)
                return;


            var roleList =
                willSaveIDList.Select(obj => Guid.Parse(obj)).ToArray();

            string userIDText = Request.QueryString["ID"];
            Guid userID = Guid.Parse(userIDText);

            Auth.AuthManager.MapUserAndRole(userID, roleList);
        }
    }
}