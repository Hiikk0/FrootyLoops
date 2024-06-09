using FrootyLoops.Forms;
using HandyControl.Themes;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Theme.xaml
    /// </summary>
    public partial class Theme : UserControl
    {

        /// <summary>
        /// Точка входу
        /// </summary>
        public Theme()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Зміна теми
        /// </summary>
        /// <param name="newTheme"> Назва теми</param>
        public void ChangeTheme(Uri newTheme)
        {
            Application.Current.Resources.MergedDictionaries.Clear();

            ResourceDictionary newResourceDictionary = new ResourceDictionary { Source = newTheme };
            Application.Current.Resources.MergedDictionaries.Add(newResourceDictionary);
            Application.Current.Resources.MergedDictionaries.Add(HandyControl.Themes.Theme.ControlsResources);
            Application.Current.Resources.MergedDictionaries.Add(HandyControl.Themes.ThemeResources.Current);
            
            var window = MainWindow.GetWindow(this);
            window.InvalidateVisual();
            window.UpdateLayout();

        }
        /// <summary>
        /// Клік на кнопку для зміни теми
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Resources.Contains("LightThemeKey"))
            {
                Uri.TryCreate("./../../../Data/Themes/Theme.xaml", UriKind.Relative, out Uri result);
                ChangeTheme(result);
            }
            else if (Application.Current.Resources.Contains("DarkThemeKey"))
            {
                Uri.TryCreate("./../../../Data/Themes/LightTheme.xaml", UriKind.Relative, out Uri result);
                ChangeTheme(result);
            }
        }

        private void ExpandButtonClick(object sender, RoutedEventArgs e)
        {
            //this.Menu.Visibility = this.Menu.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;

        }
    }
}
