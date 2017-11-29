using System.ComponentModel;

namespace PerformanceMonitor
{
    public class INotifyPropertyChangedBase : INotifyPropertyChanged
    {
        //INotifyPropertyChanged****************************************************************
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
