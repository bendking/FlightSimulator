namespace FlightSimulator.Model.Interface
{
    interface IClient
    {
        void Connect();
        void Send(string msg);
        void Close();
    }
}
