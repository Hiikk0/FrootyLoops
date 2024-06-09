using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FrootyLoops.Data.Entities;

namespace FrootyLoops.UserControls
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : UserControl
    {
        public int BUTTONID;
        /// <summary>
        /// Змінна для передачі події в UserControl
        /// </summary>
        public event Action? ShowSettings;
        /// <summary>
        /// Точка входу
        /// </summary>
        public StartPage()
        {
            InitializeComponent();
            if (File.Exists("fdsafasd.txt")) MessageBox.Show("Piska");
        }
        /// <summary>
        /// Клік на кнопку для виклику налаштувань
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            BUTTONID = 0;
            ShowSettings?.Invoke();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            BUTTONID = 1;
            ShowSettings?.Invoke();
        }

        private void UserSettings_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            BUTTONID = 2;
            ShowSettings?.Invoke();
        }

    }
}
