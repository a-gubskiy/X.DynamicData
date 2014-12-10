using System;
using System.Data.SqlClient;
using System.Text;
using X.DynamicData.Core;

namespace Site
{
    public partial class SystemInformation : XPage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var sb = new StringBuilder();

            var dataContext = Global.CreateDataContext(Global.Context.DataContextAssemblyLocation);

            var connectionString = dataContext.Database.Connection.ConnectionString;

            connectionString = connectionString.Replace("metadata=res://*/DataModel.csdl|res://*/DataModel.ssdl|res://*/DataModel.msl;", String.Empty);
            connectionString = connectionString.Replace("MultipleActiveResultSets=True", String.Empty);
            connectionString = connectionString.Replace("provider=System.Data.SqlClient;provider connection string=", String.Empty);
            connectionString = connectionString.Replace("&quot;\" providerName=\"System.Data.EntityClient", String.Empty);
            connectionString = connectionString.Replace("\"", String.Empty);
            connectionString = connectionString.Replace(";App=EntityFramework", String.Empty);

            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            OpenTable(sb, Resources.Global.System);
            AppendLine(sb, Resources.Global.Version, Global.Context.Verison.ToString());
            AppendLine(sb, Resources.Global.DebugMode, Global.Context.IsDebuggingEnabled.ToString());
            CloseTable(sb);

            OpenTable(sb, Resources.Global.Database);
            AppendLine(sb, Resources.Global.DatabaseServer, sqlConnectionStringBuilder.DataSource);
            AppendLine(sb, Resources.Global.Login, sqlConnectionStringBuilder.UserID);
            AppendLine(sb, Resources.Global.DatabaseName, sqlConnectionStringBuilder.InitialCatalog);
            CloseTable(sb);

            OpenTable(sb, Resources.Global.Project);
            AppendUrlLine(sb, Resources.Global.WebApplicationAddress, Global.Context.WebsiteUrl);
            AppendLine(sb, Resources.Global.WebsiteStorageConnectionString, Global.Context.ApplicationStorageConnectionString);
            CloseTable(sb);

            OpenTable(sb, Resources.Global.FileUploadPageTitle);
            AppendLine(sb, Resources.Global.FileStorageConnectionString, Global.Context.StorageConnectionString);
            AppendUrlLine(sb, Resources.Global.FileStorageUrl, Global.Context.StorageUrl);
            CloseTable(sb);

            information.InnerHtml = sb.ToString();
        }

        private static void OpenTable(StringBuilder sb, string caption)
        {
            sb.AppendFormat(@"<table class=""table table-bordered table-hover table-condensed information"">
        <caption><h3>{0}</h3></caption>
        <colgroup><col style=""width:30%;""><col style=""width:70%;""></colgroup>
        <tbody>", caption);
        }

        private static void CloseTable(StringBuilder sb)
        {
            sb.AppendLine(@"</tbody></table>");
        }

        private static void AppendUrlLine(StringBuilder sb, String title, String value)
        {
            value = String.IsNullOrEmpty(value) ? "-" : value;
            var href = String.Format("<a target=\"new_window\" href=\"{0}\">{0}</a>", value);
            AppendLine(sb, title, href);
        }

        private static void AppendLine(StringBuilder sb, String title, String value)
        {
            sb.AppendFormat("<tr><th scope=\"row\">{0}</th><td>{1}</td></tr>", title, value);
        }
    }
}
