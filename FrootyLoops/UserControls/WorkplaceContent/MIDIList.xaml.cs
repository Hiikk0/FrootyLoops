using FrootyLoops.ViewModel;
using Melanchall.DryWetMidi.MusicTheory;
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

namespace FrootyLoops.UserControls.WorkplaceContent
{
    /// <summary>
    /// Логика взаимодействия для MIDI_Track.xaml
    /// </summary>
    public partial class MIDIList : UserControl
    {
        WorkplaceViewModel viewModel;
        public MIDIList()
        {
            InitializeComponent();
            viewModel = new WorkplaceViewModel();
            viewModel.PropertyChanged += WorkplaceContentViewModel_PropertyChanged;
            DataContext = viewModel;
            CreateNoteLines();
            //viewModel.TimeRulerZone();
        }
        private void WorkplaceContentViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            //if (e.PropertyName == "CurrentTimeRulerContent")
            //{
            //    Content.Content = viewModel.CurrentTimeRulerContent;
            //}
        }
        private void CreateNoteLines()
        {
            for (int i = 0; i < 127; i++)
            {
                RowDefinition tmpRowDef = new RowDefinition();
                RowDefinition tmpRowDef2 = new RowDefinition();
                ColumnDefinition tmpColumnDef = new ColumnDefinition();
                GridLength gridWidth = new GridLength(160);
                GridLength gridHeight = new GridLength(50);
                tmpRowDef.Height = gridHeight;
                tmpRowDef2.Height = gridHeight;
                tmpColumnDef.Width = gridWidth;
                DynamicGrid.RowDefinitions.Add(tmpRowDef);
                DynamicGrid.ColumnDefinitions.Add(tmpColumnDef);

                NoteGrid.RowDefinitions.Add(tmpRowDef2);

                // Создайте Label для отображения названия ноты
                TextBlock noteLabel = new TextBlock();
                noteLabel.Text = GetNoteName(i);
                Grid.SetRow(noteLabel, i);
                Border tmpBorder = new Border();
                Grid.SetRow(tmpBorder, i);
                noteLabel.VerticalAlignment = VerticalAlignment.Center;
                noteLabel.HorizontalAlignment = HorizontalAlignment.Right;
                
                // Задайте цвет фона для ряда (например, черный для полутонов)
                if (IsHalfTone(i))
                {
                    tmpBorder.Background = Brushes.Black;
                }
                else
                {
                    tmpBorder.Background = Brushes.White;
                }

                // Добавьте Label на ряд 
                NoteGrid.Children.Add(tmpBorder);
                NoteGrid.Children.Add(noteLabel);
            }
        }
        static string GetNoteName(int note)
        {
            string[] noteNames = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
            int octave = note / 12;
            int noteIndex = note % 12;

            return $"{noteNames[noteIndex]}{octave}";
        }

        static bool IsHalfTone(int note)
        {
            int noteIndex = note % 12;
            return noteIndex == 1 || noteIndex == 3 || noteIndex == 6 || noteIndex == 8 || noteIndex == 10;
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
                noteScrollViewer.ScrollToVerticalOffset(contentScrollViewer.VerticalOffset);
            }
            else if (sender == noteScrollViewer)
            {
                contentScrollViewer.ScrollToVerticalOffset(noteScrollViewer.VerticalOffset);
            }
        }
    }
}
