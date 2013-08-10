<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmailAddress_Edit.ascx.cs" Inherits="Site.EmailAddress_EditField" %>

<div class="input-prepend"><span class="add-on"><i class="icon-envelope"></i></span>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="DDTextBox" Text='<%# FieldValueEditString %>' TextMode="Email"></asp:TextBox>
</div>

<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" Enabled="false" />
<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" Enabled="false" />
<asp:DynamicValidator runat="server" ID="DynamicValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" />
