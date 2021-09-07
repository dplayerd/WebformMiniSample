﻿using AccountingNote.Auth;
using AccountingNote.DBSource;
using AccountingNote.Helpers;
using AccountingNote.Models;
using AccountingNote.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.SystemAdmin
{
    public partial class AccountingDetail : AdminPageBase
    {
        public override string[] RequiredRoles { get; set; } =
            new string[]
            {
                StaticText.RoleName_Announting_FinanceClerk,
                StaticText.RoleName_Announting_FinanceAdmin,
            };

        protected void Page_Load(object sender, EventArgs e)
        {
            var currentUser = AuthManager.GetCurrentUser();
            if (!this.IsPostBack)
            {
                // Check is create mode or edit mode
                if (this.Request.QueryString["ID"] == null)
                {
                    this.btnDelete.Visible = false;
                }
                else
                {
                    this.btnDelete.Visible = true;

                    string idText = this.Request.QueryString["ID"];
                    int id;
                    if (int.TryParse(idText, out id))
                    {
                        var accounting = AccountingManager.GetAccounting(id, currentUser.ID);

                        if (accounting == null)
                        {
                            this.ltMsg.Text = "Data doesn't exist";
                            this.btnSave.Visible = false;
                            this.btnDelete.Visible = false;
                        }
                        else
                        {
                            this.ddlActType.SelectedValue = accounting.ActType.ToString();
                            this.txtAmount.Text = accounting.Amount.ToString();
                            this.txtCaption.Text = accounting.Caption;
                            this.txtDesc.Text = accounting.Body;
                        }
                    }
                    else
                    {
                        this.ltMsg.Text = "ID is required.";
                        this.btnSave.Visible = false;
                        this.btnDelete.Visible = false;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<string> msgList = new List<string>();
            if (!this.CheckInput(out msgList))
            {
                this.ltMsg.Text = string.Join("<br/>", msgList);
                return;
            }


            UserInfoModel currentUser = AuthManager.GetCurrentUser();
            if (currentUser == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            string actTypeText = this.ddlActType.SelectedValue;
            string amountText = this.txtAmount.Text;
            int amount = Convert.ToInt32(amountText);
            int actType = Convert.ToInt32(actTypeText);

            string idText = this.Request.QueryString["ID"];
            Accounting accounting = new Accounting()
            {
                UserID = currentUser.ID,
                ActType = actType,
                Amount = amount,
                Caption = this.txtCaption.Text,
                Body = this.txtDesc.Text
            };


            // 假如有上傳檔案，就寫入檔名
            if (this.fileCover.HasFile &&
                FileHelper.ValidFileUpload(this.fileCover, out List<string> tempList))
            {
                string saveFileName = FileHelper.GetNewFileName(this.fileCover);
                string filePath = Path.Combine(this.GetSaveFolderPath(), saveFileName);
                this.fileCover.SaveAs(filePath);

                accounting.CoverImage = saveFileName;
            }


            if (string.IsNullOrWhiteSpace(idText))
            {
                // Execute 'Insert into db'
                AccountingManager.CreateAccounting(accounting);
            }
            else
            {
                int id;
                if (int.TryParse(idText, out id))
                {
                    // Execute 'update db'
                    accounting.ID = id;
                    AccountingManager.UpdateAccounting(accounting);
                }
            }

            Response.Redirect("/SystemAdmin/AccountingList.aspx");
        }

        private bool CheckInput(out List<string> errorMsgList)
        {
            List<string> msgList = new List<string>();

            // Type
            if (this.ddlActType.SelectedValue != "0" &&
                this.ddlActType.SelectedValue != "1")
            {
                msgList.Add("Type must be 0 or 1.");
            }

            //Amount
            if (string.IsNullOrWhiteSpace(this.txtAmount.Text))
                msgList.Add("Amount is required");
            else
            {
                int tempInt;
                if (!int.TryParse(this.txtAmount.Text, out tempInt))
                    msgList.Add("Amount must be a number.");

                if (tempInt < 0 || tempInt > 1000000)
                    msgList.Add("Amount must between 0 and 1,000,000 .");
            }

            errorMsgList = msgList;
            if (msgList.Count == 0)
                return true;
            else
                return false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string idText = this.Request.QueryString["ID"];

            if (string.IsNullOrWhiteSpace(idText))
                return;

            int id;
            if (int.TryParse(idText, out id))
            {
                // Execute 'delete db'
                AccountingManager.DeleteAccounting(id);
            }

            Response.Redirect("/SystemAdmin/AccountingList.aspx");
        }


        private string GetSaveFolderPath()
        {
            return Server.MapPath("~/FileDownload/Accounting");
        }
    }
}