using FrootyLoops.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace FrootyLoops.UserControls.SettingsContent
{
    /// <summary>
    /// Логика взаимодействия для SystemSettings.xaml
    /// </summary>
    public partial class SystemSettings : UserControl
    {
        public SystemSettings()
        {
            InitializeComponent();
        }

        private void StartUp_Click(object sender, RoutedEventArgs e)
        {
            string pathToFile = Environment.CurrentDirectory + "/" + AppDomain.CurrentDomain.FriendlyName + ".exe";
            string pathToLocation = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "//FL.lnk";
            if (File.Exists(pathToLocation))
            {
                File.Delete(pathToLocation );
            }
            else
            {
                ShortcutCreator.Creator(pathToFile, pathToLocation);
            }
        }
    }
}
