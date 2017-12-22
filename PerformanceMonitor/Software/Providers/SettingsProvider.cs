using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace PerformanceMonitor
{
    //Property to access Settings Provider class
    public static class _SettingsProvider
    {
        public static SettingsProvider SettingsProvider
        {
            get; set;
        }
    }

    public class SettingsProvider : IObservable<SettingsStruct>
    {
        //Fields********************************************************************************
        List<IObserver<SettingsStruct>> observers;
        private Dictionary<string, string> settings { get; set; }

        //Properties****************************************************************************

        //Constructor***************************************************************************
        public SettingsProvider()
        {
            observers = new List<IObserver<SettingsStruct>>();
        }

        //Methods*******************************************************************************
        public void Test()
        {
            //SettingsStruct test = new SettingsStruct();
            //test.TempPoll = 100;

            //foreach (var observer in observers)
            //    observer.OnNext(test);
        }

        public void Default()
        {
            WriteGlobalDefaultSettings();
        }

        /// <summary>
        /// Read SettingsStruct from file and add values to SettingsStruct dictionary
        /// </summary>
        public void ReadSettings()
        {
            string path = System.IO.Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.MyDoc‌​uments), "Desktop_Automation");

            if (Directory.Exists(path))
            {
                settings = new Dictionary<string, string>();
                System.IO.StreamReader file = new System.IO.StreamReader(Path.Combine(path, "AutomationSettings.txt"));

                int lineCount = File.ReadLines(Path.Combine(path, "AutomationSettings.txt")).Count();

                for (int i = 0; i < lineCount; i++)
                {
                    string[] line = new string[2];
                    line = file.ReadLine().Split(new string[] { ": " }, StringSplitOptions.None);
                    settings.Add(line[0], line[1]);
                }

                file.Close();

                NotifySubscibers(settings);
            }
            else //create path and write to defaults
            {
                WriteGlobalDefaultSettings(); //write defaults

                settings = new Dictionary<string, string>();
                System.IO.StreamReader file = new System.IO.StreamReader(Path.Combine(path, "AutomationSettings.txt"));

                int lineCount = File.ReadLines(Path.Combine(path, "AutomationSettings.txt")).Count();

                for (int i = 0; i < lineCount; i++)
                {
                    string[] line = new string[2];
                    line = file.ReadLine().Split(new string[] { ": " }, StringSplitOptions.None);
                    settings.Add(line[0], line[1]);
                }

                file.Close();
            }
        }

        public void ApplySettings(SettingsStruct settings)
        {
            //Notify subscribers
            //Write data to file
            NotifySubscribers(settings);
            WriteSettings(settings);
        }

        private void NotifySubscribers(SettingsStruct settings)
        {
            foreach (var observer in observers)
            {
                observer.OnNext(settings);
            }
        }

        //TODO HP - This code does not belong in Notify Subscribers - move to own function ConvertSettingsToStruct()
        private void NotifySubscibers(Dictionary<string, string> settingsDict)
        {
            ObservableCollection<AppButton> apps = new ObservableCollection<AppButton>();
            ObservableCollection<AppButton> autoStartApps = new ObservableCollection<AppButton>();

            //Application Shortcut Buttons
            apps.Add(new AppButton(settingsDict["appBut1"], settingsDict["appName1"]));
            apps.Add(new AppButton(settingsDict["appBut2"], settingsDict["appName2"]));
            apps.Add(new AppButton(settingsDict["appBut3"], settingsDict["appName3"]));
            apps.Add(new AppButton(settingsDict["appBut4"], settingsDict["appName4"]));
            apps.Add(new AppButton(settingsDict["appBut5"], settingsDict["appName5"]));
            apps.Add(new AppButton(settingsDict["appBut6"], settingsDict["appName6"]));

            //Autostart Applications
            //autoStartApps.Add(new AppButton("test", "test"));

            bool startWindows;
            bool dataLogging;

            if (settingsDict["startWindows"] == "1")
                startWindows = true;
            else
                startWindows = false;

            if (settingsDict["dataLogging"] == "1")
                dataLogging = true;
            else
                dataLogging = false;

            SettingsStruct settings = new SettingsStruct(settingsDict["apiKey"], settingsDict["state"], settingsDict["town"], Convert.ToInt32(settingsDict["tPoll"]), Convert.ToInt32(settingsDict["wPoll"]), 
                apps, autoStartApps, startWindows, dataLogging);

            foreach(var observer in observers)
            {
                observer.OnNext(settings);
            }
        }

        /// <summary>
        /// Pass in a dictionary and write dictionary to file
        /// </summary>
        /// <param name="_SettingsStructDictionary"></param>
        private void WriteSettings(Dictionary<string, string> _SettingsStructDictionary, Dictionary<string, string> _autoKillDictionary, Dictionary<string, string> _autoStartDictionary)
        {
            string path = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.MyDoc‌​uments), "Desktop_Automation");

            if (Directory.Exists(path))
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(Path.Combine(path, "AutomationSettingsStruct.txt"));

                foreach (KeyValuePair<string, string> element in _SettingsStructDictionary)
                {
                    file.WriteLine(element.Key + ": " + element.Value);
                }

                foreach (KeyValuePair<string, string> element in _autoKillDictionary)
                {
                    file.WriteLine(element.Key + ": " + element.Value);
                }

                foreach (KeyValuePair<string, string> element in _autoStartDictionary)
                {
                    file.WriteLine(element.Key + ": " + element.Value);
                }

                file.Close();
            }
        }

        private void WriteSettings(SettingsStruct settings)
        {
            //Parse settings struct and write data to text file
            string path = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.MyDoc‌​uments), "Desktop_Automation");

            if (Directory.Exists(path))
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(Path.Combine(path, "AutomationSettings.txt"));

                file.WriteLine("apiKey: " + settings.APIKey);
                file.WriteLine("state: " + settings.State);
                file.WriteLine("town: " + settings.Town);
                file.WriteLine("tPoll: " + settings.TempPoll);
                file.WriteLine("wPoll: " + settings.WeatherPoll);

                int i = 1;
                foreach (var item in settings.AppButton)
                {
                    file.WriteLine("appBut" + i.ToString() + ": " + item.AppPath);
                    i++;
                }

                i = 1;
                foreach (var item in settings.AppButton)
                {
                    file.WriteLine("appName" + i.ToString() + ": " + item.AppName);
                    i++;
                }

                file.WriteLine("startWindows: " + (Convert.ToInt32(settings.StartWindowsEnabled)).ToString());
                file.WriteLine("dataLogging: " + (Convert.ToInt32(settings.DataLoggingEnabled)).ToString());

                file.Close();
            }
        }

        /// <summary>
        /// Apply global defaults to file
        /// </summary>
        private void WriteGlobalDefaultSettings()
        {
            string path = System.IO.Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.MyDoc‌​uments), "Desktop_Automation");

            Directory.CreateDirectory(path);
            System.IO.StreamWriter file = new System.IO.StreamWriter(Path.Combine(path, "AutomationSettingsStruct.txt"));
            file.WriteLine("apiKey: 1cca1919311be93d");
            file.WriteLine("state: IL");
            file.WriteLine("town: Chicago");
            file.WriteLine("tPoll: 1000");
            file.WriteLine("wPoll: 30");
            file.WriteLine("appBut1: C:\\Windows\\system32\\calc");
            file.WriteLine("appBut2: C:\\Windows\\system32\\calc");
            file.WriteLine("appBut3: C:\\Windows\\system32\\calc");
            file.WriteLine("appBut4: C:\\Windows\\system32\\calc");
            file.WriteLine("appBut5: C:\\Windows\\system32\\calc");
            file.WriteLine(@"appBut6: C:\\Windows\\system32\\calc");
            file.WriteLine("appName1: Calculator");
            file.WriteLine("appName2: Calculator");
            file.WriteLine("appName3: Calculator");
            file.WriteLine("appName4: Calculator");
            file.WriteLine("appName5: Calculator");
            file.WriteLine("appName6: Calculator");
            file.WriteLine("startWindows: 0");
            file.WriteLine("datalogging: 0");

            file.Close();
        }

        /// <summary>
        /// Starts applications in the autostart list
        /// </summary>
        /// <param name="_autoStartDictionary"></param>
        public void AutoStartApplications(Dictionary<string, string> _autoStartDictionary)
        {
            foreach (KeyValuePair<string, string> autostart in _autoStartDictionary)
            {
                if (!Environment.Is64BitProcess)
                    Process.Start(autostart.Value);
                else
                    Process.Start(autostart.Value);
            }
        }

        /// <summary>
        /// Kills applications in the autokill list
        /// </summary>
        /// <param name="_autoKillDictionary"></param>
        public void AutoKillApplications(Dictionary<string, string> _autoKillDictionary)
        {
            foreach (KeyValuePair<string, string> autokill in _autoKillDictionary)
            {
                string pr = autokill.Value.Split('\\').Last().Split('.')[0];

                foreach (var process in Process.GetProcessesByName(pr))
                {
                    process.Kill();
                }
            }
        }

        //IObservable***************************************************************************
        public IDisposable Subscribe(IObserver<SettingsStruct> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);


            return new Unsubscriber(observers, observer);
        }
    }

    class Unsubscriber : IDisposable
    {
        private List<IObserver<SettingsStruct>> _observers;
        private IObserver<SettingsStruct> _observer;

        public Unsubscriber(List<IObserver<SettingsStruct>> observers, IObserver<SettingsStruct> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (!(_observer == null)) _observers.Remove(_observer);
        }
    }
}
