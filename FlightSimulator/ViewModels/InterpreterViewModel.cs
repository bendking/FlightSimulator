using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FlightSimulator.Views;
using System.Windows.Threading;
using FlightSimulator.Model;
namespace FlightSimulator.ViewModels
{
    class InterpreterViewModel : BaseNotify
    {
        private CommandInterpreter view;
        private string color = "White";
        public string IsSending
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                NotifyPropertyChanged("IsSending");
            }
        }
        public InterpreterViewModel(CommandInterpreter _view)
        {
            view = _view;
        }
        public void sendCommands(string s)
        {
            
            string[] lines = s.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            
            Thread t = new Thread(delegate()
            {
             
                //view.changeTextBoxColorFromOtherThread("red");
                foreach(string line in lines)
                {

                    CommandClient.GetInstance().Send(line);
                    System.Threading.Thread.Sleep(2000);

                }

                //view.changeTextBoxColorFromOtherThread("white");

            });
            t.Start();
        }
    }
}
