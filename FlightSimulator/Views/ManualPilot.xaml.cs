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
using FlightSimulator.ViewModels;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for ManualPilot.xaml
    /// </summary>
    public partial class ManualPilot : UserControl
    {
        JoyStickViewModel viewModel;
        public ManualPilot()
        {
            InitializeComponent();
            viewModel = new JoyStickViewModel();
            this.DataContext = viewModel;
        }

        /*
        private void LeftSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            viewModel.Throttle(e.NewValue);
        }

        private void ButtomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            viewModel.Rudder(e.NewValue);
        }
        */
    }
}
