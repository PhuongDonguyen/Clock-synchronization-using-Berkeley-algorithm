// Coordinator
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace ClockSyncApp
{
    public partial class CoordinatorForm : Form
    {
        private UdpHelper udpHelper;
        private int coordinatorPort = 8000;
        private List<DateTime> clientTimes;
        private List<IPEndPoint> clientEndpoints;

        public CoordinatorForm()
        {
            InitializeComponent();
            udpHelper = new UdpHelper(coordinatorPort);
            clientTimes = new List<DateTime>();
            clientEndpoints = new List<IPEndPoint>();

            Thread listenThread = new Thread(ListenForClientConnections);
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        private void ListenForClientConnections()
        {
            LogMessage("Waiting for client connections...");
            while (true)
            {
                IPEndPoint clientEndpoint = new IPEndPoint(IPAddress.Any, 0);
                string clientResponse = udpHelper.Receive(ref clientEndpoint);

                DateTime clientTime = DateTime.Parse(clientResponse);
                clientTimes.Add(clientTime);
                clientEndpoints.Add(clientEndpoint);

                UpdateClientTimesDisplay();
                LogMessage($"Client connected: {clientTime:HH:mm:ss} from {clientEndpoint.Address}:{clientEndpoint.Port}");
            }
        }

        private void UpdateClientTimesDisplay()
        {
            if (txtClientTimes.InvokeRequired)
            {
                txtClientTimes.Invoke(new Action(UpdateClientTimesDisplay));
            }
            else
            {
                txtClientTimes.Clear();
                for (int i = 0; i < clientTimes.Count; i++)
                {
                    txtClientTimes.AppendText($"- Client {i + 1}: {clientTimes[i]:HH:mm:ss} (IP: {clientEndpoints[i].Address}:{clientEndpoints[i].Port}){Environment.NewLine}");
                }
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            if (clientTimes.Count == 0 || clientEndpoints.Count == 0)
            {
                LogMessage("No clients connected.");
                return;
            }

            List<DateTime> receivedClientTimes = new List<DateTime>();

            for (int i = 0; i < clientTimes.Count; i++)
            {
                receivedClientTimes.Add(clientTimes[i]); // Add the already collected client times
            }

            DateTime averageTime = CalculateAverageTime(receivedClientTimes);
            LogMessage($"Calculated average time: {averageTime:HH:mm:ss}");

            for (int i = 0; i < receivedClientTimes.Count; i++)
            {
                TimeSpan timeDifference = averageTime - receivedClientTimes[i];
                AdjustClientTime(clientEndpoints[i], timeDifference);
            }
        }

        private DateTime CalculateAverageTime(List<DateTime> times)
        {
            long totalTicks = times.Sum(time => time.Ticks);
            long averageTicks = totalTicks / times.Count;
            return new DateTime(averageTicks);
        }

        private void AdjustClientTime(IPEndPoint clientEndpoint, TimeSpan adjustment)
        {
            string adjustmentMessage = $"{adjustment.TotalSeconds}"; // Only send the difference in seconds
            udpHelper.Send(adjustmentMessage, clientEndpoint.Address.ToString(), clientEndpoint.Port);
            LogMessage($"Sent time adjustment of {adjustment.TotalSeconds} seconds to {clientEndpoint.Address}:{clientEndpoint.Port}");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            coordinatorTimeLbl.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void LogMessage(string message)
        {
            if (txtMessageLog.InvokeRequired)
            {
                txtMessageLog.Invoke(new Action<string>(LogMessage), message);
            }
            else
            {
                txtMessageLog.AppendText(message + Environment.NewLine);
            }
        }
    }
}
