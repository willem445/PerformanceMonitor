using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceMonitor
{
    class AppShortcutModel : INotifyPropertyChangedBase
    {
        //Fields********************************************************************************
        private List<string> appName;
        private List<string> appPath;

        //Properties**************************************************************************** 
        public List<string> AppNameList
        {
            get
            {
                return appName;
            }
            set
            {
                appName = value;
                OnPropertyChanged(nameof(AppNameList));
                OnPropertyChanged(nameof(AppName1));
                OnPropertyChanged(nameof(AppName2));
                OnPropertyChanged(nameof(AppName3));
                OnPropertyChanged(nameof(AppName4));
                OnPropertyChanged(nameof(AppName5));
                OnPropertyChanged(nameof(AppName6));
            }
        }
        public List<string> AppPathList
        {
            get
            {
                return appPath;
            }
            set
            {
                appPath = value;
                OnPropertyChanged(nameof(AppPathList));
                OnPropertyChanged(nameof(AppPath1));
                OnPropertyChanged(nameof(AppPath2));
                OnPropertyChanged(nameof(AppPath3));
                OnPropertyChanged(nameof(AppPath4));
                OnPropertyChanged(nameof(AppPath5));
                OnPropertyChanged(nameof(AppPath6));
            }
        }

        public string AppName1
        {
            get
            {
                return appName[0];
            }
            set
            {
                appName[0] = value;
                OnPropertyChanged(nameof(AppName1));
            }
        }
        public string AppName2
        {
            get
            {
                return appName[1];
            }
            set
            {
                appName[1] = value;
                OnPropertyChanged(nameof(AppName2));
            }
        }
        public string AppName3
        {
            get
            {
                return appName[2];
            }
            set
            {
                appName[2] = value;
                OnPropertyChanged(nameof(AppName3));
            }
        }
        public string AppName4
        {
            get
            {
                return appName[3];
            }
            set
            {
                appName[3] = value;
                OnPropertyChanged(nameof(AppName4));
            }
        }
        public string AppName5
        {
            get
            {
                return appName[4];
            }
            set
            {
                appName[4] = value;
                OnPropertyChanged(nameof(AppName5));
            }
        }
        public string AppName6
        {
            get
            {
                return appName[5];
            }
            set
            {
                appName[5] = value;
                OnPropertyChanged(nameof(AppName6));
            }
        }

        public string AppPath1
        {
            get
            {
                return appPath[0];
            }
            set
            {
                appPath[0] = value;
                OnPropertyChanged(nameof(AppPath1));
            }
        }
        public string AppPath2
        {
            get
            {
                return appPath[1];
            }
            set
            {
                appPath[1] = value;
                OnPropertyChanged(nameof(AppPath2));
            }
        }
        public string AppPath3
        {
            get
            {
                return appPath[2];
            }
            set
            {
                appPath[2] = value;
                OnPropertyChanged(nameof(AppPath3));
            }
        }
        public string AppPath4
        {
            get
            {
                return appPath[3];
            }
            set
            {
                appPath[3] = value;
                OnPropertyChanged(nameof(AppPath4));
            }
        }
        public string AppPath5
        {
            get
            {
                return appPath[4];
            }
            set
            {
                appPath[4] = value;
                OnPropertyChanged(nameof(AppPath5));
            }
        }
        public string AppPath6
        {
            get
            {
                return appPath[5];
            }
            set
            {
                appPath[5] = value;
                OnPropertyChanged(nameof(AppPath6));
            }
        }

        //Constructor***************************************************************************
        public AppShortcutModel()
        {

        }

    }
}
