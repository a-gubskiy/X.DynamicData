using System;
using System.Linq;
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
                table_links.InnerHtml = String.Join(String.Empty, (from o in Navigator.GetEntitiesLinks()
                                                                   select String.Format("<a class=\"btn btn-default square\" href=\"{0}\"><i class=\"{1}\"></i><br />{2}</a>", o.Url, o.Icon, o.Title)).ToArray());

                custom_links.InnerHtml = String.Join(String.Empty, (from o in Navigator.GetCustomLinks()
                                                                    select String.Format("<a class=\"btn btn-default square\" href=\"{0}\"><i class=\"{1}\"></i><br />{2}</a>", o.Url, o.Icon, o.Title)).ToArray());

                system_links.InnerHtml = String.Join(String.Empty, (from o in Navigator.GetSystemLinks()
                                                                    select String.Format("<a class=\"btn btn-default square\" href=\"{0}\"><i class=\"{1}\"></i><br />{2}</a>", o.Url, o.Icon, o.Title)).ToArray());

                plugin_widget.Visible = Navigator.GetCustomLinks().Any();
            }

            if (!Global.CanCreateDataContext())
            {
                ShowMessage(Resources.Global.CantInitDataModelAssembly, Resources.Global.Warning, MessageBoxIcon.Stop);
            }

            if (Global.MetaModel.VisibleTables.Count == 0)
            {
                ShowMessage(Resources.Global.ModelIsEmpty, Resources.Global.Warning, MessageBoxIcon.Warning);
            }
            
            login_title.InnerHtml = String.Format("{0}: <strong>{1}</strong>.<br />{2}: <strong>{3}</strong>.",
                Resources.Global.YouWorkWithProject, Global.Context.Title, Resources.Global.YouLoginAs, WebSecurity.CurrentUserName);
        }
    }
}