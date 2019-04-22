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

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for CommandInterpreter.xaml
    /// </summary>
    public partial class CommandInterpreter : UserControl
    {
        public CommandInterpreter()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            // TODO (OFEC): Execute all commands
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            // Reset value of text box
            commandBox.SetValue(TextBox.TextProperty, "");
        }

        private void CommandBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
