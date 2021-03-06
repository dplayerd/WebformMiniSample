using AccountingNote.Auth;
using AccountingNote.DBSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.SystemAdmin
{
    public partial class UserList : AdminPageBase
    {
        public override UserLevelEnum RequiredLevel { get; set; } = UserLevelEnum.Admin;

        protected void Page_Load(object sender, EventArgs e)
        {
            var list = UserInfoManager.GetUserInfoList();
            this.gvList.DataSource = list;
            this.gvList.DataBind();
        }
    }
}