

namespace PerformanceMonitor
{
    public class WeatherModel : INotifyPropertyChangedBase
    {
        //Fields*******************************************************************************
        private string place = "";
        private string obsTime = "";
        private string weather = "";
        private string temperature = "";
        private string humidity = "";
        private string pressure = "";
        private string windSpeed = "";
        private string dewpoint = "";
        private string visibility = "";
        private string latitude = "";
        private string longitude = "";
        private string headIndex = "";
        private string precipitation = "";

        //Constructor***************************************************************************
        public WeatherModel()
        {

        }

        //Properties*****************************************************************************
        public string Place
        {
            get
            {
                return place;
            }
            set
            {
                place = value;
                OnPropertyChanged("Place");
            }
        }
        public string ObsTime
        {
            get
            {
                return obsTime;
            }
            set
            {
                obsTime = value;
                OnPropertyChanged("ObsTime");
            }
        }
        public string Weather
        {
            get
            {
                return weather;
            }
            set
            {
                weather = value;
                OnPropertyChanged("Weather");
            }
        }
        public string Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                temperature = value;
                OnPropertyChanged("Temperature");
            }
        }
        public string Humidity
        {
            get
            {
                return humidity;
            }
            set
            {
                humidity = value;
                OnPropertyChanged("Humidity");
            }
        }
        public string WindSpeed
        {
            get
            {
                return windSpeed;
            }
            set
            {
                windSpeed = value;
                OnPropertyChanged("Windspeed");
            }
        }
        public string Pressure
        {
            get
            {
                return pressure;
            }
            set
            {
                pressure = value;
                OnPropertyChanged("Pressure");
            }
        }
        public string Dewpoint
        {
            get
            {
                return dewpoint;
            }
            set
            {
                dewpoint = value;
                OnPropertyChanged("Dewpoint");
            }
        }
        public string Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                visibility = value;
                OnPropertyChanged("Visibility");
            }
        }
        public string Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                latitude = value;
                OnPropertyChanged("Latitude");
            }
        }
        public string Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                longitude = value;
                OnPropertyChanged("Longitude");
            }
        }
        public string HeatIndex
        {
            get
            {
                return headIndex;
            }
            set
            {
                headIndex = value;
                OnPropertyChanged("HeatIndex");
            }
        }
        public string Precipitation
        {
            get
            {
                return precipitation;
            }
            set
            {
                precipitation = value;
                OnPropertyChanged("Precipitation");
            }
        }



 
    }
}
