using FrootyLoops.Data.Entities;
using FrootyLoops.UserControls.WorkplaceContent;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Multimedia;
using Melanchall.DryWetMidi.MusicTheory;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrootyLoops.Services
{
    //NamikoEngine, 2024
    public class Engine
    {
        public Engine() 
        {

        }
        private static List<TimedEvent> midiEvents = new List<TimedEvent>();
        private List<string> audioFiles = new List<string>() /*{ "file1.wav", "file2.wav" }*/;
        private List<double> startTimes = new List<double>() /*{ 10, 15 }*/; // in seconds
        private List<double> endTimes = new List<double>() /*{ 25, 48 }*/; // in seconds
        private List<WaveOut> waveOuts = new List<WaveOut>();
        private List<AudioFileReader> audioFileReaders = new List<AudioFileReader>();
        public void LoadFilesToEngine(List<MusicBlock> musicBlocks)
        {
            foreach (var block in musicBlocks)
            {
                if (!string.IsNullOrEmpty(block.FileName) && block.StartTime.TotalSeconds != 0 && block.EndTime.TotalSeconds != 0)
                {

                    audioFiles.Add(block.FileName);
                    startTimes.Add(block.StartTime.TotalSeconds);
                    endTimes.Add(block.EndTime.TotalSeconds);
                }
            }
            PlayTracks();
        }
        public void PlayTracks()
        {
            var mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 2));
            mixer.ReadFully = true;

            for (int i = 0; i < audioFiles.Count; i++)
            {
                var reader = new AudioFileReader(audioFiles[i])
                {
                    Volume = 1.0f
                };
                audioFileReaders.Add(reader);

                var resampler = new WdlResamplingSampleProvider(reader, 44100);

                var offsetSampleProvider = new OffsetSampleProvider(resampler)
                {
                    DelayBy = TimeSpan.FromSeconds(startTimes[i]),
                    LeadOut = TimeSpan.FromSeconds(endTimes[i])
                };

                mixer.AddMixerInput(offsetSampleProvider);
            }

            var waveOut = new WaveOutEvent();
            waveOut.Init(new SampleToWaveProvider(mixer));
            waveOut.Play();
        }

        public static void PlayMIDI(List<MusicBlockData> musicBlocks)
        {
            // Создаем MIDI файл
            var midiFile = new MidiFile();

            // Создаем трек
            var trackChunk = new TrackChunk();
            midiFile.Chunks.Add(trackChunk);

            // Добавляем события (нажатие и отпускание клавиши)
            foreach (MusicBlockData musicBlock in musicBlocks)
            {
                var octaveValue = musicBlock.Note.Value.Item2; // Получите значение октавы (например, 4)
                var note = new Melanchall.DryWetMidi.Interaction.Note(NoteName.C, octaveValue, 5, musicBlock.Column.Value); // Нота C4
                var noteOnEvent = note.GetTimedNoteOnEvent();
                var noteOffEvent = note.GetTimedNoteOffEvent();

                trackChunk.Events.Add(noteOnEvent.Event);
                trackChunk.Events.Add(noteOffEvent.Event);
            }
            var playback = new MidiFile(trackChunk).GetPlayback();
            playback.Start();
        }

        public void StopTracks()
        {
            foreach (var waveOut in waveOuts)
            {
                waveOut.Stop();
                waveOut.Dispose();
            }
            waveOuts.Clear();

            foreach (var reader in audioFileReaders)
            {
                reader.Dispose();
            }
            audioFileReaders.Clear();
        }
    }
}
