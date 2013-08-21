<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeBehind="List.aspx.cs" Inherits="Site.List" %>

<%@ Register Src="~/DynamicData/Content/GridViewPager.ascx" TagName="GridViewPager" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h1><%= _table.DisplayName%></h1>

    <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
        <DataControls>
            <asp:DataControlReference ControlID="GridView1" />
        </DataControls>
    </asp:DynamicDataManager>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <div class="load-progress">
                        Загрузка: &nbsp;
                        <img src="/images/ajax-loader.gif">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>

            <div class="DD">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="true"
                    HeaderText="List of validation errors" CssClass="DDValidator" />
                <asp:DynamicValidator runat="server" ID="GridViewValidator" ControlToValidate="GridView1" Display="None" CssClass="DDValidator" />

                <asp:QueryableFilterRepeater runat="server" ID="FilterRepeater">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("DisplayName") %>' OnPreRender="Label_PreRender" />
                        <asp:DynamicFilter runat="server" ID="DynamicFilter" OnFilterChanged="DynamicFilter_FilterChanged" />
                        <br />
                    </ItemTemplate>
                </asp:QueryableFilterRepeater>
                <br />
            </div>

            <asp:GridView ID="GridView1" runat="server" DataSourceID="GridDataSource" EnablePersistedSelection="true" AllowPaging="True" AllowSorting="True" CssClass="table table-bordered table-hover table-condensed grid-view" GridLines="None">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox CssClass="select_all" ID="select_all_rows" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox CssClass="select" ID="select_row" runat="server" />
                            <asp:DynamicHyperLink CssClass="glyphicon glyphicon-pencil" ID="edit_link" runat="server" Action="Edit" Text=" " />&nbsp;
                            <asp:LinkButton CssClass="glyphicon glyphicon-remove" ID="delete_link" runat="server" CommandName="Delete" Text=" " OnClientClick="<%$ Resources:Global, AreYourSureToRemoveRecord %>" />&nbsp;
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <PagerStyle CssClass="DDFooter" />
                <PagerTemplate>
                    <asp:GridViewPager ID="GridViewPager1" runat="server" />
                </PagerTemplate>
                <EmptyDataTemplate>
                    <%=Resources.Global.NoSuchItem %>
                </EmptyDataTemplate>
            </asp:GridView>

            <asp:EntityDataSource ID="GridDataSource" runat="server" EnableDelete="true" />

            <asp:QueryExtender TargetControlID="GridDataSource" ID="GridQueryExtender" runat="server">
                <asp:DynamicFilterExpression ControlID="FilterRepeater" />
            </asp:QueryExtender>

            <br />

            <div class="DDBottomHyperLink">
                <asp:DynamicHyperLink ID="InsertHyperLink" CssClass="btn btn-default" runat="server" Action="Insert" Text="<%$ Resources:Global, Add %>"></asp:DynamicHyperLink>
                <asp:Button OnClick="RemoveSelectedRows" runat="server" ID="RemoveSelected" CssClass="btn btn-danger" Text="<%$ Resources:Global, RemoveSelected %>" OnClientClick="<%$ Resources:Global, AreYourSureToRemoveRecords %>" />
            </div>



        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            intializeGridViewSelectAllCheckbox();
        }
    </script>

</asp:Content>

