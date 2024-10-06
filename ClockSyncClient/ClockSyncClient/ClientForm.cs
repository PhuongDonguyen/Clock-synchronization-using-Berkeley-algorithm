using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockSyncClient
{
    public partial class ClientForm : Form
    {
        private UdpClient udpClient;
        private string coordinatorIP = "localhost";
        private int coordinatorPort = 8000;
        public ClientForm()
        {
            InitializeComponent();
            // Set up UDP Client
            udpClient = new UdpClient();
            LogMessage("Client is ready.");
            Console.WriteLine("At this line");

            // Automatically send time when the form loads
            Thread clientThread = new Thread(SendClientTime);
            clientThread.Start();
        }

        // Method to send client time to coordinator
        private void SendClientTime()
        {
            try
            {
                // Get client's local time
                DateTime clientTime = DateTime.Now;
                string clientTimeString = clientTime.ToString("HH:mm:ss");

                // Send client time to the coordinator
                SendMessage(clientTimeString, coordinatorIP, coordinatorPort);
                LogMessage($"Sent time to coordinator: {clientTimeString}");

                // Start listening for a response
                ReceiveMessage();
            }
            catch (Exception ex)
            {
                LogMessage($"Error: {ex.Message}");
            }
        }

        // Method to send a message to the coordinator
        private void SendMessage(string message, string ipAddress, int port)
        {
            byte[] data = Encoding.ASCII.GetBytes(message); // Convert message to bytes
            udpClient.Send(data, data.Length, ipAddress, port); // Send data to the coordinator
        }

        // Method to receive a message from the coordinator
        private void ReceiveMessage()
        {
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0); // Listening for coordinator response

            LogMessage("Waiting for synchronization response from coordinator...");
            byte[] data = udpClient.Receive(ref remoteEndPoint); // Wait for response

            string response = Encoding.ASCII.GetString(data); // Convert received data to string
            LogMessage($"Received message from coordinator: {response}");
        }

        // Method to log messages to the TextBox on the client UI
        private void LogMessage(string message)
        {
            if (txtClientLog.InvokeRequired) // Check if the call is from a different thread
            {
                txtClientLog.Invoke(new Action(() => LogMessage(message)));
            }
            else
            {
                txtClientLog.AppendText(message + Environment.NewLine); // Append text if on the UI thread
            }
        }
    }

}
