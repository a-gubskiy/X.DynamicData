using System;
using System.Windows.Forms;
using WebMatrix.WebData;
using X.DynamicData.Core;

namespace Site
{
    public partial class _Default : XPage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Global.Context != null)
            {
                startup_menu.InnerHtml = Navigator.Render();
            }

            if (!Global.CanCreateDataContext())
            {
                ShowMessage(Resources.Global.CantInitDataModelAssembly, Resources.Global.Warning, MessageBoxIcon.Stop);
            }

            if (Global.MetaModel.VisibleTables.Count == 0)
            {
                ShowMessage(Resources.Global.ModelIsEmpty, Resources.Global.Warning, MessageBoxIcon.Warning);
            }


            login_title.InnerHtml = String.Format("{0}: <i>{1}</i>. {2}: <i>{3}</i>",
                Resources.Global.YouWorkWithProject, Global.Context.Title, Resources.Global.YouLoginAs, WebSecurity.CurrentUserName);
        }
    }
}