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
using System.Windows.Threading;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for CommandInterpreter.xaml
    /// </summary>
    public partial class CommandInterpreter : UserControl
    {
        InterpreterViewModel viewModel;

        public CommandInterpreter()
        {
            InitializeComponent();
            viewModel = new InterpreterViewModel(this);
            this.DataContext = viewModel;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            // Execute all commands
            viewModel.sendCommands(commandBox.Text);
            viewModel.IsSending = "White";
        }

        /*
        public void changeTextBoxColorFromOtherThread(string color)
        {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate ()
            {

            if (color.CompareTo("red") == 0)
            {
                commandBox.Background = Brushes.Red;
            } else if (color.CompareTo("white") == 0)
            {
                commandBox.Background = Brushes.White;
            }

            }));
        }
        */

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            // Reset value of text box
            commandBox.SetValue(TextBox.TextProperty, "");
            viewModel.IsSending = "White";

        }

        private void CommandBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.IsSending = "Red";
        }
    }
}
