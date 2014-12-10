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

//using System;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.Web.DynamicData;
//using System.Web.Routing;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.Expressions;

//namespace Site
//{
//    public partial class Insert : System.Web.UI.Page
//    {
//        protected MetaTable table;

//        protected void Page_Init(object sender, EventArgs e)
//        {
//            table = DynamicDataRouteHandler.GetRequestMetaTable(Context);
//            FormView1.SetMetaTable(table, table.GetColumnValuesFromRoute(Context));
//            DetailsDataSource.EntityTypeFilter = table.EntityType.Name;
//        }

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            Title = table.DisplayName;
//        }

//        protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
//        {
//            if (e.CommandName == DataControlCommands.CancelCommandName)
//            {
//                Response.Redirect(table.ListActionPath);
//            }
//        }

//        protected void FormView1_ItemInserted(object sender, FormViewInsertedEventArgs e)
//        {
//            if (e.Exception == null || e.ExceptionHandled)
//            {
//                Response.Redirect(table.ListActionPath);
//            }
//        }

//    }
//}
