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

        public static IEnumerable<Link> GetAllLinks()
        {
            var list = new List<Link>();

            AddLinkToList(list, "/", "glyphicon glyphicon-home", Global.GetText("HomePageTitle"));


            list.AddRange(GetCustomLinks());
            list.AddRange(GetEntitiesLinks());
            list.AddRange(GetSystemLinks());

            return list;
        }

        public static IEnumerable<Link> GetEntitiesLinks()
        {
            var list = new List<Link>();

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
                    AddLinkToList(list, url, "glyphicon glyphicon-list-alt", table.DisplayName);

                }
            }

            return list;
        }

        public static IEnumerable<Link> GetSystemLinks()
        {
            var list = new List<Link>();

            AddLinkToList(list, "/System/manage.aspx", "glyphicon glyphicon-cog", Global.GetText("ManagePageTitle"));

            if (Global.Context.ShowLogsInMenu)
            {
                AddLinkToList(list, "/System/logs.aspx", "glyphicon glyphicon-book", "Системные логи");
            }

            AddLinkToList(list, "/System/FileUpload.aspx", "glyphicon glyphicon-upload", Global.GetText("FileUploadPageTitle"));
            AddLinkToList(list, "/System/systeminformation.aspx", "glyphicon glyphicon-info-sign", Global.GetText("SystemInformationPageTite"));
            AddLinkToList(list, "/System/serverinformation.aspx", "glyphicon glyphicon-hdd", Global.GetText("ServerInformationPageTite"));
            AddLinkToList(list, "/System/login.aspx?logout=true", "glyphicon glyphicon-share", Global.GetText("Logout"));

            return list;
        }

        public static IEnumerable<Link> GetCustomLinks()
        {
            var list = new List<Link>();

            foreach (var link in CustomLinks)
            {
                AddLinkToList(list, link.Value, "icon-th-large", link.Key);
            }

            return list;
        }

        private static void AddLinkToList(List<Link> list, string url, string @class, string title)
        {
            var virtualUrl = "~" + url;

            if (UrlAuthorizationModule.CheckUrlAccessForPrincipal(virtualUrl, HttpContext.Current.User, "GET"))
            {
                var link = new Link(url, @class, title);
                list.Add(link);
            }
        }    
    }
}
