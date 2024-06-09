using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FrootyLoops.Data.Entities;
using FrootyLoops.UserControls.SettingsContent;
using FrootyLoops.ViewModel;
using HandyControl;

namespace FrootyLoops.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        SettingsContentMainView viewModel;
        /// <summary>
        /// Змінна для передачі подій в UserControl
        /// </summary>
        public event Action? SwitchToLogin;
        /// <summary>
        /// Змінна для передачі події в UserControl
        /// </summary>
        public event Action? GoToStartPage;

        /// <summary>
        /// Точка входу
        /// </summary>
        public Settings()
        {
            InitializeComponent();
            viewModel = new SettingsContentMainView();
            viewModel.PropertyChanged += SettingsContentViewModel_PropertyChanged;
            DataContext = viewModel;
        }

        private void SettingsContentViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CurrentSettingsContent")
            {
                Content.Content = viewModel.CurrentSettingsContent;
            }
            if (e.PropertyName == "DeleteAccount")
            {
                ExitFromAccBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
        /// <summary>
        /// Клік на кнопку для виходу з аккаунту (перехід до логіну)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitFromAcc_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ExitFromAcc();
            SwitchToLogin?.Invoke();
        }
        /// <summary>
        /// Клік на кнопку для виходу з налаштувань (перехід до стартової сторінки)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitFromSet_Click(object sender, RoutedEventArgs e)
        {
            GoToStartPage?.Invoke();
        }
        /// <summary>
        /// Відтворення у частині вікна контенту з налаштуваннями
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Theme_Checked(object sender, RoutedEventArgs e)
        {
            //Content.Content = new Theme();
            viewModel.ThemeShow();
        }

        private void WhatsNew_Checked(object sender, RoutedEventArgs e)
        {
            //Content.Content = new WhatsNew();
            viewModel.WhatsNewShow();
        }

        private void FAQ_Checked(object sender, RoutedEventArgs e)
        {
            //Content.Content = new FAQ();
            viewModel.FAQShow();
        }

        private void SysSetBtn_Checked(object sender, RoutedEventArgs e)
        {
            //Content.Content = new SystemSettings();
            viewModel.SysSetShow();
        }

        private void WorkSetBtn_Checked(object sender, RoutedEventArgs e)
        {
            //Content.Content = new Workzone();
            viewModel.WorkzoneShow();
        }

        private void LangSetBtn_Checked(object sender, RoutedEventArgs e)
        {
            //Content.Content = new Language();
            viewModel.LanguageShow();
        }

        private void UserSetBtn_Checked(object sender, RoutedEventArgs e)
        {
            //Content.Content = new UserSettings();
            viewModel.UserSetShow();
        }

        private void Update_Checked(object sender, RoutedEventArgs e)
        {
            viewModel.UpdateShow();

        }
    }
}
