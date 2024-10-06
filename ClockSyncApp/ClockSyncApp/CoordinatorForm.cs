using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace ClockSyncApp
{
    public partial class CoordinatorForm : Form
    {
        private UdpHelper udpHelper;
        private int coordinatorPort = 8000;
        private int clientPort = 8081;
        private List<DateTime> clientTimes; // List of client times

        public CoordinatorForm()
        {
            InitializeComponent();
            udpHelper = new UdpHelper(coordinatorPort);
            clientTimes = new List<DateTime>();

            // Start listening for client connections
            Thread listenThread = new Thread(ListenForClientConnections);
            listenThread.IsBackground = true; // Set the thread as a background thread
            listenThread.Start();
        }

        private void ListenForClientConnections()
        {
            LogMessage("Waiting for client connections...");

            while (true)
            {
                string clientResponse = udpHelper.Receive(); // Wait for a client time
                DateTime clientTime = DateTime.Parse(clientResponse); // Parse the client time
                clientTimes.Add(clientTime); // Add client time to the list
                UpdateClientTimesDisplay(clientTime); // Update the display
                LogMessage($"Client connected: {clientTime:HH:mm:ss}");
            }
        }

        private void UpdateClientTimesDisplay(DateTime clientTime)
        {
            if (txtClientTimes.InvokeRequired)
            {
                txtClientTimes.Invoke(new Action(() => UpdateClientTimesDisplay(clientTime))); // Marshal to UI thread
            }
            else
            {
                txtClientTimes.AppendText($"- Client {clientTimes.Count}: {clientTime:HH:mm:ss} {Environment.NewLine}");
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            if (clientTimes.Count == 0)
            {
                LogMessage("No client connected.");
                return;
            }

            // Proceed with synchronization
            udpHelper.Send("TIME_REQUEST", "255.255.255.255", clientPort); // Broadcast time request
            LogMessage("Sent request to all clients.");

            Thread listenThread = new Thread(ListenForClientResponses);
            listenThread.IsBackground = true; // Set the thread as a background thread
            listenThread.Start();
        }

        private void ListenForClientResponses()
        {
            LogMessage("Waiting for client responses...");

            for (int i = 0; i < clientTimes.Count; i++)
            {
                string clientResponse = udpHelper.Receive(); // Receive client time
                DateTime clientTime = DateTime.Parse(clientResponse); // Parse the client time
                LogMessage($" - Response from client {i + 1}: {clientTime:HH:mm:ss}");
            }

            // Continue with average time calculation and adjustments...
        }

        private void LogMessage(string message)
        {
            if (txtMessageLog.InvokeRequired) // Check if the call is from a different thread
            {
                txtMessageLog.Invoke(new Action<string>(LogMessage), message); // Invoke the method on the UI thread
            }
            else
            {
                txtMessageLog.AppendText(message + Environment.NewLine); // Append text if already on the UI thread
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            coordinatorTimeLbl.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
