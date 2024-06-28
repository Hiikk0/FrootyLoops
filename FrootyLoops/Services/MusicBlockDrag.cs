using FrootyLoops.UserControls.WorkplaceContent;
using FrootyLoops.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;
using Octokit;
using System.ComponentModel;
using System.Windows.Media.Media3D;
using FrootyLoops.Data.Entities;
using System.IO;
using System.Windows.Media.Imaging;
using Melanchall.DryWetMidi.MusicTheory;
//using HandyControl.Controls;

namespace FrootyLoops.Services
{
    public class MusicBlockDrag
    {
        //Хто бачить це, покинь усю надію....
        private bool isDragging;
        private Point mouseOffset;
        private Point mouseBlockOffset;
        private TranslateTransform dragTranslation;
        public Workplace workplace;
        public TimeRuler timeRuler;

        public MusicBlockDrag(MusicBlock musicBlock) 
        {
            workplace = Workplace.Current;
            timeRuler = new TimeRuler();
            musicBlock.MouseLeftButtonDown += (sender,e) => MusicBlock_MouseLeftButtonDown(sender,e,musicBlock);
            musicBlock.MouseLeftButtonUp += (sender, e) => MusicBlock_MouseLeftButtonUp(sender,e,musicBlock);
            musicBlock.MouseMove += MusicBlock_MouseMove;
            dragTranslation = new TranslateTransform();
            musicBlock.RenderTransform = dragTranslation;
        }

        private void MusicBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e, MusicBlock musicBlock)
        {
            isDragging = true;
            mouseOffset = e.GetPosition(null);
            mouseBlockOffset = e.GetPosition(musicBlock);
            musicBlock.CaptureMouse();

            // Запуск анимации
            var animation = new DoubleAnimation(0.7, TimeSpan.FromMilliseconds(200));
            musicBlock.BeginAnimation(UIElement.OpacityProperty, animation);
            if (musicBlock.Type == "TrackArray" && Workplace.viewModel.typeChk != 2)
            {
                Workplace.viewModel.TrackArrayZone();
                Workplace.viewModel.typeChk = 2;
            }
            if (musicBlock.Type == "MIDI" && Workplace.viewModel.typeChk != 1)
            {
                Workplace.viewModel.MIDIListZone();
                Workplace.viewModel.typeChk = 1;
            }
            if (musicBlock.Type == "Track" && Workplace.viewModel.typeChk != 3)
            {
                Workplace.viewModel.TrackViewZone();
                Workplace.viewModel.typeChk = 3;
            }
        }

