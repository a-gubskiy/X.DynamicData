using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace X.DynamicData.Core
{
    public static class Navigator
    {
        public static Dictionary<string, string> CustomLinks { get; private set; }

        public static void AddCustomLink(string text, string url)
        {
            CustomLinks.Add(text, url);
        }

        static Navigator()
        {
            CustomLinks = new Dictionary<string, string>();
        }



        public static string Render()
        {
            var sb = new StringBuilder();

            sb.AppendFormat(RenderLink("/", "icon-home", Global.GetText("HomePageTitle")));

            sb.AppendFormat(RenderLink("/System/manage.aspx", "icon-cog", Global.GetText("ManagePageTitle")));

            foreach (var link in CustomLinks)
            {
                sb.AppendFormat(RenderLink(link.Value, "icon-th-large", link.Key));
            }

            if (Global.MetaModel.VisibleTables.Count > 0)
            {
                //When DAL library not loadad correct
                var items = (from o in Global.MetaModel.VisibleTables
                             where o.Scaffold
                             orderby o.DisplayName
                             select o).ToList();

                foreach (var table in items)
                {
                    var url = String.Format("/{0}/List.aspx", table.Name);
                    sb.AppendFormat(RenderLink(url, "icon-list-alt", table.DisplayName));

                }

            }

            if (Global.Context.ShowLogsInMenu)
            {
                sb.AppendFormat(RenderLink("/System/logs.aspx", "icon-book", "Системные логи"));
            }

            sb.AppendFormat(RenderLink("/System/FileUpload.aspx", "icon-upload", Global.GetText("FileUploadPageTitle")));
            sb.AppendFormat(RenderLink("/System/systeminformation.aspx", "icon-info-sign", Global.GetText("SystemInformationPageTite")));
            sb.AppendFormat(RenderLink("/System/serverinformation.aspx", "icon-hdd", Global.GetText("ServerInformationPageTite")));
            sb.AppendFormat(RenderLink("/System/login.aspx?logout=true", "icon-share", Global.GetText("Logout")));

            return sb.ToString();
        }

        private static string RenderLink(string url, string @class, string title)
        {
            var virtualUrl = "~" + url;

            if (UrlAuthorizationModule.CheckUrlAccessForPrincipal(virtualUrl, HttpContext.Current.User, "GET"))
            {
                return String.Format("<li><a href=\"{0}\"><i class=\"{1}\"></i>{2}</a></li>", url, @class, title);
            }

            return String.Empty;
        }
    }
}
