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
using Microsoft.Win32;

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
        public event Action? ShowWorkplace;
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

        private void NewFile_Click(object sender, RoutedEventArgs e)
        {
            ShowWorkplace?.Invoke();
        }
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Music files (*.mp3, *.wav)|*.mp3; *.wav";
            openFileDialog.ShowDialog();
            ShowWorkplace?.Invoke();
        }
    }
}
