using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PerformanceMonitor
{
    internal class AppShortcutViewModel : IObserver<SettingsStruct> 
    {
        //Fields********************************************************************************
        private IDisposable unsubscriber;
        private AppShortcutModel _AppShortcutModel;

        //Properties****************************************************************************
        public AppShortcutModel AppShortcutModel
        {
            get
            {
                return _AppShortcutModel;
            }
        }

        //Constructor***************************************************************************
        public AppShortcutViewModel()
        {
            _AppShortcutModel = new AppShortcutModel();
        }

        //Methods*******************************************************************************
        internal void OpenApp1()
        {
            if (!Environment.Is64BitProcess)
                System.Diagnostics.Process.Start(AppShortcutModel.AppPath1);
            else
                System.Diagnostics.Process.Start(AppShortcutModel.AppPath1);
        }

        internal void OpenApp2()
        {
            if (!Environment.Is64BitProcess)
                System.Diagnostics.Process.Start(AppShortcutModel.AppPath2);
            else
                System.Diagnostics.Process.Start(AppShortcutModel.AppPath2);
        }

        internal void OpenApp3()
        {
            if (!Environment.Is64BitProcess)
                System.Diagnostics.Process.Start(AppShortcutModel.AppPath3);
            else
                System.Diagnostics.Process.Start(AppShortcutModel.AppPath3);
        }

        internal void OpenApp4()
        {
            if (!Environment.Is64BitProcess)
                System.Diagnostics.Process.Start(AppShortcutModel.AppPath4);
            else
                System.Diagnostics.Process.Start(AppShortcutModel.AppPath4);
        }

        internal void OpenApp5()
        {
            if (!Environment.Is64BitProcess)
                System.Diagnostics.Process.Start(AppShortcutModel.AppPath5);
            else
                System.Diagnostics.Process.Start(AppShortcutModel.AppPath5);
        }

        internal void OpenApp6()
        {
            if (!Environment.Is64BitProcess)
                System.Diagnostics.Process.Start(AppShortcutModel.AppPath6);
            else
                System.Diagnostics.Process.Start(AppShortcutModel.AppPath6);
        }

        //ICommand******************************************************************************
        public ICommand OpenApp1Command
        {
            get
            {
                return new RelayCommand(OpenApp1);
            }
        }

        public ICommand OpenApp2Command
        {
            get
            {
                return new RelayCommand(OpenApp2);
            }
        }

        public ICommand OpenApp3Command
        {
            get
            {
                return new RelayCommand(OpenApp3);
            }
        }

        public ICommand OpenApp4Command
        {
            get
            {
                return new RelayCommand(OpenApp4);
            }
        }

        public ICommand OpenApp5Command
        {
            get
            {
                return new RelayCommand(OpenApp5);
            }
        }

        public ICommand OpenApp6Command
        {
            get
            {
                return new RelayCommand(OpenApp6);
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

        }

        public virtual void OnError(Exception error)
        {
            // Do nothing.
        }

        public virtual void OnNext(SettingsStruct setting)
        {
            List<string> appNameList = new List<string>();
            List<string> appPathList = new List<string>();

            //Update application buttons
            foreach (var item in setting.AppButton)
            {
                appNameList.Add(item.AppName);
                appPathList.Add(item.AppPath);
            }

            AppShortcutModel.AppNameList = appNameList;
            AppShortcutModel.AppPathList = appPathList;
        }
    }
}
