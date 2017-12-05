using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PerformanceMonitor
{
    internal class SettingsViewModel : INotifyPropertyChangedBase, IObserver<SettingsStruct> 
    {
        //Fields********************************************************************************
        private IDisposable unsubscriber;
        private SettingsModel _SettingsModel;
        private bool applyButtonClicked;

        //State combobox fields
        private ObservableCollection<US_State> states;
        private string selectedState;

        private string selectedButton;

        //Temporary fields
        private string townTemp;
        private string stateTemp;
        private int tPollTemp;
        private int wPollTemp;
        private bool startWindowsTemp;
        private bool dataLoggingTemp;

        //Properties****************************************************************************
        public SettingsModel SettingsModel
        {
            get
            {
                return _SettingsModel;
            }
        }
        public ObservableCollection<US_State> States
        {
            get
            {
                return states;
            }
            set
            {
                states = value;
                OnPropertyChanged(nameof(States));
            }
        }
        public string SelectedState
        {
            get
            {
                return selectedState;
            }
            set
            {
                selectedState = value;
                OnPropertyChanged(nameof(SelectedState));
            }
        }
        public string SelectedButton
        {
            get
            {
                return selectedButton;
            }
            set
            {
                selectedButton = value;
                OnPropertyChanged(nameof(SelectedButton));
            }
        }

        //Constructor***************************************************************************
        public SettingsViewModel()
        {
            _SettingsModel = new SettingsModel(); //Instantiate settings model
            States = StateArray.States(); //Create list of states
        }

        //Methods*******************************************************************************
        internal void Apply()
        {
            applyButtonClicked = true;

            //Update state in settings model with combobox selected item
            SettingsModel.State = SelectedState;

            SettingsStruct _SettingsStruct = new SettingsStruct(
                SettingsModel.APIKey,
                SettingsModel.State,
                SettingsModel.Town,
                SettingsModel.TempPoll,
                SettingsModel.WeatherPoll,
                SettingsModel.AppButtons,
                SettingsModel.StartWindowsEnabled,
                SettingsModel.DataLoggingEnabled);

            //Write settings to file and notify subscribers of changes
            _SettingsProvider.SettingsProvider.ApplySettings(_SettingsStruct);
        }

        internal void Default()
        {
            //Write global defaults
            _SettingsProvider.SettingsProvider.Default();
        }

        /// <summary>
        /// Open settings tab, store settings in temp fields if user does not apply settings
        /// </summary>
        internal void SettingsClick()
        {
            //Populate temporary fields to hold current settings data
            stateTemp = SettingsModel.State;
            townTemp = SettingsModel.Town;
            tPollTemp = SettingsModel.TempPoll;
            wPollTemp = SettingsModel.WeatherPoll;
            startWindowsTemp = SettingsModel.StartWindowsEnabled;
            dataLoggingTemp = SettingsModel.DataLoggingEnabled;
        }

        /// <summary>
        /// Close settings tab and apply new settings or revert to original settings
        /// </summary>
        internal void Close()
        {
            //If apply button has not been pressed, update settings model data with original settings
            if (applyButtonClicked == false)
            {
                SelectedState = stateTemp;
                SettingsModel.State = stateTemp;
                SettingsModel.Town = townTemp;
                SettingsModel.TempPoll = tPollTemp;
                SettingsModel.DataLoggingEnabled = dataLoggingTemp;
                SettingsModel.StartWindowsEnabled = startWindowsTemp;
            }

            //Reset apply button clicked
            applyButtonClicked = false;

        }

        /// <summary>
        /// Change open application shortcut button
        /// </summary>
        internal void SetButton()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            Nullable<bool> result = openFileDialog1.ShowDialog();

            if (result == true)
            {
                string strfilename = openFileDialog1.InitialDirectory + openFileDialog1.FileName;

                //User names the application
                EnterAppName getAppName = new EnterAppName();
                Nullable<bool> appNameResult = getAppName.ShowDialog();

                if (appNameResult == true)
                {
                    string appName = getAppName._displayName;

                    //Find correct index and change property containing app button data
                    for (int i = 0; i < 6; i++)
                    {
                        if (SettingsModel.AppButtons[i].AppName == SelectedButton)
                        {
                            SettingsModel.AppButtons[i].AppName = appName;
                            SettingsModel.AppButtons[i].AppPath = strfilename;
                            SelectedButton = appName;
                        }
                    }
                }
            }
        }

        internal void AddAutoStartButton()
        {
            Console.WriteLine("Test");
        }

        internal void RemoveAutoStartButton()
        {
            Console.WriteLine("Test");
        }

        //ICommand******************************************************************************
        public ICommand ApplyCommand
        {
            get
            {
                return new RelayCommand(Apply);
            }
        }

        public ICommand DefaultCommand
        {
            get
            {
                return new RelayCommand(Default);
            }
        }

        public ICommand SettingsButtonClickCommand
        {
            get
            {
                return new RelayCommand(SettingsClick);
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                return new RelayCommand(Close);
            }
        }

        public ICommand SetButtonCommand
        {
            get
            {
                return new RelayCommand(SetButton);
            }
        }

        public ICommand AddAutoStartCommand
        {
            get
            {
                return new RelayCommand(AddAutoStartButton);
            }
        }

        public ICommand RemoveAutoStartCommand
        {
            get
            {
                return new RelayCommand(RemoveAutoStartButton);
            }
        }

        //IObserver*****************************************************************************
        public virtual void Subscribe(IObservable<SettingsStruct> provider)
        {
            unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        public virtual void OnCompleted()
        {
            //Console.WriteLine("Additional temperature data will not be transmitted.");
        }

        public virtual void OnError(Exception error)
        {
            // Do nothing.
        }

        public virtual void OnNext(SettingsStruct _SettingsStruct)
        {
            SettingsModel.UpdateSettings(_SettingsStruct);
            SelectedState = SettingsModel.State;
        }
    }

    static class StateArray
    {
        static ObservableCollection<US_State> states;

        static StateArray()
        {
            states = new ObservableCollection<US_State>();
            states.Add(new US_State("AL", "Alabama"));
            states.Add(new US_State("AK", "Alaska"));
            states.Add(new US_State("AZ", "Arizona"));
            states.Add(new US_State("AR", "Arkansas"));
            states.Add(new US_State("CA", "California"));
            states.Add(new US_State("CO", "Colorado"));
            states.Add(new US_State("CT", "Connecticut"));
            states.Add(new US_State("DE", "Delaware"));
            states.Add(new US_State("DC", "District Of Columbia"));
            states.Add(new US_State("FL", "Florida"));
            states.Add(new US_State("GA", "Georgia"));
            states.Add(new US_State("HI", "Hawaii"));
            states.Add(new US_State("ID", "Idaho"));
            states.Add(new US_State("IL", "Illinois"));
            states.Add(new US_State("IN", "Indiana"));
            states.Add(new US_State("IA", "Iowa"));
            states.Add(new US_State("KS", "Kansas"));
            states.Add(new US_State("KY", "Kentucky"));
            states.Add(new US_State("LA", "Louisiana"));
            states.Add(new US_State("ME", "Maine"));
            states.Add(new US_State("MD", "Maryland"));
            states.Add(new US_State("MA", "Massachusetts"));
            states.Add(new US_State("MI", "Michigan"));
            states.Add(new US_State("MN", "Minnesota"));
            states.Add(new US_State("MS", "Mississippi"));
            states.Add(new US_State("MO", "Missouri"));
            states.Add(new US_State("MT", "Montana"));
            states.Add(new US_State("NE", "Nebraska"));
            states.Add(new US_State("NV", "Nevada"));
            states.Add(new US_State("NH", "New Hampshire"));
            states.Add(new US_State("NJ", "New Jersey"));
            states.Add(new US_State("NM", "New Mexico"));
            states.Add(new US_State("NY", "New York"));
            states.Add(new US_State("NC", "North Carolina"));
            states.Add(new US_State("ND", "North Dakota"));
            states.Add(new US_State("OH", "Ohio"));
            states.Add(new US_State("OK", "Oklahoma"));
            states.Add(new US_State("OR", "Oregon"));
            states.Add(new US_State("PA", "Pennsylvania"));
            states.Add(new US_State("RI", "Rhode Island"));
            states.Add(new US_State("SC", "South Carolina"));
            states.Add(new US_State("SD", "South Dakota"));
            states.Add(new US_State("TN", "Tennessee"));
            states.Add(new US_State("TX", "Texas"));
            states.Add(new US_State("UT", "Utah"));
            states.Add(new US_State("VT", "Vermont"));
            states.Add(new US_State("VA", "Virginia"));
            states.Add(new US_State("WA", "Washington"));
            states.Add(new US_State("WV", "West Virginia"));
            states.Add(new US_State("WI", "Wisconsin"));
            states.Add(new US_State("WY", "Wyoming"));
        }

        public static ObservableCollection<US_State> States()
        {
            return states;
        }
    }

    public class US_State
    {
        public string Name { get; set; }
        public string Abbreviations { get; set; }

        public US_State(string abbreviations, string name)
        {
            Abbreviations = abbreviations;
            Name = name;
        }
    }

    public class AppButton : INotifyPropertyChangedBase
    {
        private string appPath;
        private string appName;

        public string AppPath
        {
            get
            {
                return appPath;
            }
            set
            {
                appPath = value;
                OnPropertyChanged(nameof(AppPath));
            }
        }
        public string AppName
        {
            get
            {
                return appName;
            }
            set
            {
                appName = value;
                OnPropertyChanged(nameof(AppName));
            }
        }


        public AppButton(string appPath, string appName)
        {
            this.AppPath = appPath;
            this.AppName = appName;
        }
    }
}
