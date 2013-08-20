<%@ Control Language="C#" CodeBehind="GridViewPager.ascx.cs" Inherits="Site.GridViewPager" %>

<div class="DDPager">

    <ul class="left pagination">
        <li><asp:LinkButton Text="<<" ID="ImageButtonFirst" runat="server" CommandName="Page" CommandArgument="First" /></li>
        <li><asp:LinkButton Text="<" ID="ImageButtonPrev" runat="server" CommandName="Page" CommandArgument="Prev" /></li>
        <li><span class="page-counter">Страница<asp:TextBox ID="TextBoxPage" runat="server" Columns="5" AutoPostBack="true" OnTextChanged="TextBoxPage_TextChanged" /> из <asp:Label ID="LabelNumberOfPages" runat="server" /></span></li>
        <li><asp:LinkButton Text=">" ID="ImageButtonNext" runat="server" CommandName="Page" CommandArgument="Next" /></li>
        <li><asp:LinkButton Text=">>" ID="ImageButtonLast" runat="server" CommandName="Page" CommandArgument="Last" /></li>
    </ul>

    <ul class="right pagination">
        <li>
            <span>
                <%=Resources.Global.RecordPerPage %>
                <asp:DropDownList ID="DropDownListPageSize" runat="server" AutoPostBack="true" CssClass="page-list" OnSelectedIndexChanged="DropDownListPageSize_SelectedIndexChanged">
                    <asp:ListItem Value="5" />
                    <asp:ListItem Value="10" />
                    <asp:ListItem Value="15" />
                    <asp:ListItem Value="20" />
                    <asp:ListItem Value="50" />
                    <asp:ListItem Value="100" />
                    <asp:ListItem Value="200" />
                </asp:DropDownList>
            </span>
        </li>
    </ul>

</div>
