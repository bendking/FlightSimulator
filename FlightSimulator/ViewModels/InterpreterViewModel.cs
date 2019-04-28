using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FlightSimulator.Views;
using System.Windows.Threading;
using FlightSimulator.Model;
using System.Windows.Input;

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

        private string text;
        public string Text
        {
            set
            {
                text = value;
                IsSending = "Red";
                NotifyPropertyChanged("Text");
            }
            get
            {
                return text;
            }
        }

        private ICommand _okCommand;
        public ICommand OkCommand
        {
            get
            {
                return _okCommand ?? (_okCommand = new CommandHandler(() => OnOk()));
            }
        }

        public void OnOk()
        {
            sendCommands(Text);
            IsSending = "White";
        }


        private ICommand _clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand = new CommandHandler(() => OnClear()));
            }
        }

        public void OnClear()
        {
            Text = "";
            IsSending = "White";
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
                    if (line.Equals(""))
                        continue;

                   // for (int i = 0; i < 30; i++)
                    //{
                        CommandClient.GetInstance().Send(line);
                    //}
                    System.Threading.Thread.Sleep(2000);

                }

                //view.changeTextBoxColorFromOtherThread("white");

            });
            t.Start();
        }
    }
}
