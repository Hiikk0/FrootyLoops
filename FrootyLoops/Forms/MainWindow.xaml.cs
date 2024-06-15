using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using FrootyLoops.ViewModel;
using HandyControl;

namespace FrootyLoops.Forms
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : HandyControl.Controls.Window
    {
        /// <summary>
        /// Поточна модель, до якої буде виконуватися прив'язка
        /// </summary>
        MainViewModel viewModel;
        /// <summary>
        /// Чи є вікно максимізованим
        /// </summary>
        private bool IsMaximized = false;
        /// <summary>
        /// Змінні для зберігання минулої ширини, висоти та координат
        /// </summary>
        private double PreviousWidth, PreviousHeight, PreviousTop, PreviousLeft;
        /// <summary>
        /// Поточний спосіб визначення розмірів вікна
        /// </summary>
        private SizeToContent sizeToContent;
        /// <summary>
        /// Максимальна іконка
        /// </summary>
        private readonly BitmapImage maxIcon = new BitmapImage(new Uri("/Data/Design/Icons/maximizeIcon.png", UriKind.Relative));
        /// <summary>
        /// Мінімальна іконка
        /// </summary>
        private readonly BitmapImage minIcon = new BitmapImage(new Uri("/Data/Design/Icons/restoreIcon.png", UriKind.Relative));
        /// <summary>
        /// Точка входу, ініціалізація MainWindowViewModel
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainViewModel();
            viewModel.PropertyChanged += MainViewModel_PropertyChanged;
            DataContext = viewModel;
        }
        /// <summary>
        /// Перевірка, які значення змінилися і застосування дій.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CurrentViewModel")
            {
                InvalidateVisual();
            }
            if (e.PropertyName == "CurrentWidth")
            {
                this.MinWidth = viewModel.CurrentMinWidth;
            }
            if (e.PropertyName == "CurrentHeight")
            {
                this.MinHeight = viewModel.CurrentMinHeight;
            }
            if (e.PropertyName == "CurrentSizeToContentState")
            {
                sizeToContent = viewModel.CurrentSizeToContentState;
                if (!this.IsMaximized) { this.SizeToContent = viewModel.CurrentSizeToContentState; }
                UpdateLayout();
            }
        }
        /// <summary>
        /// Згортання вікна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        /// <summary>
        /// Розгортання та відновлення вікна 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            var MaxIcon = this.Template.FindName("MaxIcon", this) as Image;
            if (IsMaximized)
            {
                this.SizeToContent = sizeToContent;
                this.Width = PreviousWidth;
                this.Height = PreviousHeight;
                this.Left = PreviousLeft;
                this.Top = PreviousTop;
                IsMaximized = false;

                MaxIcon.Source = maxIcon;
            }
            else
            {   
                PreviousWidth = this.Width;
                PreviousHeight = this.Height;
                PreviousLeft = this.Left;
                PreviousTop = this.Top;
                sizeToContent = this.SizeToContent;

                SizeToContent = SizeToContent.Manual;

                var workArea = System.Windows.SystemParameters.WorkArea;
                this.Left = workArea.Left;
                this.Top = workArea.Top;
                this.Width = workArea.Width;
                this.Height = workArea.Height;

                IsMaximized = true;

                MaxIcon.Source = minIcon;
            }
        }
        /// <summary>
        /// Закриття програми
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Реалізація перетаскування вікна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 2)
            {
                
                var pointToWindow = Mouse.GetPosition(this);
                var pointToScreen = this.PointToScreen(pointToWindow);

                this.Left = Math.Max(SystemParameters.VirtualScreenLeft, pointToScreen.X - pointToWindow.X);
                this.Top = Math.Max(SystemParameters.VirtualScreenTop, pointToScreen.Y - pointToWindow.Y);
                Maximize_Click(sender, e);
                DragMove();
            }
            else if (e.ClickCount == 1 && IsMaximized)
            {
                    Maximize_Click(sender, e);
                    var pointToWindow = Mouse.GetPosition(this);
                    var pointToScreen = this.PointToScreen(pointToWindow);

                    this.Left = Math.Max(SystemParameters.VirtualScreenLeft, pointToScreen.X - pointToWindow.X);
                    this.Top = Math.Max(SystemParameters.VirtualScreenTop, pointToScreen.Y - pointToWindow.Y);
                    DragMove();
            }
            else if (e.ClickCount == 1) { DragMove(); }
        }
    }
}
