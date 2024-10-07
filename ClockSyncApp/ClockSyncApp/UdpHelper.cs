using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ClockSyncApp
{
    internal class UdpHelper
    {
        private UdpClient udpClient;
        private int port;

        public UdpHelper(int port)
        {
            this.port = port;
            udpClient = new UdpClient(port); // Bind the UdpClient to the specified port
        }

        public void Send(string message, string ipAddress, int remotePort)
        {
            byte[] data = Encoding.ASCII.GetBytes(message); // Convert message to bytes
            udpClient.Send(data, data.Length, ipAddress, remotePort); // Send data over UDP
        }

        public string Receive(ref IPEndPoint clientEndpoint)
        {
            //IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port); // Listening on any IP
            //byte[] data = udpClient.Receive(ref endPoint); // Receive data
            //return Encoding.ASCII.GetString(data); // Convert data to string
            byte[] data = udpClient.Receive(ref clientEndpoint); // Receive data along with sender's info
            return Encoding.UTF8.GetString(data); // Convert bytes to string
        }
    }
}
