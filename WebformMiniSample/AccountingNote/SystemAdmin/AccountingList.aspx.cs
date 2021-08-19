using AccountingNote.Auth;
using AccountingNote.DBSource;
using AccountingNote.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.SystemAdmin
{
    public partial class AccountingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // check is logined
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            var currentUser = AuthManager.GetCurrentUser();

            if (currentUser == null)        // 如果帳號不存在，導至登入頁
            {
                this.Session["UserLoginInfo"] = null;
                Response.Redirect("/Login.aspx");
                return;
            }

            // read accounting data
            var list = AccountingManager.GetAccountingList(currentUser.UserGuid);

            if (list.Count > 0)  // check is empty data
            {
                var pagedList = this.GetPagedDataTable(list);

                this.gvAccountingList.DataSource = pagedList;
                this.gvAccountingList.DataBind();

                this.ucPager.TotalSize = list.Count;
                this.ucPager.Bind();
            }
            else
            {
                this.gvAccountingList.Visible = false;
                this.plcNoData.Visible = true;
            }
        }

        private int GetCurrentPage()
        {
            string pageText = Request.QueryString["Page"];

            if (string.IsNullOrWhiteSpace(pageText))
                return 1;
            int intPage;
            if (!int.TryParse(pageText, out intPage))
                return 1;
            if (intPage <= 0)
                return 1;
            return intPage;
        }

        private List<Accounting> GetPagedDataTable(List<Accounting> list)
        {
            int startIndex = (this.GetCurrentPage() - 1) * 10;
            return list.Skip(startIndex).Take(10).ToList();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/AccountingDetail.aspx");
        }

        protected void gvAccountingList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var row = e.Row;

            if (row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = row.FindControl("lblActType") as Label;

                var rowData = row.DataItem as Accounting;
                int actType = rowData.ActType;

                if (actType == 0)
                {
                    lbl.Text = "支出";
                }
                else
                {
                    lbl.Text = "收入";
                }

                if (rowData.Amount > 1500)
                {
                    lbl.ForeColor = Color.Red;
                }
            }
        }
    }
}