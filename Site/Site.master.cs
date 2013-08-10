using System;
using System.Text;
using System.Windows.Forms;
using WebMatrix.WebData;
using X.DynamicData.Core;

namespace Site
{
    public partial class SiteMasterPage : XMasterPage
    {
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            if (!WebSecurity.IsAuthenticated && Request.Url.AbsolutePath.ToLower() != "/system/login.aspx")
            {
                Response.Redirect("~/System/Login.aspx");
            }

            if (WebSecurity.IsAuthenticated)
            {
                menu.InnerHtml = Navigator.Render();
                brand.InnerText = Global.Context.Title;
                site_link.HRef = Global.Context.WebsiteUrl;
            }

            if (Global.Context.IsDebuggingEnabled && !IsPostBack)
            {
                ShowMessage(Resources.Global.SystemWorkInDebugMode, Resources.Global.Warning, MessageBoxIcon.Information);
            }

            top_nav.Visible = WebSecurity.IsAuthenticated;
        }

        public override void ShowMessage(string text, string caption, MessageBoxIcon icon)
        {
            var @class = String.Empty;

            switch (icon)
            {
                case MessageBoxIcon.Error:
                    @class = "alert alert-error";
                    break;
                case MessageBoxIcon.Information:
                    @class = "alert alert-success";
                    break;
                case MessageBoxIcon.None:
                    @class = "alert alert-info";
                    break;
                case MessageBoxIcon.Question:
                    @class = "alert alert-block";
                    break;
                case MessageBoxIcon.Warning:
                    @class = "alert alert-block";
                    break;
            }

            message_container.InnerHtml += RenderMessage(caption, text, @class);

            message_container.Visible = true;
        }

        private static string RenderMessage(string caption, string text, string @class)
        {
            var sb = new StringBuilder();
            
            sb.AppendFormat("<div class=\"alert {0}\">", @class);
            sb.AppendLine("<button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>");
            sb.AppendFormat("<strong>{0}</strong>&nbsp;<span>{1}</span>", caption, text);
            sb.AppendLine("</div>");

            return sb.ToString();
        }
    }
}
