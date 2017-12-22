using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PerformanceMonitor
{
    public struct SettingsStruct
    {
        private string _apiKey;
        private string _state;
        private string _town;
        private int _tempPoll;
        private int _weatherPoll;
        private ObservableCollection<AppButton> _apps;
        private ObservableCollection<AppButton> _autostartApps;
        private bool _startWindowsEnabled;
        private bool _dataLoggingEnabled;

        public SettingsStruct(string apiKey, string state, string town, int tempPoll, int weatherPoll, ObservableCollection<AppButton> appCollection, ObservableCollection<AppButton> autoStartApps, bool startWindowsEnabled, bool dataLoggingEnabled)
        {
            this._apiKey = apiKey;
            this._state = state;
            this._town = town;
            this._tempPoll = tempPoll;
            this._weatherPoll = weatherPoll;
            this._apps = appCollection;
            this._autostartApps = autoStartApps;
            this._startWindowsEnabled = startWindowsEnabled;
            this._dataLoggingEnabled = dataLoggingEnabled;
        }

        public string APIKey { get { return this._apiKey; } }
        public string State { get { return this._state; } }
        public string Town { get { return this._town; } }
        public int TempPoll { get { return this._tempPoll; } }
        public int WeatherPoll { get { return this._weatherPoll; } }
        public ObservableCollection<AppButton> AppButton { get { return this._apps; } }
        public ObservableCollection<AppButton> AutoStartApps { get { return this._autostartApps; } }
        public bool StartWindowsEnabled { get { return this._startWindowsEnabled; } }
        public bool DataLoggingEnabled { get { return this._dataLoggingEnabled; } }
    }
}
