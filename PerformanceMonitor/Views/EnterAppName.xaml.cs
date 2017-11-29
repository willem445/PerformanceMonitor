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
using System.Windows.Shapes;

namespace PerformanceMonitor
{
    /// <summary>
    /// Interaction logic for EnterAppName.xaml
    /// </summary>
    public partial class EnterAppName : Window
    {
        public string _displayName { get; set; } = "";

        public EnterAppName()
        {
            InitializeComponent();
            this.Title = "Enter Application Name";
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void okayButton_Click(object sender, RoutedEventArgs e)
        {
            _displayName = appNameTextBox.Text;
            this.DialogResult = true;
        }
    }
}
