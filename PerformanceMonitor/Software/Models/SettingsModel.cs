using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace PerformanceMonitor 
{
    class SettingsModel : INotifyPropertyChangedBase
    {
        //Fields********************************************************************************
        SettingsProvider settingsProvider;
        private string apiKey;
        private string state;
        private string town;
        private int tPoll;
        private int wPoll;
        private ObservableCollection<AppButton> appButtons;
        private ObservableCollection<AppButton> autoStartApps;
        private bool startWindowsEnabled;
        private bool dataLoggingEnabled;

        //Properties****************************************************************************
        public string APIKey
        {
            get
            {
                return apiKey;
            }
            set
            {
                apiKey = value;
                OnPropertyChanged("APIKey");
            }
        }
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                OnPropertyChanged("State");
            }
        }
        public string Town
        {
            get
            {
                return town;
            }
            set
            {
                town = value;
                OnPropertyChanged("Town");
            }
        }
        public int TempPoll
        {
            get
            {
                return tPoll;
            }
            set
            {
                tPoll = value;
                OnPropertyChanged("TempPoll");
            }
        }
        public int WeatherPoll
        {
            get
            {
                return wPoll;
            }
            set
            {
                wPoll = value;
                OnPropertyChanged("WeatherPoll");
            }
        }
        public ObservableCollection<AppButton> AppButtons
        {
            get
            {
                return appButtons;
            }
            set
            {
                appButtons = value;
                OnPropertyChanged(nameof(AppButtons));
            }
        }

        public ObservableCollection<AppButton> AutoStartApps
        {
            get
            {
                return autoStartApps;
            }
            set
            {
                autoStartApps = value;
                OnPropertyChanged(nameof(AutoStartApps));
            }
        }

        public bool StartWindowsEnabled
        {
            get
            {
                return startWindowsEnabled;
            }
            set
            {
                startWindowsEnabled = value;
                OnPropertyChanged("StartWindowsEnabled");
            }
        }
        public bool DataLoggingEnabled
        {
            get
            {
                return dataLoggingEnabled;
            }
            set
            {
                dataLoggingEnabled = value;
                OnPropertyChanged("DataLoggingEnabled");
            }
        }

        //Constructor***************************************************************************
        public SettingsModel()
        {
            settingsProvider = _SettingsProvider.SettingsProvider;
        }

        //Methods*******************************************************************************
        public void UpdateSettings(SettingsStruct _SettingsStruct)
        {
            //Update properties from settings struct
            APIKey = _SettingsStruct.APIKey;
            Town = _SettingsStruct.Town;
            State = _SettingsStruct.State;
            TempPoll = _SettingsStruct.TempPoll;
            WeatherPoll = _SettingsStruct.WeatherPoll;
            AppButtons = _SettingsStruct.AppButton;
            AutoStartApps = _SettingsStruct.AutoStartApps;
            StartWindowsEnabled = _SettingsStruct.StartWindowsEnabled;
            DataLoggingEnabled = _SettingsStruct.DataLoggingEnabled;
        }
    }
}
