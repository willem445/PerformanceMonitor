using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PerformanceMonitor
{
    internal class HardwareViewModel : IObserver<SettingsStruct>
    {
        //Fields********************************************************************************
        private IDisposable unsubscriber;

        private HardwareModel _HardwareModel;
        Computer thisComputer;
        Timer timer;

        private UInt32 tPoll = 30;

        //Properties****************************************************************************
        public HardwareModel HardwareModel
        {
            get
            {
                return _HardwareModel;
            }
        }

        //Constructor***************************************************************************
        public HardwareViewModel()
        {
            //Create instance of hardware model
            _HardwareModel = new HardwareModel();

            //Create instance of OpenHardwareModel
            thisComputer = new Computer() { CPUEnabled = true, GPUEnabled = true, FanControllerEnabled = false, MainboardEnabled = false, HDDEnabled = false, RAMEnabled = false };
            thisComputer.Open();

            //Update computer data 
            HardwareModel.UpdateHardware();

            //Create timer to update computer data on interval set by user
            timer = new Timer(tPoll);
            timer.Elapsed += new ElapsedEventHandler(HardwareModel.UpdateHardware);
            timer.Enabled = true;
            timer.Start();
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
            Console.WriteLine("Additional temperature data will not be transmitted.");
        }

        public virtual void OnError(Exception error)
        {
            // Do nothing.
        }

        public virtual void OnNext(SettingsStruct setting)
        {
            //Console.WriteLine("HardwareViewModel checking in.");
            //Console.WriteLine(setting.WeatherPoll);

            //Update timer interval from settings struct
            timer.Interval = setting.TempPoll;
        }


    }
}
