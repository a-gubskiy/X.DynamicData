<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Tel_Edit.ascx.cs" Inherits="Site.Tel_EditField" %>

<div class="input-group">
    <span class="input-group-addon"><i class="glyphicon glyphicon-phone"></i></span>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control phone" Text='<%# FieldValueEditString %>' TextMode="Phone"></asp:TextBox>
</div>