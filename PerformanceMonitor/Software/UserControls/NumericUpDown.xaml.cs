using System;
using System.Media;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PerformanceMonitor
{
    /// <summary>
    /// Interaction logic for NumericUpDown.xaml
    /// </summary>
    public partial class NumericUpDown : UserControl
    {
        private readonly Regex _numMatch;

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(int), typeof(NumericUpDown), new UIPropertyMetadata(100));

        public int Maximum
        {
            get { return (int)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(int),
            typeof(NumericUpDown), new UIPropertyMetadata(0));

        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(NumericUpDown),
            new PropertyMetadata(0, new PropertyChangedCallback(OnSomeValuePropertyChanged)));

        public int Value
        {
            get
            {
                return (int)GetValue(ValueProperty);
            }
            set
            {
                updwnTextBox.Text = value.ToString();
                SetValue(ValueProperty, value);
            }
        }

        public NumericUpDown()
        {
            InitializeComponent();

            _numMatch = new Regex(@"^-?\d+$");
            Maximum = int.MaxValue;
            Minimum = 0;
            updwnTextBox.Text = "0";
        }

        private void ResetText(TextBox tb)
        {
            tb.Text = 0 < Minimum ? Minimum.ToString() : "0";

            tb.SelectAll();
        }

        private static void OnSomeValuePropertyChanged(
            DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            NumericUpDown numericBox = target as NumericUpDown;
            numericBox.updwnTextBox.Text = e.NewValue.ToString();
        }

        private void updwnTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = (TextBox)sender;
            if (!_numMatch.IsMatch(tb.Text)) ResetText(tb);
            Value = Convert.ToInt32(tb.Text);
            if (Value < Minimum) Value = Minimum;
            if (Value > Maximum) Value = Maximum;
            RaiseEvent(new RoutedEventArgs(ValueChangedEvent));
        }

        private static readonly RoutedEvent ValueChangedEvent =
        EventManager.RegisterRoutedEvent("ValueChanged", RoutingStrategy.Bubble,
        typeof(RoutedEventHandler), typeof(NumericUpDown));

        public event RoutedEventHandler ValueChanged
        {
            add { AddHandler(ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }

        private void updwnTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var tb = (TextBox)sender;
            var text = tb.Text.Insert(tb.CaretIndex, e.Text);

            e.Handled = !_numMatch.IsMatch(text);
        }

        private static readonly RoutedEvent IncreaseClickedEvent =
            EventManager.RegisterRoutedEvent("IncreaseClicked", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(NumericUpDown));


        public event RoutedEventHandler IncreaseClicked
        {
            add
            {
                AddHandler(IncreaseClickedEvent, value);
            }
            remove
            {
                RemoveHandler(IncreaseClickedEvent, value);
            }
        }

        private static readonly RoutedEvent DecreaseClickedEvent =
            EventManager.RegisterRoutedEvent("DecreaseClicked", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(NumericUpDown));

        public event RoutedEventHandler DecreaseClicked
        {
            add
            {
                AddHandler(DecreaseClickedEvent, value);
            }
            remove
            {
                RemoveHandler(DecreaseClickedEvent, value);
            }
        }

        private void updwnTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.IsDown && e.Key == Key.Up && Value < Maximum)
            {
                Value++;
                RaiseEvent(new RoutedEventArgs(IncreaseClickedEvent));
            }
            else if (e.IsDown && e.Key == Key.Down && Value > Minimum)
            {
                Value--;
                RaiseEvent(new RoutedEventArgs(DecreaseClickedEvent));
            }
        }

        private void Increase_Click(object sender, RoutedEventArgs e)
        {
            if (Value < Maximum)
            {
                Value++;
                RaiseEvent(new RoutedEventArgs(IncreaseClickedEvent));
            }
        }

        private void Decrease_Click(object sender, RoutedEventArgs e)
        {
            if (Value > Minimum)
            {
                Value--;
                RaiseEvent(new RoutedEventArgs(DecreaseClickedEvent));
            }
        }
    }
}
