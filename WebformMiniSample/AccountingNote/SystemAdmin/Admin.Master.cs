using AccountingNote.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.SystemAdmin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 如果尚未登入，導至登入頁
            if (!AuthManager.IsLogined())                
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            var currentUser = AuthManager.GetCurrentUser();
            // 如果帳號不存在，導至登入頁
            if (currentUser == null)                             
            {
                Response.Redirect("/Login.aspx");
                return;
            }
        }
    }
}