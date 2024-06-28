using FrootyLoops.Data.Entities;
using FrootyLoops.Services;
using FrootyLoops.UserControls.WorkplaceContent;
using FrootyLoops.ViewModel;
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
using Microsoft.Win32;

namespace FrootyLoops.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Workplace.xaml
    /// </summary>
    public partial class Workplace : UserControl
    {
        public static WorkplaceViewModel viewModel { get; set; }
        public static Workplace Current { get; set; }
        public string FileToLoad { get; set; }
        /// <summary>
        /// Точка входу
        /// </summary>
        public Workplace()
        {
            Current = this;
            InitializeComponent();
            viewModel = new WorkplaceViewModel();
            viewModel.PropertyChanged += SettingsContentViewModel_PropertyChanged;
            DataContext = viewModel;
            viewModel.TrackZone();
            viewModel.StorageZone();
            viewModel.UserResoursesZone();
            FileToLoad = MainViewModel.fileToSave;
            if (!string.IsNullOrEmpty(FileToLoad))
            {
                LoadFromFile load = new LoadFromFile(FileToLoad);
            }
            //viewModel.MIDIListZone();
        }
        private void SettingsContentViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CurrentTrackZoneContent")
            {
                TrackZoneContent.Content = viewModel.CurrentTrackZoneContent;
            }
            if (e.PropertyName == "CurrentStorageContent")
            {
                StorageContent.Content = viewModel.CurrentStorageContent;
            }
            if (e.PropertyName == "CurrentMIDIListContent")
            {
                MIDIListContent.Content = viewModel.CurrentMIDIListContent;
            }
            if (e.PropertyName == "CurrentUserResoursesContent")
            {
                UserResoursesContent.Content = viewModel.CurrentUserResoursesContent;
            }
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            TrackZone trackZone = (TrackZone)TrackZoneContent.Content;
            Grid dynamicGrid = (Grid)trackZone.contentScrollViewer.Content;
            List<Canvas> innerGrid = new List<Canvas>();
            foreach (var inner in dynamicGrid.Children)
                        {
                            if (inner is Canvas)
                            {
                                innerGrid.Add((Canvas)inner);
                            }
                        }
            List <MusicBlock> musicBlocks = new List <MusicBlock>();
            foreach (var inner in innerGrid)
            {
                foreach (var block in inner.Children)
                {
                    if (block is MusicBlock)
                    {
                        musicBlocks.Add((MusicBlock)block);
                    }
                }
            }

            Engine engine = new Engine();
            engine.LoadFilesToEngine(musicBlocks);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "FL files|*.flsp";
            if (saveFileDialog.ShowDialog() == true)
            {
                string FileToSave = saveFileDialog.FileName;
                
                SetMusicBlockData.WriteObject(FileToSave);
            }
        }
    }
}
