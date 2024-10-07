using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ClockSyncClient
{
    public partial class ClientForm : Form
    {
        private UdpClient udpClient;
        private string coordinatorIP = "192.168.1.103";
        private int coordinatorPort = 8000;

        public ClientForm()
        {
            InitializeComponent();
            udpClient = new UdpClient();
            LogMessage("Client is ready.");

            Thread clientThread = new Thread(SendClientTime);
            clientThread.Start();
        }

        private void SendClientTime()
        {
            try
            {
                DateTime clientTime = DateTime.Now;
                string clientTimeString = clientTime.ToString("HH:mm:ss");

                SendMessage(clientTimeString, coordinatorIP, coordinatorPort);
                LogMessage($"Sent time to coordinator: {clientTimeString}");

                ReceiveMessage();
            }
            catch (Exception ex)
            {
                LogMessage($"Error: {ex.Message}");
            }
        }

        private void SendMessage(string message, string ipAddress, int port)
        {
            byte[] data = Encoding.ASCII.GetBytes(message);
            udpClient.Send(data, data.Length, ipAddress, port);
        }

        private void ReceiveMessage()
        {
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            LogMessage("Waiting for time adjustment from coordinator...");

            udpClient.Client.ReceiveTimeout = 5000;

            while (true)
            {
                try
                {
                    byte[] data = udpClient.Receive(ref remoteEndPoint);
                    string response = Encoding.ASCII.GetString(data);
                    double adjustmentSeconds = double.Parse(response); // Parse the adjustment

                    AdjustClientTime(adjustmentSeconds);
                    break;
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.TimedOut)
                    {
                        LogMessage("Receive timed out. No data received.");
                    }
                    else
                    {
                        LogMessage($"Socket error: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    LogMessage($"Error: {ex.Message}");
                }
            }
        }

        private void AdjustClientTime(double adjustmentSeconds)
        {
            DateTime adjustedTime = DateTime.Now.AddSeconds(adjustmentSeconds);
            LogMessage($"Time adjusted by {adjustmentSeconds} seconds. New time: {adjustedTime:HH:mm:ss}");

            // You can optionally adjust system clock here, or just log the adjustment
        }

        private void LogMessage(string message)
        {
            if (txtClientLog.InvokeRequired)
            {
                txtClientLog.Invoke(new Action(() => LogMessage(message)));
            }
            else
            {
                txtClientLog.AppendText(message + Environment.NewLine);
            }
        }
    }
}
