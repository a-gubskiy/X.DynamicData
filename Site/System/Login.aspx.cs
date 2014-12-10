using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using WebMatrix.WebData;
using X.DynamicData.Core;

namespace Site
{
    public partial class Login : XPage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            login_title.InnerText = Resources.Global.LoginPageTitle;

            if (!String.IsNullOrEmpty(Request["logout"]))
            {
                WebSecurity.Logout();
                Response.Redirect("~");
            }
        }

        protected void signin_Click(object sender, EventArgs e)
        {
            var authenticated = WebSecurity.Login(t_login.Text, t_password.Text);

            if (authenticated)
            {
                FormsAuthentication.RedirectFromLoginPage(t_login.Text, false);
                Response.Redirect("~");
            }
            else
            {
                ShowMessage(Resources.Global.LoginError, Resources.Global.LoginPageTitle, MessageBoxIcon.Error);
            }
        }
    }
}