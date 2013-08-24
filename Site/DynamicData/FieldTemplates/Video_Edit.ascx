<%@ Control Language="C#" AutoEventWireup="true" Inherits="Site.Video_EditField" CodeBehind="Video_Edit.ascx.cs" %>

<div class="input-group">
    <span class="input-group-addon"><i class="glyphicon glyphicon-facetime-video"></i></span>
    <asp:TextBox ID="TextBox1" TextMode="MultiLine" runat="server" Text='<%# FieldValueEditString %>' CssClass="DDTextBox"></asp:TextBox>
</div>

<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" Enabled="false" />
<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" Enabled="false" />
<asp:DynamicValidator runat="server" ID="DynamicValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" />

<br />
<br />

<%--<a href="#" class="thumbnail video-container">--%>
    <div id="video_container" class="video-container" runat="server"></div>
<%--</a>--%>