using System;
using System.Web.Helpers;
using X.DynamicData.Core;

namespace Site
{
    public partial class ServerInformation : XPage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        
            var html = @"<style type=""text/css"">  div.server-info { text-align: center; }  table.server-info { border-collapse:collapse; text-align:center; margin: auto; width:600px; direction: ltr; }  table.server-info tbody tr:nth-child(even){ background-color: #EEE; }  table.server-info, table.server-info th, table.server-info td { border:1px solid black; }  table.server-info th, table.server-info td  { text-align:left; padding:2px; font-family:Tahoma, Arial, sans-serif; font-size:0.75em; }  h1.server-info { font-family:Tahoma, Arial, sans-serif; font-size:150%; text-align:center; }  table.server-info h2 { font-family:Tahoma, Arial, sans-serif; font-size:125%; text-align:center; }  p.server-info { text-align:center; font-family:Tahoma, Arial, sans-serif; font-size:0.75em; }  .ital { font-style: italic; }   .warn { color: #F00; } </style>";
            html = ServerInfo.GetHtml().ToHtmlString().Replace(html, String.Empty);
        
            html = html.Replace("<h1 class=\"server-info\">ASP.NET Server Information</h1>", String.Empty);
            html = html.Replace("h2", "h3");
            html = html.Replace("<div>", String.Empty);
            html = html.Replace("</div>", String.Empty);
            html = html.Replace(" dir=\"ltr\"", String.Empty);
            html = html.Replace("server-info", "table table-bordered table-hover table-condensed");
            html = html.Replace("<div class=\"table table-bordered table-hover table-condensed\">", String.Empty);
            html = html.Replace("table table-bordered table-hover table-condensed", "table table-bordered table-hover table-condensed information");

            server_information.InnerHtml = html;
        }
    }
}