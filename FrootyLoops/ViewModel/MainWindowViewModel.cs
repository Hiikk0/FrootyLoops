using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using FrootyLoops;
using FrootyLoops.Data.Entities;
using FrootyLoops.UserControls;

namespace FrootyLoops.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Тимчасова змінна для поточного UserControl.
        /// </summary>
        private object _currentViewModel;
        /// <summary>
        /// Тимчасова змінна для поточної мінімальної ширини.
        /// </summary>
        private double _currentMinWidth;
        /// <summary>
        /// Тимчасова змінна для поточної мінімальної висоти.
        /// </summary>
        private double _currentMinHeight;
        /// <summary>
        /// Тимчасова змінна для поточного способу визначення розміру вікна.
        /// </summary>
        public static SizeToContent _currentSizeToContentState = SizeToContent.WidthAndHeight;

        BitmapImage stdImage = new BitmapImage(new Uri(App.STDPATH + "/Data/Design/Pics/Pic1.jpg", UriKind.Relative));
        /// <summary>
        /// Точка входу. Виклик першого UserControl
        /// </summary>
        public MainViewModel()
        {
            ShowLogin();
        }
        /// <summary>
        /// Повернення поточного UserControl та його встановлення
        /// </summary>
        public object CurrentUserControl
        {
            get {
                
                return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged("CurrentUserControl");
            }
        }
        /// <summary>
        /// Повернення поточноої ширини та її встановлення
        /// </summary>
        public double CurrentMinWidth
        {
            get { return _currentMinWidth; }
            set
            {
                _currentMinWidth = value;
                OnPropertyChanged("CurrentMinWidth");
            }
        }
        /// <summary>
        /// Повернення поточної мінімальної висоти та її встановлення
        /// </summary>
        public double CurrentMinHeight
        {
            get { return _currentMinHeight; }
            set
            {
                _currentMinHeight = value;
                OnPropertyChanged("CurrentMinHeight");
            }
        }
        /// <summary>
        /// Повернення поточного стану SizeToContent (чи треба вікну адаптуватися до контенту) та його встановлення
        /// </summary>
        public SizeToContent CurrentSizeToContentState
        {
            get { return _currentSizeToContentState; }
            set
            {
                _currentSizeToContentState = value;
                OnPropertyChanged("CurrentSizeToContentState");
            }
        }
        /// <summary>
        /// Встановлення Login поточним контентом вікна та підписка на події
        /// Шляхи: до реєстрації та до стартової сторінки
        /// </summary>
        public void ShowLogin()
        {
            var Control = new UserControls.Login();
            CurrentSizeToContentState = SizeToContent.WidthAndHeight;
            CurrentUserControl = Control;
            CurrentMinWidth = Control.MinWidth;
            CurrentMinHeight = Control.MinHeight;
            Control.SwitchToRegister += ShowRegister;
            Control.GoToStartPage += ShowStartPage;
        }
        /// <summary>
        /// Встановлення Register поточним контентом вікна та підписка на події
        /// Шляхи: до логіна та до стартової сторінки
        /// </summary>
        public void ShowRegister()
        {
            var Control = new UserControls.Registration();
            CurrentSizeToContentState = SizeToContent.WidthAndHeight;
            CurrentUserControl = Control;
            CurrentMinWidth = Control.MinWidth;
            CurrentMinHeight = Control.MinHeight;
            Control.SwitchToLogin += ShowLogin;
            Control.GoToStartPage += ShowStartPage;
        }
        /// <summary>
        /// Встановлення StartPage поточним контентом вікна та підписка на події
        /// Шляхи: до налаштувань
        /// </summary>
        public void ShowStartPage()
        {
            var Control = new UserControls.StartPage();
            BitmapImage stdImage = new BitmapImage(new Uri(App.STDPATH + "/Data/Design/Pics/Pic1.jpg", UriKind.Relative));
            CurrentSizeToContentState = SizeToContent.Manual;
            CurrentUserControl = Control;
            CurrentMinWidth = Control.MinWidth;
            CurrentMinHeight = Control.MinHeight;
            Control.Username.Text = CurrentUser.user.Name;
            if (Directory.GetFiles(App.STDPATH + "/Users/" + CurrentUser.user.Name + "/", "*" + ".jpg").Concat
               (Directory.GetFiles(App.STDPATH + "/Users/" + CurrentUser.user.Name + "/", "*" + ".png")).Any())
            {
                string path = Directory.GetFiles(App.STDPATH + "/Users/" + CurrentUser.user.Name + "/", "*" + ".jpg").Concat
                (Directory.GetFiles(App.STDPATH + "/Users/" + CurrentUser.user.Name + "/", "*" + ".png")).First();
                path = path.Replace("\\", "/");
                stdImage = new BitmapImage(new Uri(path, UriKind.Relative));
            }
            Control.UserPic.ImageSource = stdImage;
            Control.PicСontainer.Fill = Control.UserPic;
            Control.ShowSettings += () => ShowSettings(Control.BUTTONID);
        }
        /// <summary>
        /// Встановлення Settings поточним контентом вікна та підписка на події
        /// Шляхи: до логіна та до стартової сторінки
        /// </summary>
        public void ShowSettings(int? ID)
        {
            var Control = new UserControls.Settings();
            CurrentSizeToContentState = SizeToContent.Manual;
            CurrentUserControl = Control;
            CurrentMinWidth = Control.MinWidth;
            CurrentMinHeight = Control.MinHeight;
            Control.SwitchToLogin += ShowLogin;
            Control.GoToStartPage += ShowStartPage;
            RoutedEventArgs click = new(RadioButton.CheckedEvent);
            switch (ID)
            {
                case 0:
                    Control.SysSetBtn.IsChecked = true;
                    Control.SysSetBtn.RaiseEvent(click);
                    return;
                case 1:
                    Control.HelpBtn.IsChecked = true;
                    Control.HelpBtn.RaiseEvent(click);
                    return;
                case 2:
                    Control.UserSetBtn.IsChecked = true;
                    Control.UserSetBtn.RaiseEvent(click);
                    return;
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
