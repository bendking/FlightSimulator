using FlightSimulator.Model.Interface;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace FlightSimulator.Model
{
    class CommandClient : IClient
    {
        private static CommandClient commandClientSingleton = null;
        private string ip;
        private int port;
        private IPEndPoint ep;
        private TcpClient client;
        private bool connected = false;
        private StreamWriter writer = null;

        public static CommandClient GetInstance(string _ip, int _port)
        {
            if(commandClientSingleton == null)
            {
                commandClientSingleton = new CommandClient(_ip, _port);
            }
            else if (commandClientSingleton.ParametersChanged(_ip, _port))
            {
                commandClientSingleton.Close();
                commandClientSingleton = new CommandClient(_ip, _port);
            }
            return commandClientSingleton;

        }
        public static CommandClient GetInstance()
        {
            if (commandClientSingleton == null)
            {
                commandClientSingleton = new CommandClient();
            }
          
            return commandClientSingleton;
        }
        public bool ParametersChanged(string _ip, int _port)
        {
            if(ip != _ip || port != _port)
            {
                return true;
            }
            return false;
        }
        public CommandClient(string _ip, int _port)
        {
            FlightServerIP = _ip;
            FlightCommandPort = _port;
        }
        public CommandClient()
        {

        }

        public string FlightServerIP
        {
            get { return ip; }
            set { ip = value; }
        }

        public int FlightCommandPort
        {
            get { return port; }
            set { port = value; }
        }

        public void Connect()
        {
            if (connected) return;
            connected = true;
       
            // Create endpoint & client, then connect
            ep = new IPEndPoint(IPAddress.Parse(FlightServerIP), FlightCommandPort);
            client = new TcpClient();
            // DEBUG
            System.Diagnostics.Debug.WriteLine("Connecting...");
            client.Connect(ep);
            // DEBUG
            System.Diagnostics.Debug.WriteLine("Client connected.");
            writer = new StreamWriter(client.GetStream());
        }

      

        public void Send(string msg)
        {
            if (!connected) return;
            // DEBUG
            System.Diagnostics.Debug.WriteLine("Sending message: " + msg);
            // Send data to server
            writer.WriteLine(msg+"\r\n");

            /* DEPRECATED
            NetworkStream stream = client.GetStream();
            using (NetworkStream stream = client.GetStream())
            using (StreamWriter writer = new StreamWriter(stream))
            {
                // Send data to server
                writer.WriteLine(msg+"\r\n");
            }
            */
        }

        public void Close()
        {
            if (!connected) return;
            connected = false;
            // Close connection
            client.Close();
        }
    }
}
