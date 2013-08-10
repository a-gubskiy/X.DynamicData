<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Logs.aspx.cs" Inherits="Site.Logs" %>

<%@ Register Src="~/DynamicData/Content/GridViewPager.ascx" TagName="GridViewPager" TagPrefix="asp" %>

<asp:Content ID="main" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h2><%=Resources.Global.LogPageTitle %></h2>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="PageIndexChanging" DataKeyNames="InstanceId" EnablePersistedSelection="true" AllowPaging="True" AllowSorting="True" CssClass="table table-bordered table-hover table-condensed" GridLines="None">
        <Columns>
            <asp:BoundField DataField="Time" HeaderText="Time"></asp:BoundField>
            <asp:BoundField DataField="Title" HeaderText="Title"></asp:BoundField>
            <asp:BoundField DataField="Category" HeaderText="Category"></asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href="#" onclick="javascript:bootbox.alert('<%# Eval("Message") %>');"><%=Resources.Global.ShowMessage %></a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <Columns>
        </Columns>
        <PagerStyle CssClass="DDFooter" />
        <PagerTemplate>
            <asp:GridViewPager ID="GridViewPager1" runat="server" />
        </PagerTemplate>
        <EmptyDataTemplate>
            <%=Resources.Global.NoSuchItem %>
        </EmptyDataTemplate>
    </asp:GridView>
    
</asp:Content>
