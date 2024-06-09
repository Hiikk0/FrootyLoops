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
using FrootyLoops.Services;
using FrootyLoops.Data.Entities;
using HandyControl.Controls;
using HandyControl.Data;

namespace FrootyLoops.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : UserControl
    {
        /// <summary>
        /// Точка входу
        /// </summary>
        public Registration()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Змінна для передачі події в UserControl
        /// </summary>
        public event Action? SwitchToLogin;
        /// <summary>
        /// Змінна для передачі події в UserControl
        /// </summary>
        public event Action? GoToStartPage;
        /// <summary>
        /// Клік на кнопку для виклику логіну
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            SwitchToLogin?.Invoke();
        }
        /// <summary>
        /// Клік на кнопку для завершення реєстрації (переходу до стартової сторінки)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinRegister(object sender, RoutedEventArgs e)
        {
            if(CheckInput() == false) { }
            else { CreateJson(); }
        }
        /// <summary>
        /// Надсилає на перевірку введені дані та відображає отриману відповідь. 
        /// </summary>
        /// <returns>Є помилки чи ні</returns>
        private bool CheckInput()
        {
            List<string> Errors = InputChecker.InputRegCheck(Username.Text, Password.Text, EMail.Text);

            if (Errors.Count > 0)
            {
                Growl.Clear();
                foreach (string err in Errors)
                {
                    Growl.Error(new GrowlInfo
                    {
                        Message = err,
                        Type = InfoType.Error,
                        WaitTime = 1,
                        Token = "RegistrationErrors",
                    });
                }
                return false;
            }
            else { return true; }
        }
        /// <summary>
        /// Створює нового користувача
        /// </summary>
        private void CreateJson()
        {
            string path = App.STDPATH + "/Users/" + Username.Text;
            User user = new User()
            {
                Name = Username.Text,
                Password = Encryptor.Encrypt(Password.Text),
                Email = EMail.Text,
                PasswordHint = Hint.Text,
                RegDate = DateTime.Now,
                LastLogDataTime = DateTime.Now,
            };

            try
            {
                Directory.CreateDirectory(path);
                JsonWorker.CreateJson(user, path + "/UserInfo.json");
                CurrentUser.user = user;
                GoToStartPage?.Invoke();
            }
            catch (DirectoryNotFoundException ex)
            {
                Growl.Error(new GrowlInfo
                {
                    Message = "Critical errors occurred when creating the profile: "
                    + ex.Message + " Please check the permissions for the app.",
                    Type = InfoType.Error,
                    WaitTime = 1,
                    Token = "RegistrationErrors",
                });
            }
            catch (Exception ex)
            {
                Growl.Error(new GrowlInfo
                {
                    Message = "Critical errors occurred when creating the profile: "
                    + ex.Message + " Please report this bug to the developer.",
                    Type = InfoType.Error,
                    WaitTime = 1,
                    Token = "RegistrationErrors",
                });
            }
        }
    }
}
