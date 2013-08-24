<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Password_Edit.ascx.cs" Inherits="Site.Password_EditField" %>

<div class="input-group">
    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control password" Text='<%# FieldValueEditString %>' TextMode="Password"></asp:TextBox>
</div>