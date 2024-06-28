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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FrootyLoops.ViewModel;

namespace FrootyLoops.UserControls.WorkplaceContent
{
    /// <summary>
    /// Логика взаимодействия для TrackZone.xaml
    /// </summary>
    public partial class TrackZone : UserControl
    {
        WorkplaceViewModel viewModel;
        public TrackZone()
        {
            InitializeComponent();
            viewModel = new WorkplaceViewModel();
            viewModel.PropertyChanged += WorkplaceContentViewModel_PropertyChanged;
            DataContext = viewModel;
            //viewModel.TimeRulerZone();
        }
        private void WorkplaceContentViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CurrentTimeRulerContent")
            {
                Content.Content = viewModel.CurrentTimeRulerContent;
            }
        }
        private void OnScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (sender == timeRulerScrollViewer)
            {
                contentScrollViewer.ScrollToHorizontalOffset(timeRulerScrollViewer.HorizontalOffset);
            }
            else if (sender == contentScrollViewer)
            {
                timeRulerScrollViewer.ScrollToHorizontalOffset(contentScrollViewer.HorizontalOffset);
            }
        }
    }
}
