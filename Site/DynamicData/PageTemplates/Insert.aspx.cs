using System;
using System.Web.DynamicData;
using System.Web.UI.WebControls;
using X.DynamicData.Core;

namespace Site
{
    public partial class Insert : XPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            CheckPartialRendering(_table);
            FormView1.SetMetaTable(_table, _table.GetColumnValuesFromRoute(Context));
            DetailsDataSource.EntityTypeFilter = _table.EntityType.Name;
        }

        protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName == DataControlCommands.CancelCommandName)
            {
                Response.Redirect(_table.ListActionPath);
            }
        }

        protected void FormView1_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            if (e.Exception == null || e.ExceptionHandled)
            {
                var url = _table.ListActionPath + Request.Url.Query; //for saving filter on table
                Response.Redirect(url);
            }
            else
            {
                ShowMessage(e.Exception);
                e.ExceptionHandled = true;
            }
        }
    }
}
