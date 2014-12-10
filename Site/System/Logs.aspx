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
                    <!-- Button trigger modal -->
                    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#<%# Eval("Id") %>">
                        <%=Resources.Global.ShowDetails %>
                    </button>

                    <div class="modal fade" id="<%# Eval("Id") %>">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                    <h4 class="modal-title">Modal title</h4>
                                </div>
                                <div class="modal-body">
                                    <p><%# Eval("Message") %></p>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                        <!-- /.modal-dialog -->
                    </div>
                    <!-- /.modal -->

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

</asp:Content>
