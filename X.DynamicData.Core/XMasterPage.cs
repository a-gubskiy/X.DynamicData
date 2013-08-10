using System.Web.UI;
using System.Windows.Forms;

namespace X.DynamicData.Core
{
    public abstract class XMasterPage : MasterPage
    {
        public abstract void ShowMessage(string text, string caption, MessageBoxIcon icon);
    }
}
