using FrootyLoops.Data.Entities;
using FrootyLoops.Services;
using FrootyLoops.UserControls;
using FrootyLoops.UserControls.SettingsContent;
using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Tools.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FrootyLoops.ViewModel
{
    public class SettingsContentMainView : INotifyPropertyChanged
    {
        public static bool _deleteAccount = false;
        /// <summary>
        /// Тимчасова змінна для поточного UserControl.
        /// </summary>
        private object? _currentSettingsViewModel;
        /// <summary>
        /// Повернення поточного UserControl та його встановлення
        /// </summary>
        public object CurrentSettingsContent
        {
            get
            {

                return _currentSettingsViewModel;
            }
            set
            {
                _currentSettingsViewModel = value;
                OnPropertyChanged("CurrentSettingsContent");
            }
        }
        public object DeleteAccount
        {
            get
            {

                return _deleteAccount;
            }
            set
            {
                _deleteAccount = (bool)value;
                OnPropertyChanged("DeleteAccount");
            }
        }

        private string _userName = CurrentUser.user.Name;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged("UserName");
            }
        }
        private string _userEmail = CurrentUser.user.Email;
        public string UserEmail
        {
            get { return _userEmail; }
            set
            {
                _userEmail = value;
                OnPropertyChanged("UserEmail");
            }
        }
        private string _userPassword = CurrentUser.user.Password;
        public string UserPassword
        {
            get { return _userPassword; }
            set
            {
                _userPassword = value;
                OnPropertyChanged("UserPassword");
            }
        }
        private string _userPasswordHint = CurrentUser.user.PasswordHint;
        public string UserPasswordHint
        {
            get { return _userPasswordHint; }
            set
            {
                _userPasswordHint = value;
                OnPropertyChanged("UserPasswordHint");
            }
        }
        public void ExitFromAcc()
        {
            try { File.Delete(App.STDPATH + "/Users/user.json"); } catch (FileNotFoundException) { }
            CurrentUser.Clear();
        }

        public void ThemeShow()
        {
            var content = new Theme();
            CurrentSettingsContent = content;
        }

        public void WhatsNewShow()
        {
            var content = new WhatsNew();
            CurrentSettingsContent = content;
        }

        public void FAQShow()
        {
            var content = new FAQ();
            CurrentSettingsContent = content;
        }

        public void SysSetShow()
        {
            var content = new SystemSettings();
            CurrentSettingsContent = content;
        }

        public void WorkzoneShow()
        {
            var content = new Workzone();
            CurrentSettingsContent = content;
        }
        public void LanguageShow()
        {
            var content = new Language();
            CurrentSettingsContent = content;
        }
        public void UpdateShow()
        {
            var content = new Update();
            CurrentSettingsContent = content;
        }
        public void UserSetShow()
        {
            var content = new UserSettings();
            CurrentSettingsContent = content;
            content.Username.Text = CurrentUser.user.Name;
            content.UserEmail.Text = CurrentUser.user.Email;
            content.UserPasswordHint.Text = CurrentUser.user.PasswordHint;
            content.Accept += () => SaveChanges(content);
            content.Decline += () => CancelChanges(content);
            content.UserPic.ImageSelected += UserPic_ImageSelected;
            content.UserPic.ImageUnselected += UserPic_ImageUnSelected;
            content.Delete += UserDeleteWarning;
        }

        private void UserDeleteWarning()
        {
            Growl.Ask("Are you sure you want to delete your account? This action cannot be undone.", isConfirmed =>
            {
                if (isConfirmed)
                {
                    Directory.Delete(App.STDPATH + "/Users/" + CurrentUser.user.Name, true);
                    Growl.Clear();
                    DeleteAccount = true;
                    return true;
                }
                else
                {
                    Growl.Clear();
                    return false;
                }
            }, "SettingsErrors");
        }

        private void CancelChanges(UserSettings content)
        {
            content.Username.Text = UserName;
            content.UserEmail.Text = UserEmail;
            content.UserPassword.Text = "Password";
            content.UserPasswordHint.Text= UserPasswordHint;
            content.NewPassword.Text = "Password";
            UserPic_ImageUnSelected(new object(), new RoutedEventArgs());
            Growl.Success(new GrowlInfo
            {
                Message = "Changes canceled!",
                Type = InfoType.Info,
                WaitTime = 10,
                Token = "SettingsErrors",
            });
        }

        private bool success = true;
        private bool CheckInput(UserSettings content, int value)
        {
            List<string> Errors;
            switch (value)
            {
                case 0: Errors = InputChecker.InputRegCheck(content.Username.Text, CurrentUser.user.Password, CurrentUser.user.Email);
                    break;
                case 1: Errors = InputChecker.InputRegCheck(CurrentUser.user.Password, content.NewPassword.Text, CurrentUser.user.Email);
                    break;
                case 2: Errors = InputChecker.InputRegCheck(CurrentUser.user.Password, CurrentUser.user.Password, content.UserEmail.Text);
                    break;
                default: Errors = InputChecker.InputRegCheck(content.Username.Text, content.NewPassword.Text, content.UserEmail.Text);
                    break;
            }
            if (Errors.Count > 0)
            {
                Growl.Clear();
                foreach (string err in Errors)
                {
                    if (err.Contains("Password Hint: "))
                    {
                        Growl.Info(new GrowlInfo
                        {
                            Message = err,
                            Type = InfoType.Info,
                            WaitTime = 10,
                            Token = "SettingsErrors",
                        });
                    }
                    else
                    {
                        Growl.Error(new GrowlInfo
                        {
                            Message = err,
                            Type = InfoType.Error,
                            WaitTime = 10,
                            Token = "SettingsErrors",
                        });
                    }
                }
                success = false;
                return false;
            }
            else { success = true; return true; }
        }
        public void SaveChanges(UserSettings content)
        {
            if (content.Username.Text != CurrentUser.user.Name && CheckInput(content,0) == true)
            {
                UserName = content.Username.Text;
                try
                {
                    Directory.Move(App.STDPATH + "/Users/" + CurrentUser.user.Name, App.STDPATH + "/Users/" + UserName);
                    JsonWorker.UpdateJson("Name", UserName, App.STDPATH + "/Users/" + UserName + "/UserInfo.json");
                    CurrentUser.Clear();
                    CurrentUser.LoadUser(App.STDPATH + "/Users/" + UserName + "/UserInfo.json");
                }
                catch (Exception) { success = false; }
            }
            else if (content.Username.Text != CurrentUser.user.Name && CheckInput(content, 0) == false)
            {
                success = false;
            }
            if (content.NewPassword.IsEnabled == true && CheckInput(content,1)) 
            {
                UserPassword = Encryptor.Encrypt(content.NewPassword.Text);
                try
                {
                    JsonWorker.UpdateJson("Password", UserPassword, App.STDPATH + "/Users/" + CurrentUser.user.Name + "/UserInfo.json");
                }
                catch (Exception) { success = false; }
            }
            else if (content.NewPassword.IsEnabled == true && CheckInput(content, 1) == false)
            {
                success = false;
            }
            if (content.UserEmail.Text != CurrentUser.user.Email && CheckInput(content,2)) 
            { 
                UserEmail = content.UserEmail.Text;
                try 
                { 
                    JsonWorker.UpdateJson("Email", UserEmail, App.STDPATH + "/Users/" + CurrentUser.user.Name + "/UserInfo.json"); 
                }
                catch (Exception) { success = false; }
            }
            else if (content.UserEmail.Text != CurrentUser.user.Email && CheckInput(content, 2) == false)
            {
                success = false;
            }
            if (content.UserPasswordHint.Text != CurrentUser.user.PasswordHint)
            {
                UserPasswordHint = content.UserPasswordHint.Text;
                try 
                { 
                    JsonWorker.UpdateJson("PasswordHint", UserPasswordHint, App.STDPATH + "/Users/" + CurrentUser.user.Name + "/UserInfo.json"); 
                }
                catch (Exception) { success = false; }
            }
            CurrentUser.Clear();
            CurrentUser.LoadUser(App.STDPATH + "/Users/" + UserName + "/UserInfo.json");
            Autologger.Create(App.STDPATH + "/Users/" + UserName + "/UserInfo.json");

            if (success)
            {
                Growl.Success(new GrowlInfo
                {
                    Message = "Changes applied!",
                    Type = InfoType.Info,
                    WaitTime = 10,
                    Token = "SettingsErrors",
                });
            }
        }

        private void UserPic_ImageSelected(object sender, RoutedEventArgs e)
        {
            UserPic_ImageUnSelected(sender,e);
            ImageSelector current = (ImageSelector)sender;
            string Path = current.Uri.LocalPath;
            try
            {
                File.Copy(Path, App.STDPATH + "/Users/" + UserName +"/"+ System.IO.Path.GetFileName(Path));
            }
            catch (Exception err)
            {
                Growl.Error(new GrowlInfo
                {
                    Message = "Error during coping image: " + err.Message,
                    Type = InfoType.Error,
                    WaitTime = 10,
                    Token = "SettingsErrors",
                });
            };
        }
        private void UserPic_ImageUnSelected(object sender, RoutedEventArgs e)
        {
            foreach (var file in Directory.GetFiles(App.STDPATH + "/Users/" + UserName + "/", "*" + ".jpg").Concat
               (Directory.GetFiles(App.STDPATH + "/Users/" + UserName + "/", "*" + ".png")))
            {
                File.Delete(file);
            }
        }

        /// <summary>
        /// Якщо якесь значення змінилось, вікно буде сповіщено про це.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
