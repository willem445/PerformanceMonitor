using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PerformanceMonitor
{
    class HardwareModel : INotifyPropertyChangedBase
    {
        //Fields********************************************************************************
        Computer thisComputer;

        #region Fields
        //PKG Fields
        private int cpuPkgTemp;
        private int cpuPkgLoad;
        private int gpuPkgMem;
        private int gpuPkgLoad;
        private int gpuPkgFan;
        private int gpuPkgTemp;

        //CPU Fields
        //CPU Name
        private string cpuName;

        //Core 0
        private string cpuCore0;
        private string cpuCore0Min;
        private string cpuCore0Max;
        private string cpuCore0Load;

        //Core 1
        private string cpuCore1;
        private string cpuCore1Min;
        private string cpuCore1Max;
        private string cpuCore1Load;

        //Core 2
        private string cpuCore2;
        private string cpuCore2Min;
        private string cpuCore2Max;
        private string cpuCore2Load;

        //Core 3
        private string cpuCore3;
        private string cpuCore3Min;
        private string cpuCore3Max;
        private string cpuCore3Load;

        //GPU Fields
        private string gpuName;
        private string gpuTemp;
        private string gpuTempMin;
        private string gpuTempMax;
        private string gpuLoad;
        private string gpuMem;
        private string gpuFan;
        #endregion

        //Properties****************************************************************************
        #region CPU Properties
        public int CPUPkgTemp
        {
            get
            {
                return cpuPkgTemp;
            }
            set
            {
                cpuPkgTemp = value;
                OnPropertyChanged("CPUPkgTemp");
            }
        }

        public int CPUPkgLoad
        {
            get
            {
                return cpuPkgLoad;
            }
            set
            {
                cpuPkgLoad = value;
                OnPropertyChanged("CPUPkgLoad");
            }
        }

        public string CPUName
        {
            get
            {
                return cpuName;
            }
            set
            {
                cpuName = value;
                OnPropertyChanged("CPUName");
            }
        }

        //Core 0
        public string CPUCore0
        {
            get
            {
                return cpuCore0;
            }
            set
            {
                cpuCore0 = value;
                OnPropertyChanged("CPUCore0");
            }
        }

        public string CPUCore0Min
        {
            get
            {
                return cpuCore0Min;
            }
            set
            {
                cpuCore0Min = value;
                OnPropertyChanged("CPUCore0Min");
            }
        }

        public string CPUCore0Max
        {
            get
            {
                return cpuCore0Max;
            }
            set
            {
                cpuCore0Max = value;
                OnPropertyChanged("CPUCore0Max");
            }
        }

        public string CPUCore0Load
        {
            get
            {
                return cpuCore0Load;
            }
            set
            {
                cpuCore0Load = value;
                OnPropertyChanged("CPUCore0Load");
            }
        }

        //Core 1
        public string CPUCore1
        {
            get
            {
                return cpuCore1;
            }
            set
            {
                cpuCore1 = value;
                OnPropertyChanged("CPUCore1");
            }
        }

        public string CPUCore1Min
        {
            get
            {
                return cpuCore1Min;
            }
            set
            {
                cpuCore1Min = value;
                OnPropertyChanged("CPUCore1Min");
            }
        }

        public string CPUCore1Max
        {
            get
            {
                return cpuCore1Max;
            }
            set
            {
                cpuCore1Max = value;
                OnPropertyChanged("CPUCore1Max");
            }
        }

        public string CPUCore1Load
        {
            get
            {
                return cpuCore1Load;
            }
            set
            {
                cpuCore1Load = value;
                OnPropertyChanged("CPUCore1Load");
            }
        }

        //Core 2
        public string CPUCore2
        {
            get
            {
                return cpuCore2;
            }
            set
            {
                cpuCore2 = value;
                OnPropertyChanged("CPUCore2");
            }
        }

        public string CPUCore2Min
        {
            get
            {
                return cpuCore2Min;
            }
            set
            {
                cpuCore2Min = value;
                OnPropertyChanged("CPUCore2Min");
            }
        }

        public string CPUCore2Max
        {
            get
            {
                return cpuCore2Max;
            }
            set
            {
                cpuCore2Max = value;
                OnPropertyChanged("CPUCore2Max");
            }
        }

        public string CPUCore2Load
        {
            get
            {
                return cpuCore2Load;
            }
            set
            {
                cpuCore2Load = value;
                OnPropertyChanged("CPUCore2Load");
            }
        }

        //Core 3
        public string CPUCore3
        {
            get
            {
                return cpuCore3;
            }
            set
            {
                cpuCore3 = value;
                OnPropertyChanged("CPUCore3");
            }
        }

        public string CPUCore3Min
        {
            get
            {
                return cpuCore3Min;
            }
            set
            {
                cpuCore3Min = value;
                OnPropertyChanged("CPUCore3Min");
            }
        }

        public string CPUCore3Max
        {
            get
            {
                return cpuCore3Max;
            }
            set
            {
                cpuCore3Max = value;
                OnPropertyChanged("CPUCore3Max");
            }
        }

        public string CPUCore3Load
        {
            get
            {
                return cpuCore3Load;
            }
            set
            {
                cpuCore3Load = value;
                OnPropertyChanged("CPUCore3Load");
            }
        }
        #endregion

        #region GPU Properties
        public string GPUName
        {
            get
            {
                return gpuName;
            }
            set
            {
                gpuName = value;
                OnPropertyChanged("GPUName");
            }
        }

        public string GPUTemp
        {
            get
            {
                return gpuTemp;
            }
            set
            {
                gpuTemp = value;
                OnPropertyChanged("GPUTemp");
            }
        }

        public string GPUTempMin
        {
            get
            {
                return gpuTempMin;
            }
            set
            {
                gpuTempMin = value;
                OnPropertyChanged("GPUTempMin");
            }
        }

        public string GPUTempMax
        {
            get
            {
                return gpuTempMax;
            }
            set
            {
                gpuTempMax = value;
                OnPropertyChanged("GPUTempMax");
            }
        }

        public string GPULoad
        {
            get
            {
                return gpuLoad;
            }
            set
            {
                gpuLoad = value;
                OnPropertyChanged("GPULoad");
            }
        }

        public string GPUFan
        {
            get
            {
                return gpuFan;
            }
            set
            {
                gpuFan = value;
                OnPropertyChanged("GPUFan");
            }
        }

        public string GPUMem
        {
            get
            {
                return gpuMem;
            }
            set
            {
                gpuMem = value;
                OnPropertyChanged("GPUMem");
            }
        }

        public int GPUPkgTemp
        {
            get
            {
                return gpuPkgTemp;
            }
            set
            {
                gpuPkgTemp = value;
                OnPropertyChanged("GPUPkgTemp");
            }
        }

        public int GPUPkgMem
        {
            get
            {
                return gpuPkgMem;
            }
            set
            {
                gpuPkgMem = value;
                OnPropertyChanged("GPUPkgMem");
            }
        }

        public int GPUPkgFan
        {
            get
            {
                return gpuPkgFan;
            }
            set
            {
                gpuPkgFan = value;
                OnPropertyChanged("GPUPkgFan");
            }
        }

        public int GPUPkgLoad
        {
            get
            {
                return gpuPkgLoad;
            }
            set
            {
                gpuPkgLoad = value;
                OnPropertyChanged("GPUPkgLoad");
            }
        }
        #endregion

        //Constructor***************************************************************************
        public HardwareModel()
        {
            thisComputer = new Computer() { CPUEnabled = true, GPUEnabled = true, FanControllerEnabled = false, MainboardEnabled = false, HDDEnabled = false, RAMEnabled = false };
            thisComputer.Open();
        }

        //Methods*******************************************************************************
        public void UpdateHardware(object source, ElapsedEventArgs e)
        {
            //_CPUModel.CPUTemp = i.ToString();
            //i++;
            string cpuName = "";
            string[] cpuTemp = new string[5];
            string[] cpuTempMin = new string[5];
            string[] cpuTempMax = new string[5];
            string[] cpuLoad = new string[5];
            string[] cpuLoadMax = new string[5];

            string gpuName = "";
            string[] gpuTemp = new string[3];
            string[] gpuTempMin = new string[3];
            string[] gpuTempMax = new string[3];
            string[] gpuLoad = new string[5];
            string gpuFan = "";
            string[] gpuMem = new string[3];

            int i = 0;
            int j = 0;
            int k = 0;
            int l = 0;
            int m = 0;

            foreach (var hardwareItem in thisComputer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.CPU) //Update CPU
                {
                    cpuName = hardwareItem.Name;

                    hardwareItem.Update();
                    foreach (IHardware subHardware in hardwareItem.SubHardware)
                        subHardware.Update();

                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        //Console.WriteLine(sensor.SensorType + " " + sensor.Name + " " + sensor.Value);
                        if (sensor.SensorType == SensorType.Temperature) //CPU Temp
                        {
                            cpuTemp[i] = String.Format("{0}°C", sensor.Value.HasValue ? sensor.Value.Value.ToString() : "no value");
                            cpuTempMin[i] = String.Format("{0}°C", sensor.Value.HasValue ? sensor.Min.Value.ToString() : "no value");
                            cpuTempMax[i] = String.Format("{0}°C", sensor.Value.HasValue ? sensor.Max.Value.ToString() : "no value");
                            i++;
                        }
                        else if (sensor.SensorType == SensorType.Load) //CPU Load
                        {
                            cpuLoad[j] = String.Format("{0}%", sensor.Value.HasValue ? Math.Ceiling(sensor.Value.Value).ToString() : "no value");
                            cpuLoadMax[j] = sensor.Value.HasValue ? Math.Ceiling(sensor.Value.Value).ToString() : "no value";
                            j++;
                        }
                    }
                }
                else if (hardwareItem.HardwareType == HardwareType.GpuNvidia) //Update GPU
                {
                    gpuName = hardwareItem.Name;

                    hardwareItem.Update();
                    foreach (IHardware subHardware in hardwareItem.SubHardware)
                        subHardware.Update();

                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        //Console.WriteLine(sensor.SensorType + " " + sensor.Name + " " + sensor.Value);
                        if (sensor.SensorType == SensorType.Temperature)
                        {
                            gpuTemp[k] = String.Format("{0}°C", sensor.Value.HasValue ? sensor.Value.Value.ToString() : "no value");
                            gpuTempMax[k] = String.Format("{0}°C", sensor.Value.HasValue ? sensor.Max.Value.ToString() : "no value");
                            gpuTempMin[k] = String.Format("{0}°C", sensor.Value.HasValue ? sensor.Min.Value.ToString() : "no value");
                            k++;
                        }
                        else if (sensor.SensorType == SensorType.Load)
                        {
                            gpuLoad[l] = String.Format("{0}%", sensor.Value.HasValue ? sensor.Value.Value.ToString() : "no value");
                            l++;
                        }
                        else if (sensor.SensorType == SensorType.Control)
                        {
                            gpuFan = sensor.Value.ToString();
                        }
                        else if (sensor.SensorType == SensorType.SmallData)
                        {
                            gpuMem[m] = sensor.Value.ToString();
                            m++;
                        }
                    }
                }
            }

            CPUName = cpuName;
            GPUName = gpuName;
            CPUPkgTemp = Int32.Parse(cpuTemp[4].Split('°')[0]);
            CPUPkgLoad = Int32.Parse(cpuLoad[4].Split('%')[0]);
            GPUPkgTemp = Int32.Parse(gpuTemp[0].Split('°')[0]);
            GPUPkgFan = Int32.Parse(gpuFan.Split('%')[0]);
            GPUPkgLoad = Int32.Parse(gpuLoad[0].Split('%')[0]);
            GPUPkgMem = (int)((double)(Math.Round((Convert.ToDecimal(gpuMem[1]) / Convert.ToDecimal(gpuMem[0]) * 100), 1)));

            //Core 0
            CPUCore0 = cpuTemp[0];
            CPUCore0Min = cpuTempMin[0];
            CPUCore0Max = cpuTempMax[0];
            CPUCore0Load = cpuLoad[0];

            //Core 1
            CPUCore1 = cpuTemp[1];
            CPUCore1Min = cpuTempMin[1];
            CPUCore1Max = cpuTempMax[1];
            CPUCore1Load = cpuLoad[1];

            //Core 2
            CPUCore2 = cpuTemp[2];
            CPUCore2Min = cpuTempMin[2];
            CPUCore2Max = cpuTempMax[2];
            CPUCore2Load = cpuLoad[2];

            //Core 3
            CPUCore3 = cpuTemp[3];
            CPUCore3Min = cpuTempMin[3];
            CPUCore3Max = cpuTempMax[3];
            CPUCore3Load = cpuLoad[3];

            //GPU
            GPUTemp = gpuTemp[0];
            GPUTempMin = gpuTempMin[0];
            GPUTempMax = gpuTempMax[0];
            GPULoad = gpuLoad[0];
            GPUFan = gpuFan;
            GPUMem = gpuLoad[1];
        }

        public void UpdateHardware()
        {
            //_CPUModel.CPUTemp = i.ToString();
            //i++;
            string cpuName = "";
            string[] cpuTemp = new string[5];
            string[] cpuTempMin = new string[5];
            string[] cpuTempMax = new string[5];
            string[] cpuLoad = new string[5];
            string[] cpuLoadMax = new string[5];

            string gpuName = "";
            string[] gpuTemp = new string[3];
            string[] gpuTempMin = new string[3];
            string[] gpuTempMax = new string[3];
            string[] gpuLoad = new string[5];
            string gpuFan = "";
            string[] gpuMem = new string[3];

            int i = 0;
            int j = 0;
            int k = 0;
            int l = 0;
            int m = 0;

            foreach (var hardwareItem in thisComputer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.CPU) //Update CPU
                {
                    cpuName = hardwareItem.Name;

                    hardwareItem.Update();
                    foreach (IHardware subHardware in hardwareItem.SubHardware)
                        subHardware.Update();

                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        //Console.WriteLine(sensor.SensorType + " " + sensor.Name + " " + sensor.Value);
                        if (sensor.SensorType == SensorType.Temperature) //CPU Temp
                        {
                            cpuTemp[i] = String.Format("{0}°C", sensor.Value.HasValue ? sensor.Value.Value.ToString() : "no value");
                            cpuTempMin[i] = String.Format("{0}°C", sensor.Value.HasValue ? sensor.Min.Value.ToString() : "no value");
                            cpuTempMax[i] = String.Format("{0}°C", sensor.Value.HasValue ? sensor.Max.Value.ToString() : "no value");
                            i++;
                        }
                        else if (sensor.SensorType == SensorType.Load) //CPU Load
                        {
                            cpuLoad[j] = String.Format("{0}%", sensor.Value.HasValue ? Math.Ceiling(sensor.Value.Value).ToString() : "no value");
                            cpuLoadMax[j] = sensor.Value.HasValue ? Math.Ceiling(sensor.Value.Value).ToString() : "no value";
                            j++;
                        }
                    }
                }
                else if (hardwareItem.HardwareType == HardwareType.GpuNvidia) //Update GPU
                {
                    gpuName = hardwareItem.Name;

                    hardwareItem.Update();
                    foreach (IHardware subHardware in hardwareItem.SubHardware)
                        subHardware.Update();

                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        //Console.WriteLine(sensor.SensorType + " " + sensor.Name + " " + sensor.Value);
                        if (sensor.SensorType == SensorType.Temperature)
                        {
                            gpuTemp[k] = String.Format("{0}°C", sensor.Value.HasValue ? sensor.Value.Value.ToString() : "no value");
                            gpuTempMax[k] = String.Format("{0}°C", sensor.Value.HasValue ? sensor.Max.Value.ToString() : "no value");
                            gpuTempMin[k] = String.Format("{0}°C", sensor.Value.HasValue ? sensor.Min.Value.ToString() : "no value");
                            k++;
                        }
                        else if (sensor.SensorType == SensorType.Load)
                        {
                            gpuLoad[l] = String.Format("{0}%", sensor.Value.HasValue ? sensor.Value.Value.ToString() : "no value");
                            l++;
                        }
                        else if (sensor.SensorType == SensorType.Control)
                        {
                            gpuFan = sensor.Value.ToString();
                        }
                        else if (sensor.SensorType == SensorType.SmallData)
                        {
                            gpuMem[m] = sensor.Value.ToString();
                            m++;
                        }
                    }
                }
            }

            CPUName = cpuName;
            GPUName = gpuName;
            CPUPkgTemp = Int32.Parse(cpuTemp[4].Split('°')[0]);
            CPUPkgLoad = Int32.Parse(cpuLoad[4].Split('%')[0]);
            GPUPkgTemp = Int32.Parse(gpuTemp[0].Split('°')[0]);
            GPUPkgFan = Int32.Parse(gpuFan.Split('%')[0]);
            GPUPkgLoad = Int32.Parse(gpuLoad[0].Split('%')[0]);
            GPUPkgMem = (int)((double)(Math.Round((Convert.ToDecimal(gpuMem[1]) / Convert.ToDecimal(gpuMem[0]) * 100), 1)));

            //Core 0
            CPUCore0 = cpuTemp[0];
            CPUCore0Min = cpuTempMin[0];
            CPUCore0Max = cpuTempMax[0];
            CPUCore0Load = cpuLoad[0];

            //Core 1
            CPUCore1 = cpuTemp[1];
            CPUCore1Min = cpuTempMin[1];
            CPUCore1Max = cpuTempMax[1];
            CPUCore1Load = cpuLoad[1];

            //Core 2
            CPUCore2 = cpuTemp[2];
            CPUCore2Min = cpuTempMin[2];
            CPUCore2Max = cpuTempMax[2];
            CPUCore2Load = cpuLoad[2];

            //Core 3
            CPUCore3 = cpuTemp[3];
            CPUCore3Min = cpuTempMin[3];
            CPUCore3Max = cpuTempMax[3];
            CPUCore3Load = cpuLoad[3];

            //GPU
            GPUTemp = gpuTemp[0];
            GPUTempMin = gpuTempMin[0];
            GPUTempMax = gpuTempMax[0];
            GPULoad = gpuLoad[0];
            GPUFan = gpuFan;
            GPUMem = gpuLoad[1];
        }
    }
}
