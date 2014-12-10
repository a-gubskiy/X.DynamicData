using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.UI.WebControls;
using X.DynamicData.Core;

namespace Site
{
    public partial class Logs : XPage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!IsPostBack)
            {
                ShowPage(0);
            }
        }

        private IEnumerable<dynamic> GetData()
        {
            var logs = new EventLog("application", ".").Entries.Cast<EventLogEntry>();

            var entries = (from o in logs
                           where o.Source.Contains("ASP.NET")
                           //&& o.Message.Contains(Global.Context.WebsiteUrl)
                           select new
                               {
                                   o.InstanceId,
                                   Time = o.TimeGenerated,
                                   Message = Server.HtmlEncode(o.Message).Replace("\r", "").Replace("\n", "").Replace("\\", "\\\\"),
                                   Title = o.Message.Substring(0, 20),
                                   o.Category,
                                   Id = string.Format("d{0}", Guid.NewGuid())
                               }).ToList();

            return entries;

        }

        protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ShowPage(e.NewPageIndex);
        }

        private void ShowPage(int page)
        {
            GridView1.PageIndex = page;
            GridView1.DataSource = GetData();
            GridView1.DataBind();
        }
    }
}
