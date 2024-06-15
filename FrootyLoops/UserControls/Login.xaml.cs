using FrootyLoops.Data.Entities;
using FrootyLoops.Services;
using FrootyLoops.ViewModel;
using HandyControl.Controls;
using HandyControl.Data;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FrootyLoops.UserControls
{

    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        /// <summary>
        /// Точка входу
        /// </summary>
        public Login()
        {
            InitializeComponent();
            this.Loaded += async (s, e) => await MyUserControl_LoadedAsync(s, e);
        }
        /// <summary>
        /// Змінна для передачі події в UserControl
        /// </summary>
        public event Action? SwitchToRegister;
        /// <summary>
        /// Змінна для передачі події в UserControl
        /// </summary>
        public event Action? GoToStartPage;
        /// <summary>
        /// Чи робити автовход
        /// </summary>
        private bool remem = false;
        /// <summary>
        /// Активна іконка
        /// </summary>
        private readonly BitmapImage active = new BitmapImage(new Uri("/Data/Design/Icons/activeRememberLoginButtonIc.png", UriKind.Relative));
        /// <summary>
        /// Неактивна іконка
        /// </summary>
        private readonly BitmapImage unactive = new BitmapImage(new Uri("/Data/Design/Icons/unactiveRememberLoginButtonIc.png", UriKind.Relative));
        /// <summary>
        /// Зміна іконки в Remember me
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RememberMe_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button == null) { return; }

            ControlTemplate ct = button.Template;
            Border border = (Border)ct.FindName("border", button);
            if (border == null) { return; }

            if (border.Child is not StackPanel stackPanel) { return; }

            Image image = stackPanel.Children.OfType<Image>().FirstOrDefault();

            if (image == null) { return; }
            if (/*(string)RememberMe.Tag == "Unactive"*/ remem == false)
            {
                image.Source = active;
                //RememberMe.Tag = "Active";
                remem = true;
            }
            else
            {
                image.Source = unactive;
                //RememberMe.Tag = "Unactive";
                remem = false;
            }
        }
        /// <summary>
        /// Клік на кнопку для виклику реєстрації
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SwitchToRegister?.Invoke();
        }
        /// <summary>
        /// Клік на кнопку для завершення входу (переходу до стартової сторінки)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput() == false) { }
            else
            {
                UpdateUser();
            }
        }
        /// <summary>
        /// Надсилає на перевірку введені дані та відображає отриману відповідь.
        /// </summary>
        /// <returns>Є помилки чи ні</returns>
        private bool CheckInput()
        {
            List<string> Errors = InputChecker.InputCheck(Username.Text, Password.Text);

            if (Errors.Count > 0)
            {
                Growl.Clear();
                foreach (string err in Errors)
                {
                    if(err.Contains("Password Hint: "))
                    {
                        Growl.Info(new GrowlInfo
                        {
                            Message = err,
                            Type = InfoType.Info,
                            WaitTime = 10,
                            Token = "LoginErrors",
                        });
                    }
                    else
                    {
                        Growl.Error(new GrowlInfo
                        {
                            Message = err,
                            Type = InfoType.Error,
                            WaitTime = 10,
                            Token = "LoginErrors",
                        });
                    }
                }
                return false;
            }
            else { return true; }
        }
        /// <summary>
        /// Оновлює дані про дату останнього входу користувача.
        /// </summary>
        private void UpdateUser()
        {
            string path = App.STDPATH + "/Users/" + Username.Text + "/UserInfo.json";
            CurrentUser.LoadUser(path);
            CurrentUser.user.LastLogDataTime = DateTime.Now;
            try
            {
                JsonWorker.UpdateJson("LastLogDataTimeString", Convert.ToString(CurrentUser.user.LastLogDataTime), path);
                if (remem)
                {
                    Autologger.Create(path);
                }
                GoToStartPage?.Invoke();
            }
            catch (DirectoryNotFoundException ex)
            {
                Growl.Error(new GrowlInfo
                {
                    Message = ex.Message +
                    " Please check the availability of this path.",
                    Type = InfoType.Error,
                    WaitTime = 1,
                    Token = "LoginErrors",
                });
            }
            catch (FileNotFoundException ex)
            {
                Growl.Error(new GrowlInfo
                {
                    Message = ex.Message +
                    " Please check the availability of this file. If it doesn't exist, recreate this file or all profile.",
                    Type = InfoType.Error,
                    WaitTime = 1,
                    Token = "LoginErrors",
                });
            }
            catch (IOException ex)
            {
                Growl.Error(new GrowlInfo
                {
                    Message = ex.Message +
                    " Please close the programs that are using this file and try again.",
                    Type = InfoType.Error,
                    WaitTime = 1,
                    Token = "LoginErrors",
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
                    Token = "LoginErrors",
                });
            }
        }
        /// <summary>
        /// КОСТИЛЬ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private async Task MyUserControl_LoadedAsync(object sender, RoutedEventArgs e)
        {
            await Task.Delay(500);

            if (File.Exists(App.STDPATH + "/Users/user.json"))
            {
                if (Autologger.Compare(App.STDPATH + "/Users"))
                {
                    Username.Text = Autologger.NAME;
                    UpdateUser();
                }
                else
                {
                    Growl.Error(new GrowlInfo
                    {
                        Message = "Auto login failed. The file is corrupted. Try logging in manually.",
                        Type = InfoType.Error,
                        WaitTime = 10,
                        Token = "LoginErrors",
                    });
                    File.Delete(App.STDPATH + "/Users/user.json");
                }
            }
        }
    }
}
