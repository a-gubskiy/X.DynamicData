using System;
using System.Linq;
using System.Text;
using System.Web.DynamicData;
using System.Web.UI;
using System.Windows.Forms;

namespace X.DynamicData.Core
{
    public class XPage : Page
    {
        protected MetaTable _table;

        public XMasterPage XMasterPage
        {
            get { return Master as XMasterPage; }
        }

        protected override void OnInit(EventArgs e)
        {
            _table = DynamicDataRouteHandler.GetRequestMetaTable(Context);

            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SetTitle();
        }

        protected virtual void SetTitle()
        {
            Title = _table != null
                        ? String.Format("{0} - {1}", _table.DisplayName, Global.Context.Title)
                        : Global.Context.Title;
        }

        protected void ShowMessage(string text, string caption, MessageBoxIcon icon = MessageBoxIcon.None)
        {
            if (XMasterPage != null)
            {
                XMasterPage.ShowMessage(text, caption, icon);
            }
        }

        protected void ShowMessage(Exception exception)
        {
            var text = GetExceptionMessage(exception);

            ShowMessage(text, Global.GetText("Warning"), MessageBoxIcon.Error);
        }

        private static string GetExceptionMessage(Exception exception)
        {
            var sb = new StringBuilder();

            if (exception != null)
            {
                sb.Append(exception.Message);
                sb.AppendLine(GetExceptionMessage(exception.InnerException));
            }

            return sb.ToString();
        }

        protected void CheckPartialRendering(MetaTable table)
        {
            var scriptManager = ScriptManager.GetCurrent(Page);

            if (scriptManager == null || !scriptManager.EnablePartialRendering)
            {
                return;
            }

            var disablePartialRendering = (from o in table.Columns
                                           where o.UIHint != null &&
                                                 (o.UIHint.Contains("File") || o.UIHint.Contains("Html"))
                                           select o).Any();



            if (disablePartialRendering)
            {
                scriptManager.EnablePartialRendering = false;
            }
        }

    }
}
