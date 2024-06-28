using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrootyLoops.UserControls.WorkplaceContent;

namespace FrootyLoops.ViewModel
{
    public class WorkplaceViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Тимчасова змінна для поточного UserControl.
        /// </summary>
        private object? _currentTrackZoneViewModel;
        /// <summary>
        /// Повернення поточного UserControl та його встановлення
        /// </summary>
        public object CurrentTrackZoneContent
        {
            get
            {

                return _currentTrackZoneViewModel;
            }
            set
            {
                _currentTrackZoneViewModel = value;
                OnPropertyChanged("CurrentTrackZoneContent");
            }
        }
       
        public void TrackZone()
        {
            var content = new TrackZone();
            CurrentTrackZoneContent = content;
        }
    
        /// <summary>
        /// Тимчасова змінна для поточного UserControl.
        /// </summary>
        private object? _currentTimeRulerViewModel;
        /// <summary>
        /// Повернення поточного UserControl та його встановлення
        /// </summary>
        public object CurrentTimeRulerContent
        {
            get
            {

                return _currentTimeRulerViewModel;
            }
            set
            {
                _currentTimeRulerViewModel = value;
                OnPropertyChanged("CurrentTimeRulerContent");
            }
        }
        public void TimeRulerZone()
        {
            var content = new TimeRuler();
            //content.Duration = TimeSpan.FromSeconds(10);

            CurrentTimeRulerContent = content;
        }

        /// <summary>
        /// Тимчасова змінна для поточного UserControl.
        /// </summary>
        private object? _currentStorageViewModel;
        /// <summary>
        /// Повернення поточного UserControl та його встановлення
        /// </summary>
        public object CurrentStorageContent
        {
            get
            {

                return _currentStorageViewModel;
            }
            set
            {
                _currentStorageViewModel = value;
                OnPropertyChanged("CurrentStorageContent");
            }
        }
        public void StorageZone()
        {
            var content = new Storage();
            CurrentStorageContent = content;
        }

        /// <summary>
        /// Тимчасова змінна для поточного UserControl.
        /// </summary>
        private object? _currentMIDIListViewModel;
        public int typeChk = 0;
        /// <summary>
        /// Повернення поточного UserControl та його встановлення
        /// </summary>
        public object CurrentMIDIListContent
        {
            get
            {

                return _currentMIDIListViewModel;
            }
            set
            {
                _currentMIDIListViewModel = value;
                OnPropertyChanged("CurrentMIDIListContent");
            }
        }
        public void MIDIListZone()
        {
            var content = new MIDIList();
            CurrentMIDIListContent = content;
        }

        public void TrackArrayZone()
        {
            var content = new TrackArray();
            CurrentMIDIListContent = content;
        }

        public void TrackViewZone()
        {
            var content = new TrackView();
            CurrentMIDIListContent = content;
        }

        /// <summary>
        /// Тимчасова змінна для поточного UserControl.
        /// </summary>
        private object? _currentUserResoursesViewModel;
        /// <summary>
        /// Повернення поточного UserControl та його встановлення
        /// </summary>
        public object CurrentUserResoursesContent
        {
            get
            {

                return _currentUserResoursesViewModel;
            }
            set
            {
                _currentUserResoursesViewModel = value;
                OnPropertyChanged("CurrentUserResoursesContent");
            }
        }
        public void UserResoursesZone()
        {
            var content = new UserResourses();
            CurrentUserResoursesContent = content;
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
