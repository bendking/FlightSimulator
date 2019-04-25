using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    public class FlightBoardModel : BaseNotify
    {
        private InfoServer server;
        private CommandClient client;
        private bool stop = false;

        public double Lat
        {
            get; private set;
        }

        public double Lon
        {
            get; private set;
        }

        public void HostAndConnect()
        {
            // Host for FlightGear
            Thread thread = new Thread(delegate ()
            {
                // Host for FlightGear
                Host();
                // Connect to FlightGear
                Connect();
            });

            // Sleep for 30 seconds
            // System.Threading.Thread.Sleep(30000);

            // Host & Connect
            thread.Start();
        }
        public void Host()
        {
            // Create new server and host
            server = new InfoServer(Properties.Settings.Default.FlightInfoPort);
            server.Host();
            // Open thread that will receive values concurrently
            server.ReceiveValues();
            // Parse values
            ParseValues();
        }

        public void Connect()
        {
            // Create a new client and connect
            client = CommandClient.GetInstance(Properties.Settings.Default.FlightServerIP, Properties.Settings.Default.FlightCommandPort);
            client.Connect();
        }

        // NOTE - This method is somewhat busy waiting.
        // A better implementation would be to use the observer pattern (observe the server).
        public void ParseValues()
        {
            // Debug
            System.Diagnostics.Debug.WriteLine("Parsing values...");
            Thread thread = new Thread(() => {
                // Get information received
                Dictionary<string, double> info = server.Info;

                // Update values
                double lon, lat;
                while (!stop)
                {
                    // Update latitude
                    if (info.ContainsKey("/position/latitude-deg"))
                    {
                        lat = info["/position/latitude-deg"];
                        // DEBUG
                        System.Diagnostics.Debug.WriteLine("Lat received: " + lat);
                        if (Lat != lat)
                        {
                            // DEBUG
                            System.Diagnostics.Debug.WriteLine("Lat was: " + Lat + ", Lat is: " + lat);
                            Lat = lat;
                            NotifyPropertyChanged("Lat");
                        }
                    }

                    // Update longtitude
                    if (info.ContainsKey("/position/longitude-deg"))
                    {
                        lon = info["/position/longitude-deg"];
                        // DEBUG
                        System.Diagnostics.Debug.WriteLine("Lon received: " + lon);
                        if (Lon != lon)
                        {
                            // DEBUG
                            System.Diagnostics.Debug.WriteLine("Lon was: " + Lon + ", Lon is: " + lon);
                            Lon = lon;
                            NotifyPropertyChanged("Lon");
                        }
                    }
                    
                    // Update every two seconds
                    System.Threading.Thread.Sleep(2000);
                }
            });
            // Start thread
            thread.Start();
        }

        public void StopParsing()
        {
            // Stop thread
            stop = true;
        }
    }
}
