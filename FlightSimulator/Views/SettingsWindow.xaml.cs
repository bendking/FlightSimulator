using FlightSimulator.Model;
using FlightSimulator.ViewModels.Windows;
using System.Windows;
using System.Windows.Controls;

namespace FlightSimulator.Views
{
    /// <summary>
    /// This window is used to alter the Flight Server connection details.
    /// </summary>
    public partial class SettingsWindow : Window
    {
        SettingsWindowViewModel viewModel;

        public SettingsWindow()
        {
            // Initialize component
            InitializeComponent();
            // Initialize model & view model
            viewModel = new SettingsWindowViewModel(new ApplicationSettingsModel());

            // Set default settings values
            ServerIP.SetValue(TextBox.TextProperty, viewModel.FlightServerIP);
            ServerPort.SetValue(TextBox.TextProperty, viewModel.FlightInfoPort.ToString());
            CommandPort.SetValue(TextBox.TextProperty, viewModel.FlightCommandPort.ToString());
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            // Alter the settings values as written
            viewModel.FlightServerIP = (string) ServerIP.GetValue(TextBox.TextProperty);
            viewModel.FlightInfoPort = int.Parse((string) ServerPort.GetValue(TextBox.TextProperty));
            viewModel.FlightCommandPort = int.Parse((string) CommandPort.GetValue(TextBox.TextProperty));
            // Save and close
            viewModel.SaveSettings();
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Close without changing the values
            this.Close();
        }
    }
}
