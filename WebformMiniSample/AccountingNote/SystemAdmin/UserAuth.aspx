﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAuth.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserAuth" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <table>
            <tr>
                <td colspan="2">
                    <h1>流水帳管理系統 - 後台</h1>
                </td>
            </tr>
            <tr>
                <td>
                    <a href="UserInfo.aspx">使用者資訊</a> <br />
                    <a href="AccountingList.aspx"> 流水帳管理 </a><br />
                    <a href="UserList.aspx">使用者管理</a> <br />
                </td>
                <td>
                    <!--這裡放主要內容-->
                    <table>
                        <tr>
                            <th>Account</th>
                            <td><asp:Literal runat="server" ID="ltAccount"></asp:Literal></td>
                        </tr>

                        <tr>
                            <th>Add Roles</th>
                            <td>
                                <asp:CheckBoxList ID="ckbRoleList" runat="server" DataValueField="ID" DataTextField="RoleName"></asp:CheckBoxList>
                                <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" />
                            </td>
                        </tr>

                        <tr>
                            <th>Roles</th>
                            <td>
                                <asp:Repeater ID="rptRoleList" runat="server">
                                    <ItemTemplate>
                                        <%# Eval("RoleName") %> 
                                        <asp:Button runat="server" CommandName="DeleteRole" CommandArgument='<%# Eval("ID") %>' Text="Remove" />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>