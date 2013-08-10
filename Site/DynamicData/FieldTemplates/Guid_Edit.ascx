<%@ Control Language="C#" AutoEventWireup="true" Inherits="Site.Guid_EditField" Codebehind="Guid_Edit.ascx.cs" %>

<asp:TextBox ID="TextBox1" runat="server" Text='<%# FieldValueEditString %>' CssClass="DDTextBox"></asp:TextBox>
<asp:Button ID="generate_guid" Text="Сгенерировать Guid" runat="server" onclick="generate_guid_Click"/>

<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" Enabled="false" />
<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" Enabled="false" />
<asp:DynamicValidator runat="server" ID="DynamicValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" />

