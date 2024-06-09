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

namespace FrootyLoops.UserControls.SettingsContent
{
    /// <summary>
    /// Логика взаимодействия для Update.xaml
    /// </summary>
    public partial class Update : UserControl
    {
        UpdateManager update = new UpdateManager(Assembly.GetExecutingAssembly().GetName().Version.ToString());
        public Update()
        {
            InitializeComponent();
            CurrVerTxtBlock.Text = CurrVerTxtBlock.Text + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private async void LoadAndUpdate_Click(object sender, RoutedEventArgs e)
        {
            await update.CheckForUpdatesAsync("Hiikk0", "FrootyLoops", true);
        }

        private async void CheckForUpdate(object sender, RoutedEventArgs e)
        {
            await update.CheckForUpdatesAsync("Hiikk0", "FrootyLoops", false);
            AvalVerTxtBlock.Text = AvalVerTxtBlock.Text + UpdateManager._lastestVersion.ToString();
        }
    }
}
