using System;
using System.Linq;
using System.Web.DynamicData;
using System.Web.Routing;
using System.Web.UI.WebControls;
using X.DynamicData.Core;

namespace Site
{
    public partial class List : XPage
    {
        private string PageIndexKey
        {
            get { return String.Format("PrevPageIndex_{0}", _table.Name).ToLower(); }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            GridView1.SetMetaTable(_table, _table.GetColumnValuesFromRoute(Context));
            GridDataSource.EntityTypeFilter = _table.EntityType.Name;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GridDataSource.Include = _table.ForeignKeyColumnsNames;

            // Disable various options if the table is readonly
            if (_table.IsReadOnly)
            {
                GridView1.Columns[0].Visible = false;
                InsertHyperLink.Visible = false;
                GridView1.EnablePersistedSelection = false;
            }

            var dataSourceTable = GridDataSource.GetTable();
            GridView1.ColumnsGenerator = new HideColumnFieldsManager(dataSourceTable);

            if (!IsPostBack && !IsAsync)
            {
                if (Request.UrlReferrer != null)
                {
                    if (Request.UrlReferrer.ToString().Contains("Edit.aspx"))
                    {
                        if (Session[PageIndexKey] != null)
                        {
                            GridView1.PageIndex = (int)Session[PageIndexKey];
                        }
                    }
                }
            }
        }


        protected void Label_PreRender(object sender, EventArgs e)
        {
            var label = (Label)sender;
            var dynamicFilter = (DynamicFilter)label.FindControl("DynamicFilter");
            var fuc = dynamicFilter.FilterTemplate as QueryableFilterUserControl;
            
            if (fuc != null && fuc.FilterControl != null)
            {
                label.AssociatedControlID = fuc.FilterControl.GetUniqueIDRelativeTo(label);
            }
        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            var routeValues = new RouteValueDictionary(GridView1.GetDefaultValues());
            InsertHyperLink.NavigateUrl = _table.GetActionPath(PageAction.Insert, routeValues);
            base.OnPreRenderComplete(e);
        }

        protected void DynamicFilter_FilterChanged(object sender, EventArgs e)
        {
            GridView1.PageIndex = 0;
        }

        protected void RemoveSelectedRows(object sender, EventArgs e)
        {
            var result = (from o in GridView1.Rows.Cast<GridViewRow>()
                          let cell = o.Cells[0]
                          let checkbox = cell.Controls[1] as CheckBox
                          where checkbox != null && checkbox.Checked
                          select o);

            foreach (var row in result)
            {
                GridView1.DeleteRow(row.RowIndex);
            }
        }

        protected void PageIndexChanged(object sender, EventArgs e)
        {
            Session.Add(PageIndexKey, GridView1.PageIndex);
        }
    }

    //public partial class List : System.Web.UI.Page
    //{
    //    protected MetaTable _table;

    //    private string PageIndexKey
    //    {
    //        get { return String.Format("PrevPageIndex_{0}", _table.Name).ToLower(); }
    //    }

    //    protected void Page_Init(object sender, EventArgs e)
    //    {
    //        _table = DynamicDataRouteHandler.GetRequestMetaTable(Context);
    //        GridView1.SetMetaTable(_table, _table.GetColumnValuesFromRoute(Context));
    //        GridDataSource.EntityTypeFilter = _table.EntityType.Name;

    //    }

    //    protected void Page_Load(object sender, EventArgs e)
    //    {
    //        Title = _table.DisplayName;
    //        GridDataSource.Include = _table.ForeignKeyColumnsNames;

    //        // Disable various options if the table is readonly
    //        if (_table.IsReadOnly)
    //        {
    //            GridView1.Columns[0].Visible = false;
    //            InsertHyperLink.Visible = false;
    //            GridView1.EnablePersistedSelection = false;
    //        }
    //    }

    //    protected void Label_PreRender(object sender, EventArgs e)
    //    {
    //        Label label = (Label)sender;
    //        DynamicFilter dynamicFilter = (DynamicFilter)label.FindControl("DynamicFilter");
    //        QueryableFilterUserControl fuc = dynamicFilter.FilterTemplate as QueryableFilterUserControl;
    //        if (fuc != null && fuc.FilterControl != null)
    //        {
    //            label.AssociatedControlID = fuc.FilterControl.GetUniqueIDRelativeTo(label);
    //        }
    //    }

    //    protected override void OnPreRenderComplete(EventArgs e)
    //    {
    //        RouteValueDictionary routeValues = new RouteValueDictionary(GridView1.GetDefaultValues());
    //        InsertHyperLink.NavigateUrl = _table.GetActionPath(PageAction.Insert, routeValues);
    //        base.OnPreRenderComplete(e);
    //    }

    //    protected void DynamicFilter_FilterChanged(object sender, EventArgs e)
    //    {
    //        GridView1.PageIndex = 0;
    //    }

    //    protected void RemoveSelectedRows(object sender, EventArgs e)
    //    {
    //        var result = (from o in GridView1.Rows.Cast<GridViewRow>()
    //                      let cell = o.Cells[0]
    //                      let checkbox = cell.Controls[1] as CheckBox
    //                      where checkbox != null && checkbox.Checked
    //                      select o);

    //        foreach (var row in result)
    //        {
    //            GridView1.DeleteRow(row.RowIndex);
    //        }
    //    }

    //    protected void PageIndexChanged(object sender, EventArgs e)
    //    {
    //        Session.Add(PageIndexKey, GridView1.PageIndex);
    //    }
    //}
}
