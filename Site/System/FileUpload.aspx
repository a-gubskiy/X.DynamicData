<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="Site.FileUploadPage" %>

<asp:Content ID="main_content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1><%=Resources.Global.FileUploadPageTitle %></h1>
    <%=Resources.Global.FileUploadDescription %>
    <br />
    <br />
    <%=Resources.Global.File %>: <asp:FileUpload ID="file_upload" runat="server" />&nbsp;<asp:Button CssClass="btn btn-primary" runat="server" ID="do_upload" Text="<%$Resources:Global, UploadFile  %>" OnClick="do_upload_Click"/>
    <br /><br />
    <div id="result" runat="server" clientidmode="Static" Visible="False">
        <div class="input-prepend">
            <span class="add-on">Ссылка на файл</span>
            <input class="col-md-4" runat="server" ClientIDMode="Static" id="prependedInput" type="text" placeholder="Url" />
            <br />
            <img src="" width="400" runat="server" Visible="False" clientidmode="Static" id="uploaded_image"/>
        </div>
    </div>
</asp:Content>