        private void MusicBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e, MusicBlock musicBlock)
        {
            isDragging = false;
            musicBlock.ReleaseMouseCapture();

            // Вернуть блок на место
            dragTranslation.X = 0;
            dragTranslation.Y = 0;

            // Завершение анимации
            var animation = new DoubleAnimation(1.0, TimeSpan.FromMilliseconds(200));
            musicBlock.BeginAnimation(UIElement.OpacityProperty, animation);

            // Обработка данных
            // TODO: добавьте здесь вашу логику обработки данных

            FrameworkElement hitElement = GetElementUnderCursor(e);

            if (hitElement != null)
            {
                object windowObject = GetType(hitElement);
                switch (windowObject)
                {
                    case ContentPresenter contentPresenter: SetBlockToContentPresenter(contentPresenter,e); break;
                    case ScrollViewer contentScrollViewer: SetBlockToScrollViewer(contentScrollViewer,e); break;
                    default:
                        break;
                }
            }
        }

        private FrameworkElement GetElementUnderCursor(MouseButtonEventArgs e)
        {
            // Определение принимающего элемента под курсором
            HitTestResult hitTestResult = VisualTreeHelper.HitTest((Workplace)workplace, e.GetPosition(/*musicBlock*/null));
            FrameworkElement hitElement;
            try
            {
                hitElement = hitTestResult.VisualHit as FrameworkElement;
                return hitElement;
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        private object GetType(FrameworkElement hitElement)
        {
            Border ElementBorder;
            ContentPresenter contentPresenter;
            ScrollViewer contentScrollViewer;

            try
            {
                if (hitElement.GetType() == typeof(Border))
                {
                    ElementBorder = (Border)hitElement;
                    contentPresenter = (ContentPresenter)ElementBorder.Child;
                    return contentPresenter;
                }
                else if (hitElement.GetType() == typeof(ScrollViewer))
                {
                    contentScrollViewer = (ScrollViewer)hitElement;
                    return contentScrollViewer;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void SetBlockToContentPresenter(ContentPresenter contentPresenter, MouseButtonEventArgs e)
        {
            if (contentPresenter.Name == "StorageContent")
            {
                Storage storage1 = (Storage)contentPresenter.Content;
                if (storage1.FindName("ContentPanel") != null)
                {
                    Canvas storage = (Canvas)storage1.FindName("ContentPanel");
                    MusicBlock newBlock = new MusicBlock();
                    // TODO: скопируйте все необходимые данные из droppedData в newBlock

                    storage.Children.Add(newBlock);
                    Point currentPosition = e.GetPosition(storage);
                    Canvas.SetLeft(newBlock, currentPosition.X - mouseBlockOffset.X);
                    Canvas.SetTop(newBlock, currentPosition.Y - mouseBlockOffset.Y);
                }
            }
        }

        private string GetTypeOfCont(ScrollViewer contentScrollViewer)
        {
            if ((Grid)contentScrollViewer.FindName("MIDI") != null)
            {
                return "MIDI";
            }
            else if ((Grid)contentScrollViewer.FindName("TRACK") != null)
            {
                return "TRACK";
            }
            else if ((Grid)contentScrollViewer.FindName("TRACK_ARRAY") != null)
            {
                return "TRACK_ARRAY";
            }
            return "";
        }

        private void SetBlockToScrollViewer(ScrollViewer contentScrollViewer, MouseButtonEventArgs e)
        {
            if (contentScrollViewer.Name == "contentScrollViewer")
            {
                string type = GetTypeOfCont(contentScrollViewer);
                if (type == "MIDI")
                {
                    SetMIDINote(contentScrollViewer, e, type);
                    return;
                }
                TimeRuler timeRuler = FindTimeRuler(contentScrollViewer);
                // Создание нового Grid
                Grid outerGrid = (Grid)contentScrollViewer.Content;
                outerGrid.Width = 2000; // Установите ширину, которая вам нужна

                MusicBlock newBlock = new MusicBlock();
                newBlock.Width = MusicBlock.blockWidth;

                SetPossibleType(type,newBlock);
                // TODO: скопируйте все необходимые данные из droppedData в newBlock

                // Определение полоски, над которой находится блок
                Point currentPosition = e.GetPosition(outerGrid);
                int row = 0;
                if (outerGrid.RowDefinitions.Count > 0 && outerGrid.ActualHeight > 0)
                {
                    row = (int)Math.Floor(currentPosition.Y / (outerGrid.ActualHeight / outerGrid.RowDefinitions.Count));
                }

                GridLength gridLength = new GridLength(65);

                if (outerGrid.RowDefinitions.Count == row + 1)
                {
                    RowDefinition tmpRowDef = new RowDefinition();
                    tmpRowDef.Height = gridLength;
                    outerGrid.RowDefinitions.Add(tmpRowDef);
                }

                // Создание нового Canvas для каждого ряда, если он еще не существует
                Canvas innerCanvas = null;
                foreach (UIElement child in outerGrid.Children)
                {
                    if (child is Canvas && Grid.GetRow(child) == row)
                    {
                        innerCanvas = (Canvas)child;
                        break;
                    }
                }
                if (innerCanvas == null)
                {
                    innerCanvas = new Canvas();
                    innerCanvas.Height = outerGrid.ActualHeight / outerGrid.RowDefinitions.Count;
                    outerGrid.Children.Add(innerCanvas);
                    Grid.SetRow(innerCanvas, row);
                }

                (double newBlockLeft, double newBlockRight, bool spaceIsOccupied) = CheckSpace(currentPosition, newBlock, innerCanvas);

                if (spaceIsOccupied)
                {
                    return;
                }

                // Добавление блока в определенную ячейку
                Canvas.SetLeft(newBlock, newBlockLeft);
                Canvas.SetTop(newBlock, innerCanvas.Height / 8);
                Canvas.SetBottom(newBlock, innerCanvas.Height / 2);
                Canvas.SetRight(newBlock, newBlockRight);

                newBlock.Left = Canvas.GetLeft(newBlock);
                newBlock.Top = Canvas.GetTop(newBlock);
                newBlock.Right = Canvas.GetRight(newBlock);
                newBlock.Bottom = Canvas.GetBottom(newBlock);
                newBlock.Row = row;
                innerCanvas.Children.Add(newBlock);
                MusicBlockSetter(newBlock, timeRuler);
                MusicBlockEvents(newBlock, type);
                SetMusicBlockData(newBlock, type);
            }
        }

        private void SetMIDINote(ScrollViewer contentScrollViewer, MouseButtonEventArgs e, string type)
        {
            MusicBlock newBlock = new MusicBlock();
            newBlock.Width = MusicBlock.blockWidth;
            Grid outerGrid = (Grid)contentScrollViewer.Content;
            SetPossibleType(type, newBlock);
            Point currentPosition = e.GetPosition(outerGrid);
            int row = 0;
            int column = 0;
            if (outerGrid.RowDefinitions.Count > 0 && outerGrid.ActualHeight > 0)
            {
                row = (int)Math.Floor(currentPosition.Y / (outerGrid.ActualHeight / outerGrid.RowDefinitions.Count));
            }
            if (outerGrid.ColumnDefinitions.Count > 0 && outerGrid.ActualWidth > 0)
            {
                column = (int)Math.Floor(currentPosition.X / (outerGrid.ActualWidth / outerGrid.ColumnDefinitions.Count));
            }
            UIElement? element = outerGrid.Children.Cast<UIElement>().FirstOrDefault(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == column);
            if (element != null)
            {
                return;
            }
            Grid.SetRow(newBlock, row);
            Grid.SetColumn(newBlock, column);
            newBlock.Row = row;
            newBlock.Column = column;
            newBlock.Note = GetFullNoteName(column);
            outerGrid.Children.Add(newBlock);
            SetMusicBlockData(newBlock, type);
        }

        private void SetPossibleType (string type, MusicBlock newBlock)
        {
            if (!string.IsNullOrEmpty(type))
            {
                if (type != "TRACK")
                {
                    newBlock.TrackType.IsEnabled = false;
                    if (type == "TRACK_ARRAY")
                    {
                        newBlock.MIDITrackType.IsEnabled = false;
                        newBlock.TrackArrayType.IsChecked = true;
                    }
                    else if (type == "MIDI")
                    {
                        newBlock.TrackArrayType.IsEnabled = false;
                        newBlock.MIDITrackType.IsChecked = true;
                    }
                }
            }
        }

        private (double,double,bool) CheckSpace(Point currentPosition, MusicBlock newBlock, Canvas innerCanvas)
        {
            // Проверка, занято ли место в ячейке
            double newBlockLeft = currentPosition.X - mouseBlockOffset.X;
            bool spaceIsOccupied = false;
            if (newBlockLeft < 0)
            {
                newBlockLeft = 0; // Установите начало блока равным началу Canvas, если оно выходит за пределы Canvas
            }
            double newBlockRight = newBlockLeft + newBlock.Width;
            foreach (UIElement child in innerCanvas.Children)
            {
                if (child is MusicBlock block)
                {
                    double childLeft = Canvas.GetLeft(block);
                    if (double.IsNaN(block.Width))
                    {
                        block.Width = block.Right.Value - childLeft;
                    }
                    double childRight = childLeft + block.Width;

                    if ((newBlockLeft >= childLeft && newBlockLeft < childRight)||
                        (newBlockRight > childLeft && newBlockRight <= childRight))
                    {
                        // Место занято, не добавляйте блок
                        spaceIsOccupied = true;
                        break;
                    }
                }
            }
            return (newBlockLeft, newBlockRight, spaceIsOccupied);
        }

        private void MusicBlockSetter(MusicBlock newBlock, TimeRuler timeRuler)
        {
            newBlock.HorizontalAlignment = HorizontalAlignment.Left;
            newBlock.VerticalAlignment = VerticalAlignment.Center;
            newBlock.MusicBlockNameChanger.Text = "New Block";
            TextChangedEventArgs txtChanged = new (TextBox.TextChangedEvent,UndoAction.None);
            newBlock.MusicBlockNameChanger.RaiseEvent(txtChanged);
            if (newBlock.StartTime.TotalSeconds == 0 && newBlock.EndTime.TotalSeconds == 0)
            {
                GetBlockTime(newBlock);
            }
            
        }
        public void MusicBlockEvents(MusicBlock newBlock, string type)
        {
            timeRuler.PropertyChanged += (sender, e) => TimeRuler_PropertyChanged(e, newBlock, timeRuler);
            newBlock.LeftMouseActionEvent += (sender, e) => LeftMouseActionEvent(sender, e, newBlock);
            newBlock.RightMouseActionEvent += (sender, e) => RightMouseActionEvent(sender, e, newBlock);
            newBlock.MouseActionEvent += (sender, e) => MouseActionEvent(sender, e, newBlock);
            newBlock.UpdateInfo += () => SetMusicBlockData(newBlock, type);
        }
        private void SetMusicBlockData(MusicBlock newBlock, string type)
        {
            //object content = null;
            //if (newBlock.Type == "Track")
            //{
            //    content = newBlock.FileName;
            //}
            //else if (newBlock.Type == "MIDI" && type == "MIDI")
            //{
            //    object note = GetFullNoteName(Grid.GetRow(newBlock));
            //    content = note;
            //}
            //else if (newBlock.Type == "MIDI" && type == "TRACK" && newBlock.BlockArray != null)
            //{
            //    content = newBlock.BlockArray;
            //}
            //else if (newBlock.Type == "TrackArray" && type == "TRACK" && newBlock.BlockArray != null)
            //{
            //    content = newBlock.BlockArray;
            //}
            MusicBlockData musicBlockData = new MusicBlockData(newBlock.Guid.ToString(), type, newBlock.ScaleFactor, newBlock.Width, newBlock.BlockName.Text, 
                newBlock.StartTime, newBlock.EndTime, newBlock.EndTime - newBlock.StartTime, newBlock.Type, newBlock.PicPath, newBlock.BlockArray, newBlock.Note, newBlock.FileName, newBlock.Left, 
                newBlock.Right, newBlock.Top, newBlock.Bottom, newBlock.Row, newBlock.Column);
            FrootyLoops.Data.Entities.SetMusicBlockData.DelBlock(musicBlockData);
            FrootyLoops.Data.Entities.SetMusicBlockData.AddBlock(musicBlockData);
        }
        public static (NoteName, int) GetFullNoteName(int note)
        {
            NoteName[] noteNames = { NoteName.C, NoteName.CSharp, NoteName.D, NoteName.DSharp, NoteName.E, NoteName.F, NoteName.FSharp, NoteName.G, NoteName.GSharp, NoteName.A, NoteName.ASharp, NoteName.B };
            int octave = note / 12;
            int noteIndex = note % 12;

            return (noteNames[noteIndex], octave);
        }
        private void GetBlockTime(MusicBlock newBlock) 
        {
            double blockPosition = Canvas.GetLeft(newBlock) / 2; // Получаем позицию блока
            double blockWidth = newBlock.Width /2; // Получаем ширину блока

            newBlock.StartTime = TimeSpan.FromSeconds(blockPosition / timeRuler.ScaleFactor); // Переводим позицию блока во время начала
            newBlock.EndTime = TimeSpan.FromSeconds((blockPosition + blockWidth) / timeRuler.ScaleFactor); // Переводим позицию блока + ширину блока во время конца
        }

        private bool isDraggingLeft = false;
        private bool isDraggingRight = false;
        private bool leftClick = false;
        private bool rightClick = false;
        private Point lastPosition;

        private void LeftMouseActionEvent(object sender, MouseButtonEventArgs e, MusicBlock newBlock)
        {
            if (e.ButtonState == MouseButtonState.Pressed && leftClick == false)
            {
                isDraggingLeft = true;
                leftClick = true;
                lastPosition = e.GetPosition((Canvas)newBlock.Parent);
            }
            else if (e.ButtonState == MouseButtonState.Pressed && leftClick == true)
            {
                isDraggingLeft = false;
                leftClick = false;
                GetBlockTime(newBlock);
            }
        }

        private void RightMouseActionEvent(object sender, MouseButtonEventArgs e, MusicBlock newBlock)
        {
            if (e.ButtonState == MouseButtonState.Pressed && rightClick == false) 
            { 
                isDraggingRight = true;
                rightClick = true;
                lastPosition = e.GetPosition((Canvas)newBlock.Parent);
            }
            else if (e.ButtonState == MouseButtonState.Pressed && rightClick == true)
            {
                isDraggingRight = false;
                rightClick = false;
                GetBlockTime(newBlock);
            }
        }

        private void MouseActionEvent(object sender, MouseEventArgs e, MusicBlock newBlock)
        {
            if (isDraggingLeft)
            {
                Point currentPosition = e.GetPosition((Canvas)newBlock.Parent);
                double diff = currentPosition.X - lastPosition.X;
                newBlock.Width -= diff;
                Canvas.SetLeft(newBlock, Canvas.GetLeft(newBlock) + diff);
                lastPosition = currentPosition;
            }
            else if (isDraggingRight)
            {
                Point currentPosition = e.GetPosition((Canvas)newBlock.Parent);
                double diff = currentPosition.X - lastPosition.X;
                newBlock.Width += diff;
                lastPosition = currentPosition;
            }
        }

        private void TimeRuler_PropertyChanged(PropertyChangedEventArgs e, MusicBlock newBlock, TimeRuler timeRuler)
        {
            if (e.PropertyName == "ScaleFactor")
            {
                // Измените размер блока в соответствии с изменением времени
                double newWidth = (newBlock.EndTime.TotalSeconds - newBlock.StartTime.TotalSeconds)/2 * timeRuler.ScaleFactor;
                newBlock.Width = newWidth < newBlock.MinWidth ? newBlock.MinWidth : newWidth;

                // Измените позицию блока в соответствии с изменением времени
                double newBlockLeft = newBlock.StartTime.TotalSeconds * 2 * timeRuler.ScaleFactor;
                Canvas.SetLeft(newBlock, newBlockLeft);

                // Обновите StartTime и EndTime блока
                //newBlock.StartTime = TimeSpan.FromSeconds(newBlockLeft / timeRuler.ScaleFactor);
                //newBlock.EndTime = TimeSpan.FromSeconds((newBlockLeft + newBlock.Width) / timeRuler.ScaleFactor);
            }
        }

        public TimeRuler FindTimeRuler(DependencyObject child)
        {
            child = VisualTreeHelper.GetParent(child);
            child = VisualTreeHelper.GetParent(child);
            Grid mainGrid = (Grid)child;
            TimeRuler timeRuler = (TimeRuler)mainGrid.FindName("Content");
            return timeRuler;
        }
        private void MusicBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentPosition = e.GetPosition(null);
                dragTranslation.X = currentPosition.X - mouseOffset.X;
                dragTranslation.Y = currentPosition.Y - mouseOffset.Y;
            }
        }
    }
}
