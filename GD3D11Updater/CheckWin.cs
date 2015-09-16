using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GD3D11Updater
{
    // TODO: Proper comments
    // TODO: Extract downloader into seperate class
    public partial class CheckWin : Form
    {
        private string fileName;    // Filename of saved installer
        private WebClient wc;       // WebClient for updater

        // onstructor
        public CheckWin(string cVersion, int gothicID)
        {
            LogClass.LogLine("CheckWin: InitializeComponent");
            InitializeComponent();
            LogClass.LogLine("CheckWin: Update(" + cVersion + ", " + gothicID.ToString() + ")");
            Update(cVersion, gothicID);
        }

        // Display Error-Msg and close form
        private void Error(string error)
        {
            this.Invoke((Action)(() =>
            {
                LogClass.LogLine("CheckWin: Error(" + error + ")");
                MessageBox.Show(error, "Error", MessageBoxButtons.OK);
                this.Close();
            }));
        }

        // Close form when finished
        private void Finished()
        {
            LogClass.LogLine("CheckWin: Finished");
            this.Invoke((Action)(() =>
            {
                this.Close();
            }));
        }

        // On download begin set filename, set progressBar, enable cancel-Button
        private void DownloadBegin(string fName)
        {
            this.Invoke((Action)(() =>
            {
                LogClass.LogLine("CheckWin: DownloadBegin(" + fName + ")");
                fileName = fName;
                CheckLabel.Text = "Downloading update...";
                CheckProgressBar.Style = ProgressBarStyle.Blocks;
                CheckProgressBar.Value = 0;
                CancelButton.Enabled = true;
            }));
        }

        // Handles download progress
        private void DownloadProgressed(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Invoke((Action)(() =>
            {
                CheckLabel.Text = "Downloading update (" + e.BytesReceived/1024 + "kB/" + e.TotalBytesToReceive/1024 + "kB)";
                CheckProgressBar.Value = e.ProgressPercentage;
            }));
        }

        // Handles download completion
        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // Error if cancelled or failed
            if (e.Cancelled == true)
            {
                LogClass.LogLine("CheckWin: Download cancelled");
                Error("Download has been cancelled.");
            }
            else if (e.Error != null)
            {
                LogClass.LogLine("CheckWin: Download error: " + e.Error.Message);
                Error("Error while downloading update file.");
            }
            // If successful
            else
            {
                LogClass.LogLine("CheckWin: Download finished");
                this.Invoke((Action)(() =>
                {
                    CheckLabel.Text = "Downloading update completed";
                    CheckProgressBar.Value = 100;
                    CancelButton.Enabled = false;

                    // Check for existing installer
                    if(File.Exists(fileName) == false)
                    {
                        Error("Could not find downloaded update file.");
                        return;
                    }

                    // Start installer
                    try
                    {
                        LogClass.LogLine("CheckWin: Process.Start(" + fileName + ", \"\")");
                        System.Diagnostics.Process.Start(fileName, "");
                    }
                    catch(Exception)
                    {
                        LogClass.LogLine("CheckWin: Error executing installer: " + e.Error.Message);
                        Error("Error while executing installer.");
                    }

                    Finished();
                }));
            }
        }

        // TODO: Full error handling
        // Compare 2 version strings
        private bool CompareVersions(string cVersion, string nVersion)
        {
            // Parse versions as int-Array
            int[] curVersion = (from part in cVersion.Split('.') select int.Parse(part)).ToArray();
            int[] newVersion = (from part in nVersion.Split('.') select int.Parse(part)).ToArray();

            if(curVersion.Length == 0 || newVersion.Length == 0)
            {
                return (false);
            }

            // Iterate over current version's parts
            int i;
            for (i = 0; i < curVersion.Length; i++ )
            {
                // Current version newest
                if (curVersion[i] > newVersion[i])
                {
                    return (false);
                }
                // Current version older
                else if (curVersion[i] < newVersion[i])
                {
                    return (true);
                }
                // Current version's part equals newer version' part
                else
                {
                    // Current version newer if new version shorter
                    if (newVersion.Length == i + 1)
                    {
                        return (false);
                    }
                }
            }

            // Current version newer
            return (true);
        }

        // Update version
        private void CheckUpdate(string cVersion, int gothicID)
        {
            List<string[]> versions = new List<string[]>();
            string updatePath = Properties.Settings.Default.updateURL;
            string updateFile = Properties.Settings.Default.updateFile;
            string line;

            // New StreamReader to version's file
            try
            {
                LogClass.LogLine("CheckWin: Open version file \"" + updatePath + updateFile + "\"");
                StreamReader sr = new StreamReader(wc.OpenRead(new Uri(updatePath + updateFile)));
                
                // Read each line
                while ((line = sr.ReadLine()) != null)
                {
                    // Split line into its parts
                    string[] version = line.Split(';');
                    if (version.Length != 3)
                    {
                        Error("Error while parsing the version file.");
                        return;
                    }
                    // Store version-Array in list
                    versions.Add(new string[] { version[0], version[1], version[2] });
                }

                sr.Close();
            }
            catch (WebException)
            {
                Error("Error while connecting to the update server.");
                return;
            }

            // If 1 version returned and current version outdated
            if (versions.Count > 0 && CompareVersions(cVersion, versions[versions.Count - 1][0]))
            {
                LogClass.LogLine("CheckWin: New version: " + versions[versions.Count - 1][0]);
                string changelog = "";

                // New StreamReader to changelog's file, read complete file
                try
                {
                    LogClass.LogLine("CheckWin: Opening changelog file \"" + updatePath + versions[versions.Count - 1][2] + "\"");
                    StreamReader sr = new StreamReader(wc.OpenRead(new Uri(updatePath + versions[versions.Count - 1][2])));
                    changelog = sr.ReadToEnd();
                }
                catch (WebException)
                {
                    MessageBox.Show("Error while downloading the changelog.", "Error", MessageBoxButtons.OK);
                    changelog = "No changelog available.\n\nDo you want to install the update anyway?";
                }

                // Show changelog and let user choose to update
                ChangeLogWin clw = new ChangeLogWin(changelog);
                this.Visible = false;
                DialogResult dr = clw.ShowDialog();
                this.Visible = true;
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        // Get gothic's process, kill it
                        LogClass.LogLine("CheckWin: GetProcessById(" + gothicID.ToString() + ")");
                        System.Diagnostics.Process gothic = System.Diagnostics.Process.GetProcessById(gothicID);
                        LogClass.LogLine("CheckWin: Kill G2 process");
                        gothic.Kill();
                        LogClass.LogLine("CheckWin: Wait for G2 process");
                        gothic.WaitForExit();
                        LogClass.LogLine("CheckWin: Dispose G2 process");
                        gothic.Dispose();

                        // Start download async of installer
                        string fileName = versions[versions.Count - 1][1].Substring(versions[versions.Count - 1][1].LastIndexOf('/') + 1);
                        DownloadBegin(fileName);
                        wc.DownloadProgressChanged += this.DownloadProgressed;
                        wc.DownloadFileCompleted += this.DownloadCompleted;
                        LogClass.LogLine("CheckWin: Begin Download");
                        wc.DownloadFileAsync(new Uri(updatePath + versions[versions.Count - 1][1]), fileName);
                        return;
                    }
                    catch(WebException)
                    {
                        Error("Error while downloading update file.");
                        return;
                    }
                }

                Finished();
                return;
            }

            Finished();
            return;
        }

        // Start update task
        public void Update(string cVersion, int gothicID)
        {
            wc = new WebClient();
            Task.Factory.StartNew(() => CheckUpdate(cVersion, gothicID));
        }

        // Cancel-Button click
        private void CancelButton_Click(object sender, EventArgs e)
        {
            wc.CancelAsync();   // Cancel Async-Download
        }
    }
}