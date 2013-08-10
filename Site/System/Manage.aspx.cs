using System;
using System.Windows.Forms;
using X.DynamicData.Core;

namespace Site
{
    public partial class Manage : XPage
    {
        protected void RestartSite(object sender, EventArgs e)
        {
            if (Global.Context.RestarWebApplication())
            {
                ShowMessage(String.Format("Перезапуск сайта завершен успешно в {0}.", DateTime.Now), "Перезапуск сайта", MessageBoxIcon.Information);
            }
            else
            {
                ShowMessage("Не удалось перезапустить сайт. Возможно нет доступа к директории.", "Перезапуск сайта.", MessageBoxIcon.Error);
            }
        }
    }
}