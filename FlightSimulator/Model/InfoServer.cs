using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class InfoServer : IServer 
    {
        private int port;
        private IPEndPoint ep;
        private TcpListener listener;
        private TcpClient client;
        private bool stop = false;

        private Dictionary<string, double> info;
        private string[] values = {"/position/longitude-deg",
                                   "/position/latitude-deg",
                                   "/instrumentation/airspeed-indicator/indicated-speed-kt",
                                   "/instrumentation/altimeter/indicated-altitude-ft",
                                   "/instrumentation/altimeter/pressure-alt-ft",
                                   "/instrumentation/attitude-indicator/indicated-pitch-deg",
                                   "/instrumentation/attitude-indicator/indicated-roll-deg",
                                   "/instrumentation/attitude-indicator/internal-pitch-deg",
                                   "/instrumentation/attitude-indicator/internal-roll-deg",
                                   "/instrumentation/encoder/indicated-altitude-ft",
                                   "/instrumentation/encoder/pressure-alt-ft",
                                   "/instrumentation/gps/indicated-altitude-ft",
                                   "/instrumentation/gps/indicated-ground-speed-kt",
                                   "/instrumentation/gps/indicated-vertical-speed",
                                   "/instrumentation/heading-indicator/indicated-heading-deg",
                                   "/instrumentation/magnetic-compass/indicated-heading-deg",
                                   "/instrumentation/slip-skid-ball/indicated-slip-skid",
                                   "/instrumentation/turn-indicator/indicated-turn-rate",
                                   "/instrumentation/vertical-speed-indicator/indicated-speed-fpm",
                                   "/controls/flight/aileron",
                                   "/controls/flight/elevator",
                                   "/controls/flight/rudder",
                                   "/controls/flight/flaps",
                                   "/controls/engines/engine/throttle",
                                   "/engines/engine/rpm"};

        public Dictionary<string, double> Info => info;

        public InfoServer(int _port)
        {
            port = _port;
            ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            listener = new TcpListener(ep);
            info = new Dictionary<string, double>();
        }

        public void Host()
        {
            // Listen and accept a signle client           
            // DEBUG
            System.Diagnostics.Debug.WriteLine("Accepting client...");
            listener.Start();
            client = listener.AcceptTcpClient();
            // DEBUG
            System.Diagnostics.Debug.WriteLine("Client accepted.");
        }

        public void ReceiveValues()
        {
            // DEBUG
            System.Diagnostics.Debug.WriteLine("Receiving values...");
            // Create a thread to continously parse values from FlightGear
            Thread thread = new Thread(() => {
            // Array of values to be received
            string line;
            string[] input;
            // Start receiving
            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream)) {
                    while (!stop)
                    {
                        try
                        {
                            // Read line and put into array
                            line = reader.ReadLine();
                            input = line.Split(',');
                            // DEBUG
                            System.Diagnostics.Debug.WriteLine(line);
                            // Input values into dictionary
                            for (int i = 0; i < input.Length; ++i)
                            {
                                // Parse value to float and cast to int then put in appropriate key
                                info[values[i]] = float.Parse(input[i]);
                            }
                        }
                        catch (Exception e)
                        {
                            // Write error to console
                            System.Diagnostics.Debug.WriteLine(e.ToString());
                            break;
                        }
                    }
                }
            });
            // Start thread
            thread.Start();
        }

        public void Stop()
        {
            // Stop receiving values
            stop = true;
        }

        public void Close()
        {
            // Close connection with client
            client.Close();
        }
    }
}
