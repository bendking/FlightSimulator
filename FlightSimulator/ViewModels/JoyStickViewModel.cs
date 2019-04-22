using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.EventArgs;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    class JoyStickViewModel
    {
        public void Throttle(double d)
        {
            CommandClient.GetInstance().Send("set /controls/flight/throttle " + d);

        }
        public void Rudder(double d)
        {
            CommandClient.GetInstance().Send("set /controls/flight/rudder " + d);

        }
        public void Aileron(double d)
        {
            CommandClient.GetInstance().Send("set /controls/flight/aileron " + d);
        }
        public void Elevator(double d)
        {
            CommandClient.GetInstance().Send("set /controls/flight/elevator " + d);
        }

        public void Moved(object sender, VirtualJoystickEventArgs args)
        {
            Aileron(args.Aileron / 124.0);
            Elevator(args.Elevator / 124.0);
        }
        public void Relesed(object sender)
        {
    
            for (int i = 0; i < 30; i++)
            {
                Aileron(0);
                Elevator(0);
            }
        }

    }
}
