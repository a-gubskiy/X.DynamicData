using System;
using System.Web.DynamicData;
using System.Web.UI.WebControls;
using X.DynamicData.Core;

namespace Site
{
    public partial class Edit : XPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            CheckPartialRendering(_table);
            FormView1.SetMetaTable(_table);
            DetailsDataSource.EntityTypeFilter = _table.EntityType.Name;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            DetailsDataSource.Include = _table.ForeignKeyColumnsNames;
        }

        protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName == DataControlCommands.CancelCommandName)
            {
                Response.Redirect(_table.ListActionPath);
            }
        }

        protected void FormView1_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            if (e.Exception == null || e.ExceptionHandled)
            {
                Response.Redirect(_table.ListActionPath);
            }
            else
            {
                ShowMessage(e.Exception);
                e.ExceptionHandled = true;
            }
        }

    }

    //public partial class Edit : System.Web.UI.Page
    //{
    //    protected MetaTable table;

    //    protected void Page_Init(object sender, EventArgs e)
    //    {
    //        table = DynamicDataRouteHandler.GetRequestMetaTable(Context);
    //        FormView1.SetMetaTable(table);
    //        DetailsDataSource.EntityTypeFilter = table.EntityType.Name;
    //    }

    //    protected void Page_Load(object sender, EventArgs e)
    //    {
    //        Title = table.DisplayName;
    //        DetailsDataSource.Include = table.ForeignKeyColumnsNames;
    //    }

    //    protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
    //    {
    //        if (e.CommandName == DataControlCommands.CancelCommandName)
    //        {
    //            Response.Redirect(table.ListActionPath);
    //        }
    //    }

    //    protected void FormView1_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    //    {
    //        if (e.Exception == null || e.ExceptionHandled)
    //        {
    //            Response.Redirect(table.ListActionPath);
    //        }
    //    }

    //}
}
