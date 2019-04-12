using FlightSimulator.Model.Interface;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace FlightSimulator.Model
{
    class CommandClient : IClient
    {
        private string ip;
        private int port;
        private IPEndPoint ep;
        private TcpClient client; 

        public CommandClient(string _ip, int _port)
        {
            FlightServerIP = _ip;
            FlightCommandPort = _port;
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
            // Create endpoint & client, then connect
            ep = new IPEndPoint(IPAddress.Parse(FlightServerIP), FlightCommandPort);
            client = new TcpClient();
            // DEBUG
            System.Diagnostics.Debug.WriteLine("Connecting...");
            client.Connect(ep);
            // DEBUG
            System.Diagnostics.Debug.WriteLine("Client connected.");
        }

        public void Send(string msg)
        {
            using (NetworkStream stream = client.GetStream())
            using (StreamWriter writer = new StreamWriter(stream))
            {
                // Send data to server
                writer.WriteLine(msg);
            }
        }

        public void Close()
        {
            // Close connection
            client.Close();
        }
    }
}
