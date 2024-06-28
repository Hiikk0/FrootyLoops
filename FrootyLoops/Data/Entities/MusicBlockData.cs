using FrootyLoops.Services;
using FrootyLoops.UserControls.WorkplaceContent;
using HandyControl.Controls;
using HandyControl.Data;
using Melanchall.DryWetMidi.MusicTheory;
using Octokit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FrootyLoops.Data.Entities
{
    public struct MusicBlockData(string guid, string containerType, double scaleFactor, double width, string nameOfBlock, TimeSpan startTime,
        TimeSpan endTime, TimeSpan duration, string? type, string? image, List<MusicBlock>? blockArray, (NoteName, int)? note, string? fileName, double? left, double? right, double? top, double? bottom, int row, int? column)
    {
        public string Guid { get; set; } = guid;
        public TimeSpan StartTime { get; set; } = startTime;
        public TimeSpan EndTime { get; set; } = endTime;
        public string? FileName { get; set; } = fileName;
        public string? PicPath { get; set; } = image;
        public string? Type { get; set; } = type;
        public List<MusicBlock>? BlockArray { get; set; } = blockArray;
        public (NoteName, int)? Note { get; set; } = note;
        public string NameOfBlock { get; set; } = nameOfBlock;
        public string ContainerType { get; set; } = containerType;
        public double Width { get; set; } = width;
        public double? Left { get; set; } = left;
        public double? Right { get; set; } = right;
        public double? Top { get; set; } = top;
        public double? Bottom { get; set; } = bottom;
        public int Row { get; set; } = row;
        public int? Column { get; set; } = column;
        public double ScaleFactor { get; set; } = scaleFactor;
        public TimeSpan Duration { get; set; } = duration;
    }
    //public struct RootObjectForList
    //{
    //    public string Id { get; set; }
    //    public MusicBlockData[] Values { get; set; }
    //}
    public static class SetMusicBlockData
    {
        static List<MusicBlockData> musicBlocks = new List<MusicBlockData>();
        public static void AddBlock(MusicBlockData blockData)
        {
            musicBlocks.Add(blockData);
        }
        public static void DelBlock(MusicBlockData blockData)
        {
            try
            {
                MusicBlockData blockToRemove = musicBlocks.First(b => b.Guid == blockData.Guid);
                musicBlocks.Remove(blockToRemove);
            }
            catch (Exception)
            {

            }

        }
        public static void WriteObject(string PathToSave)
        {
            JsonWorker.CreateJson(musicBlocks, PathToSave);
        }
    }
    public static class GetMusicBlockData
    {
        public static List<MusicBlockData> GetMusicBlocks(string PathToLoad)
        {
            List<MusicBlockData> musicBlocks = JsonWorker.GetMusicBlock(PathToLoad);
            if (musicBlocks == null)
            {
                Growl.Error(new GrowlInfo
                {
                    Message = "Something goes wrong at load file.",
                    Type = InfoType.Error,
                    WaitTime = 10,
                    Token = "MainMenuErrors",
                });
                return null;
            }
            return musicBlocks;
        }
    }
}
