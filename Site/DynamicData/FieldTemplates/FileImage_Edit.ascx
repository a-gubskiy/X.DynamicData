<%@ Control Language="C#" AutoEventWireup="true" Inherits="Site.FileImage_Edit" CodeBehind="FileImage_Edit.ascx.cs" %>


<span class="thumbnail">
    <asp:Image ID="ImageEdit" ImageUrl="<%# String.IsNullOrEmpty(FieldValueString) ? String.Empty : X.DynamicData.Core.Global.Context.FileStorageUrl + FieldValueString %>" runat="server" />
</span>

<br />

<asp:FileUpload ID="FileUploadEdit" runat="server" />
<asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage=""></asp:CustomValidator>
<asp:HiddenField ID="image_name" Value="<%# FieldValueString %>" runat="server" />
