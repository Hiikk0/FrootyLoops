using FrootyLoops.Data.Entities;
using FrootyLoops.Services;
using FrootyLoops.ViewModel;
using HandyControl.Controls;
using HandyControl.Data;
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
    /// Логика взаимодействия для UserSettings.xaml
    /// </summary>
    public partial class UserSettings : UserControl
    {
        public event Action? Accept;
        public event Action? Decline;
        public event Action? Delete;
        public UserSettings()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            Accept?.Invoke();
        }
        private void UserPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Encryptor.Encrypt(UserPassword.Text) == CurrentUser.user.Password)
            {
                NewPassword.IsEnabled = true;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Decline?.Invoke();
        }

        private void DelAccBtn_Click(object sender, RoutedEventArgs e)
        {
            Delete?.Invoke();
        }
    }
}
