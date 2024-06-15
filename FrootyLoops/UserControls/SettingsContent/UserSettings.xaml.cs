﻿using FrootyLoops.Data.Entities;
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
        /// <summary>
        /// Зміни зберегти
        /// </summary>
        public event Action? Accept;
        /// <summary>
        /// Зміни скасувати
        /// </summary>
        public event Action? Decline;
        /// <summary>
        /// Аккаунт видалити
        /// </summary>
        public event Action? Delete;
        /// <summary>
        /// Точка входу
        /// </summary>
        public UserSettings()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Після натискання на кнопку Accept
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            Accept?.Invoke();
        }
        /// <summary>
        /// Перевірка, чи пароль правильний. Якщо так - пароль можна змінити.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Encryptor.Encrypt(UserPassword.Text) == CurrentUser.user.Password)
            {
                NewPassword.IsEnabled = true;
            }
        }
        /// <summary>
        /// Після натискання на кнопку Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Decline?.Invoke();
        }
        /// <summary>
        /// Після натискання на кнопку Delete account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelAccBtn_Click(object sender, RoutedEventArgs e)
        {
            Delete?.Invoke();
        }
    }
}
