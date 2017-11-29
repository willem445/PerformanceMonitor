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
    /// Interaction logic for ApplicationShortcutView.xaml
    /// </summary>
    public partial class ApplicationShortcutView : UserControl
    {
        public ApplicationShortcutView()
        {
            InitializeComponent();

            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                return;

            init();
        }

        private void init()
        {
            //Assign datacontext for view
            AppShortcutViewModel _AppShortcutViewModel = new AppShortcutViewModel();
            DataContext = _AppShortcutViewModel;

            //Subscribe to settings provider
            _AppShortcutViewModel.Subscribe(_SettingsProvider.SettingsProvider);
        }
    }
}
