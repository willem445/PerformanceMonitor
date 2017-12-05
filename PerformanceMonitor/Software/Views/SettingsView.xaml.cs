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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PerformanceMonitor
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        SettingsViewModel _SettingsViewModel;
        public SettingsView()
        {
            InitializeComponent();

            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                return;

            init();
        }

        private void init()
        {
            //Assign datacontext for view
            _SettingsViewModel = new SettingsViewModel();
            DataContext = _SettingsViewModel;

            //Subscribe to settings provider to initialize settings from file
            _SettingsViewModel.Subscribe(_SettingsProvider.SettingsProvider);
        }

        private void settingsButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            pnlRightMenu.BeginStoryboard((Storyboard)this.Resources["sbShowRightMenu"]);

            //Unsubscibe from SettingsProvider since data from file is no longer needed
            _SettingsViewModel.Unsubscribe();
        }

        private void settingsButton_MouseEnter(object sender, MouseEventArgs e)
        {
            settingsButton.Source = new BitmapImage(new Uri(@"/Resources/settingsIconSelected.png", UriKind.RelativeOrAbsolute));
        }

        private void settingsButton_MouseLeave(object sender, MouseEventArgs e)
        {
            settingsButton.Source = new BitmapImage(new Uri(@"/Resources/settingsIcon.png", UriKind.RelativeOrAbsolute));
        }

        private void settingsMenuCloseButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            pnlRightMenu.BeginStoryboard((Storyboard)this.Resources["sbHideRightMenu"]);
        }

        private void button_MouseLeave(object sender, MouseEventArgs e)
        {
            var item = (Label)sender;
            item.FontWeight = FontWeights.Normal;
        }

        private void button_MouseEnter(object sender, MouseEventArgs e)
        {
            var item = (Label)sender;
            item.FontWeight = FontWeights.Bold;
        }

    }
}
