using System;
using System.Collections.Generic;
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
using System.Timers;
using Microsoft.Win32;
using System.Windows.Media.Animation;
using System.Diagnostics;

//---------------------------------------------------------------------------------------------
//Program Update Flow
//---------------------------------------------------------------------------------------------
//1. SettingsProvider reads and updates settingsstruct
//2. SettingsProvider updates subscibers with new settings data -> WeatherViewModel, HardwareViewModel, SettingsViewModel
//3. SettingsViewModel reads new settings and updates SettingsModel -> SettingsModel updates (INotifyPropertyChanged) SettingsView
//4. WeatherViewModel reads new settings and updates weather polling time
//5. HardwareViewModel reads new settings and updates hardware polling time
//6. SettingsView "apply" or "ok" button click event (ICommand) calls SettingsProvider to update subscibers and write new settings to file

//---------------------------------------------------------------------------------------------
//To Do List
//---------------------------------------------------------------------------------------------
//TODO - dataLogger
//TODO - start with windows
//TODO - autostart
//TODO - autoclose

namespace PerformanceMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Class Variables***********************************************************************





        string versionID = "v1.1.0";




        //Constructor***************************************************************************
        public MainWindow()
        {
            //Instantiate settings provider class
            _SettingsProvider.SettingsProvider = new SettingsProvider();

            InitializeComponent();
            this.Title = "Performance Monitor " + versionID;

            //Initialize settings for form
            _SettingsProvider.SettingsProvider.ReadSettings();
        }

        //Methods******************************************************************************* 

        #region App Button Event Methods
        /// <summary>
        /// Custom method for label button, highlights text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_MouseEnter(object sender, MouseEventArgs e)
        {
            var item = (Label)sender;
            item.FontWeight = FontWeights.Bold;
        }

        /// <summary>
        /// Custom method for label button, dehighlights text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_MouseLeave(object sender, MouseEventArgs e)
        {
            var item = (Label)sender;
            item.FontWeight = FontWeights.Normal;
        }

        /// <summary>
        /// Launches application that is bound to label button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void appButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //var item = (Label)sender;

            //var processStart = from x in settingsDictionary
            //                   where x.Value.Contains(item.Content.ToString())
            //                   select x;

            //foreach(KeyValuePair<string, string> value in processStart)
            //{
            //    string key = "appBut" + value.Key[value.Key.Length - 1];

            //    if (!Environment.Is64BitProcess)
            //        System.Diagnostics.Process.Start(settingsDictionary[key]);
            //    else
            //        System.Diagnostics.Process.Start(settingsDictionary[key]);
            //}
        }
        #endregion







        /// <summary>
        /// Add application to autostart list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addAutostartButton_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //Nullable<bool> result = openFileDialog.ShowDialog();

            //if (result == true)
            //{
            //    autoStartCount++;
            //    string strfilename = openFileDialog.InitialDirectory + openFileDialog.FileName;
            //    autoStartDictionary.Add("autoStart" + autoStartCount.ToString(), strfilename); //add autostart app to dictionary
            //    autoStartComboBox.Items.Add(openFileDialog.FileName.Split('\\').Last().Split('.')[0]); //add to comboBox
            //}
        }

        /// <summary>
        /// Remove application from autostart list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeAutostartButton_Click(object sender, RoutedEventArgs e)
        {
            //Dictionary<string, string> tempDict = new Dictionary<string, string>();
            //string removeKey = "";
            //string removeValue = "";
            //var dictVal = from x in autoStartDictionary
            //              where x.Value.Contains(autoStartComboBox.Text)
            //              select x;

            //foreach (KeyValuePair<string, string> item in dictVal)
            //{
            //    //Console.WriteLine(item.Key);
            //    removeKey = item.Key;
            //    removeValue = item.Value;
            //}

            //autoStartDictionary.Remove(removeKey); //remove entry from dictionary
            //autoStartComboBox.Items.Remove(removeValue.Split('\\').Last().Split('.')[0]); //remove entry from comboBox
            //autoStartCount--;

            ////Update dictionary
            //for (int i = 0; i < autoStartDictionary.Count; i++)
            //{
            //    tempDict.Add("autoStart" + (i + 1).ToString(), autoStartDictionary.Values.ElementAt(i));
            //}

            //autoStartDictionary.Clear();

            //foreach (KeyValuePair<string, string> item in tempDict)
            //{
            //    autoStartDictionary.Add(item.Key, item.Value);
            //}
        }

        /// <summary>
        /// Add application to autokill list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addAutokillButton_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //Nullable<bool> result = openFileDialog1.ShowDialog();

            //if (result == true)
            //{
            //    autoKillCount++; //increment the number of autokill apps 
            //    string strfilename = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
            //    autoKillDictionary.Add("autoKill" + autoKillCount, strfilename); //add autokill app to dictionary
            //    autoKillComboBox.Items.Add(openFileDialog1.FileName.Split('\\').Last().Split('.')[0]); //add to comboBox
            //}
        }

        /// <summary>
        /// Remove application from autokill list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeAutokillButton_Click(object sender, RoutedEventArgs e)
        {
            //Dictionary<string, string> tempDict = new Dictionary<string, string>();
            //string removeKey = "";
            //string removeValue = "";
            //var dictVal = from x in autoKillDictionary
            //              where x.Value.Contains(autoKillComboBox.Text)
            //              select x;

            //foreach (KeyValuePair<string, string> item in dictVal)
            //{
            //    //Console.WriteLine(item.Key);
            //    removeKey = item.Key;
            //    removeValue = item.Value;
            //}

            //autoKillDictionary.Remove(removeKey);
            //autoKillComboBox.Items.Remove(removeValue.Split('\\').Last().Split('.')[0]);
            //autoKillCount--;

            ////Update dictionary
            //for (int i = 0; i < autoKillDictionary.Count; i++)
            //{
            //    tempDict.Add("autoKill" + (i + 1).ToString(), autoKillDictionary.Values.ElementAt(i));
            //}

            //autoKillDictionary.Clear();

            //foreach (KeyValuePair<string, string> item in tempDict)
            //{
            //    autoKillDictionary.Add(item.Key, item.Value);
            //}
        }

        /// <summary>
        /// Add or remove application from windows autostart registry
        /// </summary>
        /// <param name="startWithWindows"></param>
        private void SetStartup(Int32 startWithWindows)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (startWithWindows == 1)
                rk.SetValue("Performance Monitor", System.Reflection.Assembly.GetExecutingAssembly().Location.ToString());
            else
                rk.DeleteValue("Performance Monitor", false);
        }
    }




}
