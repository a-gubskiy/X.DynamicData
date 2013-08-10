using System;
using System.Web.DynamicData;
using System.Web.UI.WebControls;
using X.DynamicData.Core;

namespace Site
{
    public partial class Details : XPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            FormView1.SetMetaTable(_table);
            DetailsDataSource.EntityTypeFilter = _table.EntityType.Name;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            DetailsDataSource.Include = _table.ForeignKeyColumnsNames;
        }

        protected void FormView1_ItemDeleted(object sender, FormViewDeletedEventArgs e)
        {
            if (e.Exception == null || e.ExceptionHandled)
            {
                Response.Redirect(_table.ListActionPath);
            }
        }

    }
}
