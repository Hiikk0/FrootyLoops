using FrootyLoops.Data.Entities;
using FrootyLoops.Services;
using HandyControl.Controls;
using Melanchall.DryWetMidi.MusicTheory;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace FrootyLoops.UserControls.WorkplaceContent
{
    public partial class MusicBlock : UserControl
    {
        public const double blockWidth = 156;
        public string Guid { get; set; } = System.Guid.NewGuid().ToString();
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? FileName { get; set; }
        public string? PicPath { get; set; }
        public string? Type { get; set; }
        public List<MusicBlock>? BlockArray { get; set; }
        public (NoteName, int)? Note {  get; set; }
        public string NameOfBlock { get; set; } = "Name";
        public string ContainerType { get; set; }
        public double? Left { get; set; }
        public double? Right { get; set; }
        public double? Top { get; set; }
        public double? Bottom { get; set; }
        public int Row { get; set; }
        public int? Column { get; set; }
        public double ScaleFactor { get; set; } = TimeRuler._scaleFactor;
        //public double Width { get; set; } = blockWidth;
        public MusicBlockDrag musicBlockDrag;

        // Объявление делегата для события мыши
        public delegate void RightMouseActionEventHandler(object sender, MouseButtonEventArgs e);
        public delegate void LeftMouseActionEventHandler(object sender, MouseButtonEventArgs e);
        public delegate void MouseActionEventHandler(object sender, MouseEventArgs e);
        public delegate void UpdateInfoEventHandler();

        // Объявление события мыши
        public event RightMouseActionEventHandler? RightMouseActionEvent;
        public event LeftMouseActionEventHandler? LeftMouseActionEvent;
        public event MouseActionEventHandler? MouseActionEvent;
        public event UpdateInfoEventHandler? UpdateInfo;
        public static MusicBlockData MusicBlockData;
        public MusicBlock()
        {
            InitializeComponent();
            musicBlockDrag = new MusicBlockDrag(this);
            BlockName.Text = NameOfBlock;
            MusicBlockNameChanger.Text = NameOfBlock;
        }
        private void FileMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Music files (*.mp3, *.wav, *.aac, *.wma)|*.mp3; *.wav; *.aac; *.wma|MIDI-file (*.midi)|*.midi;*.mid";
            if (openFileDialog.ShowDialog() == true)
            {
                FileName = openFileDialog.FileName;
                // Здесь вы можете использовать выбранный файл
            }
            UpdateInfo.Invoke();
        }
        private void ContextMenuButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ContextMenuButton button = sender as ContextMenuButton;
            if (button != null && button.ContextMenu != null)
            {
                button.ContextMenu.IsOpen = true;
            }
        }

        private void RightButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RightMouseActionEvent?.Invoke(sender, e);
        }

        private void LeftButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LeftMouseActionEvent?.Invoke(sender, e);
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            MouseActionEvent?.Invoke(sender, e);
        }

        private void PicMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpeg, *.jpg, *.png, *.bmp, *.gif)|*.jpeg; *.jpg; *.png; *.bmp; *.gif";
            if (openFileDialog.ShowDialog() == true)
            {
                PicPath = openFileDialog.FileName;
                // Здесь вы можете использовать выбранный файл
            }
            UpdateInfo.Invoke();
        }

        private void TrackType_Checked(object sender, RoutedEventArgs e)
        {
            this.Type = "Track";
            if (this.IsLoaded)
            {
                UpdateInfo.Invoke();
            }
        }

        private void TrackArrayType_Checked(object sender, RoutedEventArgs e)
        {
            this.Type = "TrackArray";
            if (this.IsLoaded)
            {
                UpdateInfo.Invoke();
            }
        }

        private void MIDITrackType_Checked(object sender, RoutedEventArgs e)
        {
            this.Type = "MIDI";
            if (this.IsLoaded)
            {
                UpdateInfo.Invoke();
            }
        }

        public void MusicBlockNameChanger_TextChanged(object sender, TextChangedEventArgs e)
        {
            NameOfBlock = MusicBlockNameChanger.Text;
            BlockName.Text = NameOfBlock;
            if (this.IsLoaded) { UpdateInfo.Invoke(); }
        }
    }
}
