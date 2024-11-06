using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Axis_Configurator
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }

    public partial class MainForm : Form
    {
        private const string MacAddressPrefix = ""; //B8:A4 here

        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnScan_Click(object sender, EventArgs e)
        {
            ScanNetwork();
        }

        private void ScanNetwork()
        {
            lstDevices.Items.Clear();  // Clear previous results
            try
            {
                // Run the arp command
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "arp",
                        Arguments = "-a",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                // Parse ARP command output
                ParseArpOutput(output);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error scanning network: " + ex.Message);
            }
        }

        private void ParseArpOutput(string output)
        {
            // Regular expression to find MAC addresses
            var regex = new Regex(@"([0-9A-Fa-f]{2}-){5}[0-9A-Fa-f]{2}");
            var lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                // Match MAC addresses in the line
                var macMatch = regex.Match(line);
                if (macMatch.Success)
                {
                    string macAddress = macMatch.Value;

                    // Check if MAC address starts with the specified prefix
                    if (macAddress.StartsWith(MacAddressPrefix, StringComparison.OrdinalIgnoreCase))
                    {
                        lstDevices.Items.Add($"Device: {macAddress} - {line}");
                    }
                }
            }
        }
    }
}
