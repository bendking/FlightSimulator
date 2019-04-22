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

        public void Moved(object sender, VirtualJoystickEventArgs args)
        {
            CommandClient.GetInstance().Aileron(args.Aileron / 124.0);
            CommandClient.GetInstance().Elevator(args.Elevator / 124.0);
        }
        public void Relesed(object sender)
        {
    
            for (int i = 0; i < 30; i++)
            {
                CommandClient.GetInstance().Aileron(0);
                CommandClient.GetInstance().Elevator(0);
            }
        }

    }
}
