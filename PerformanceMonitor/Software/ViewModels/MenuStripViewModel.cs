using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace PerformanceMonitor
{
    internal class MenuStripViewModel : INotifyPropertyChanged
    {
        //Fields*******************************************************************************

        //Properties***************************************************************************

        //Constructor**************************************************************************
        public MenuStripViewModel()
        {
            
        }

        //Methods******************************************************************************
        internal void SettingsButtonClick()
        {
            Console.WriteLine("Settings button clicked!");
        }

        //ICommand*****************************************************************************
        public ICommand SettingsButtonClickCommand
        {
            get
            {
                return new RelayCommand(SettingsButtonClick);
            }
        }

        //INotifyPropertyChanged****************************************************************
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
