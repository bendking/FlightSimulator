using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using FlightSimulator.Model;
using FlightSimulator.ViewModels;

namespace FlightSimulator.Views
{
    public partial class FlightBoard : UserControl
    {
        private FlightBoardViewModel viewModel;
        ObservableDataSource<Point> planeLocations = null;

        public FlightBoard()
        {
            viewModel = new FlightBoardViewModel(new FlightBoardModel());
            // Add view as observer for property changes
            viewModel.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
            { VM_PropertyChanged(sender, e); };
            // Start things up
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialize planeLocations collection
            planeLocations = new ObservableDataSource<Point>();
            // Set identity mapping of point in collection to point on plot
            planeLocations.SetXYMapping(p => p);
            // Add line graph to plotter
            plotter.AddLineGraph(planeLocations, 3, "Route");
        }

        private void VM_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // OLD - if(e.PropertyName.Equals("Lat") || e.PropertyName.Equals("Lon"))
            if(e.PropertyName.Equals("Lon"))
            {
                Point p = new Point(viewModel.Lat, viewModel.Lon);
                planeLocations.AppendAsync(Dispatcher, p);
            }
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settings = new SettingsWindow();
            settings.Show();
        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            // Start up server and client
            viewModel.HostAndConnect();
        }
    }

}

