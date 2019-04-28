using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.EventArgs;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    class JoyStickViewModel : BaseNotify
    {
        private JoystickModel model;
        public JoyStickViewModel()
        {
            model = new JoystickModel();
        }

        private string throttle;
        private string rudder;
        private string aileron;
        private string elevator;

        public string VM_Throttle
        {
            get
            {
                return throttle;
            }
            set
            {
                throttle = value;
                model.M_Throttle = throttle;
                // System.Diagnostics.Debug.WriteLine("worked");
            }

        }
        public string VM_Rudder
        {
            get
            {
                return rudder;
            }
            set
            {
                rudder = value;
                model.M_Rudder = rudder;
                // System.Diagnostics.Debug.WriteLine("worked");
            }

        }
        public string VM_Aileron
        {
            get
            {
                return aileron;
            }
            set
            {
                aileron = value;
                model.M_Aileron = aileron;
                // System.Diagnostics.Debug.WriteLine("worked");
            }

        }
        public string VM_Elevator
        {
            get
            {
                return elevator;
            }
            set
            {
                elevator = value;
                model.M_Elevator = elevator;
                // System.Diagnostics.Debug.WriteLine("worked");
            }

        }

        /* DEPRECATED
        public void Moved(object sender, VirtualJoystickEventArgs args)
        {
            aileron = "" + args.Aileron / 124.0;
            model.M_Aileron = aileron;
            elevator = "" + args.Elevator / 124.0;
            model.M_Elevator = elevator;
        }
        public void Relesed(object sender)
        {
    
           for (int i = 0; i < 30; i++)
           {
                aileron = "0";
                model.M_Aileron = aileron;
                elevator = "0";
                model.M_Elevator = elevator;
            }
        }
        */

    }
}
