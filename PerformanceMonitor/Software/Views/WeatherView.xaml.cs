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

namespace PerformanceMonitor
{
    /// <summary>
    /// Interaction logic for WeatherView.xaml
    /// </summary>
    public partial class WeatherView : UserControl
    {
        public WeatherView()
        {
            InitializeComponent();

            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                return;

            init();
        }

        private void init()
        {
            //Assign datacontext for view
            WeatherViewModel _WeatherViewModel = new WeatherViewModel();
            DataContext = _WeatherViewModel;

            //Subscribe to settings provider
            _WeatherViewModel.Subscribe(_SettingsProvider.SettingsProvider);
        }
    }
}
