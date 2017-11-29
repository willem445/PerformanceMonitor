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
    /// Interaction logic for CPUView.xaml
    /// </summary>
    public partial class HardwareView : UserControl
    {
        public HardwareView()
        {
            InitializeComponent();

            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                return;

            init();
        }

        private void init()
        {
            //Assign datacontext for view
            HardwareViewModel _HardwareViewModel = new HardwareViewModel();
            DataContext = _HardwareViewModel;

            //Subscribe to settings provider
            _HardwareViewModel.Subscribe(_SettingsProvider.SettingsProvider);
        }
    }
}
