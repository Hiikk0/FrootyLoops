using FrootyLoops.Data.Entities;
using FrootyLoops.UserControls;
using FrootyLoops.UserControls.WorkplaceContent;
using HandyControl.Controls;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.MusicTheory;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace FrootyLoops.Services
{
    public class LoadFromFile
    {
        public Workplace workplace;
        public LoadFromFile(string pathToFile) 
        {
            workplace = Workplace.Current;
            TrackZone trackZone = (TrackZone)workplace.TrackZoneContent.Content;
            
            Grid outerGrid = (Grid) trackZone.contentScrollViewer.Content;
            MIDIList list = /*(MIDIList)workplace.MIDIListContent.Content*/ null;
            
            List<MusicBlockData> musicBlocks = GetMusicBlockData.GetMusicBlocks(pathToFile);

            foreach (MusicBlockData newBlockData in musicBlocks)
            {
                MusicBlock newBlock = CreateMusicBlock(newBlockData);
                if (newBlock.ContainerType == "TRACK")
                {
                    Canvas innerCanvas = null;
                    while (newBlock.Row >= outerGrid.RowDefinitions.Count -1)
                    {
                        RowDefinition tmpRow = new RowDefinition();
                        tmpRow.Height = new GridLength(65);
                        outerGrid.RowDefinitions.Add(tmpRow);
                        innerCanvas = new Canvas();
                        innerCanvas.Height = tmpRow.Height.Value;
                        outerGrid.Children.Add(innerCanvas);
                        Grid.SetRow(innerCanvas, newBlock.Row);
                    }
                    innerCanvas = (Canvas) outerGrid.Children[newBlock.Row];
                    Canvas.SetLeft(newBlock, newBlock.Left.Value);
                    Canvas.SetTop(newBlock, newBlock.Top.Value);
                    Canvas.SetBottom(newBlock, newBlock.Bottom.Value);
                    Canvas.SetRight(newBlock, newBlock.Right.Value);
                    innerCanvas.Children.Add(newBlock);
                    newBlock.musicBlockDrag.MusicBlockEvents(newBlock, newBlock.ContainerType);
                    switch (newBlock.Type)
                    {
                        case "Track":
                            newBlock.TrackType.IsChecked = true;
                            break;
                        case "TrackArray":
                            newBlock.TrackArrayType.IsChecked = true;
                            break;
                        case "MIDI":
                            newBlock.MIDITrackType.IsChecked = true;
                            break;
                        default:
                            break;
                    }
                }
                if (newBlock.ContainerType == "MIDI")
                {
                    Workplace.viewModel.MIDIListZone();
                    list = (MIDIList)workplace.MIDIListContent.Content;
                    Grid midiGrid = list.DynamicGrid;
                    Grid.SetRow(newBlock, newBlock.Row);
                    Grid.SetColumn(newBlock, newBlock.Column.Value);
                    midiGrid.Children.Add(newBlock);
                }
            }
        }
        private MusicBlock CreateMusicBlock(MusicBlockData blockData)
        {
            MusicBlock newBlock = new MusicBlock
            {
                Guid = blockData.Guid,
                StartTime = blockData.StartTime, 
                EndTime = blockData.EndTime,
                FileName = blockData.FileName,
                PicPath = blockData.PicPath,
                Type = blockData.Type,
                BlockArray = blockData.BlockArray,
                Note = blockData.Note,
                NameOfBlock = blockData.NameOfBlock,
                ContainerType = blockData.ContainerType,
                Width = blockData.Width,
                Left = blockData.Left,
                Right = blockData.Right,
                Top = blockData.Top,
                Bottom = blockData.Bottom,
                Row = blockData.Row,
                Column = blockData.Column,
                ScaleFactor = blockData.ScaleFactor,
            };
            return newBlock;
        }
    }
}
//switch (newBlock.ContainerType)
//{
//    case "TRACK_ARRAY":
//    case "TRACK":
//    case "MIDI":
//    default:
//        break;
//}
