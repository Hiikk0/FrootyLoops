using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FrootyLoops.Services;
using HandyControl.Controls;
using HandyControl.Data;

namespace FrootyLoops.UserControls.SettingsContent
{
    /// <summary>
    /// Логика взаимодействия для Update.xaml
    /// </summary>
    public partial class Update : UserControl
    {
        /// <summary>
        /// Створення об'єкта системи оновлення
        /// </summary>
        UpdateManager update = new UpdateManager(Assembly.GetExecutingAssembly().GetName().Version.ToString());
        /// <summary>
        /// Точка входу
        /// </summary>
        public Update()
        {
            InitializeComponent();
            CurrVerTxtBlock.Text ="Current version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
        /// <summary>
        /// Завантажити оновлення
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LoadAndUpdate_Click(object sender, RoutedEventArgs e)
        {
            try { await update.CheckForUpdatesAsync("Hiikk0", "FrootyLoops", true); }
            catch (Exception ex)
            {
                Growl.Error(new GrowlInfo
                {
                    Message = "Error while update occured: " + ex.Message,
                    Type = InfoType.Error,
                    WaitTime = 10,
                    Token = "SettingsErrors",
                });
            }
        }
        /// <summary>
        /// Перевірити оновлення
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CheckForUpdate(object sender, RoutedEventArgs e)
        {
            try { 
                await update.CheckForUpdatesAsync("Hiikk0", "FrootyLoops", false);
                AvalVerTxtBlock.Text = "Avalible version: " + UpdateManager._lastestVersion.ToString();
                }
            catch (Exception ex) {
                Growl.Error(new GrowlInfo
                {
                    Message = "Error while connection occured: " + ex.Message,
                    Type = InfoType.Error,
                    WaitTime = 10,
                    Token = "SettingsErrors",
                });
            }
            
        }
    }
}
