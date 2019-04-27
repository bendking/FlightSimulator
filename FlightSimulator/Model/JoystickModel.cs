using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class JoystickModel
    {
        private string throttle;
        private string aileron;
        private string elevator;
        private string rudder;

        public string M_Throttle
        {
            get
            {
                return throttle;
            }
            set
            {
                throttle = value;
                Throttle();
            }
        }
        public string M_Aileron
        {
            get
            {
                return aileron;
            }
            set
            {
                aileron = value;
                Aileron();
            }
        }
        public string M_Elevator
        {
            get
            {
                return elevator;
            }
            set
            {
                elevator = value;
                Elevator();
            }
        }
        public string M_Rudder
        {
            get
            {
                return rudder;
            }
            set
            {
                rudder = value;
                Rudder();
            }
        }




        public void Throttle()
        {
            CommandClient.GetInstance().Send("set /controls/engines/current-engine/throttle " + throttle);

        }
        public void Rudder()
        {
            CommandClient.GetInstance().Send("set /controls/flight/rudder " + rudder);

        }
        public void Aileron()
        {
            CommandClient.GetInstance().Send("set /controls/flight/aileron " + Double.Parse(aileron)/124.0);
        }
        public void Elevator()
        {
            CommandClient.GetInstance().Send("set /controls/flight/elevator " + Double.Parse(elevator)/124.0);
        }
    }
}
