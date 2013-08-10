<%@ Control Language="C#" AutoEventWireup="true" Inherits="Site.FileUpload_Edit" Codebehind="FileUpload_Edit.ascx.cs" %>

<asp:FileUpload ID="FileUpload1" runat="server" />
<br /> 
<asp:Label ID="Label1" runat="server" Text="<%# FieldValueString %>"></asp:Label> ( <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink> )&nbsp;&nbsp;

<asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage=""></asp:CustomValidator>