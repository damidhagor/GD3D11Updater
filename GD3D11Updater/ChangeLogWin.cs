using System;
using System.Windows.Forms;

namespace GD3D11Updater
{
    // Form to display a chengelog
    public partial class ChangeLogWin : Form
    {
        /// <summary>
        /// Creates a new form with the given changelog.
        /// </summary>
        /// <param name="changelog">Changelog to be displayed. String can be RTF conform.</param>
        public ChangeLogWin(string changelog)
        {
            LogClass.LogLine("ChangeLogWin: InitializeComponent");
            InitializeComponent();
            LogClass.LogLine("ChangeLogWin: Set ChangeLog");
            ChangeLogRTB.Rtf = changelog;
            ResizeWin();
        }

        /// <summary>
        /// Arranges controls when form is resized.
        /// </summary>
        public void ResizeWin()
        {
            YesButton.Top = NoButton.Top = this.Height - 70;
            ChangeLogLabel.Top = YesButton.Top - 30;
            ChangeLogRTB.Height = (ChangeLogLabel.Top <= ChangeLogRTB.Top - 30) ? 0 : ChangeLogLabel.Top - ChangeLogRTB.Top - 10;
            ChangeLogRTB.Width = (this.Right <= ChangeLogRTB.Left) ? 0 : this.Width - ChangeLogRTB.Left - 30;
        }

        /// <summary>
        /// Handles click on YesButton.
        /// Closes the form with a DialogResult of "Yes".
        /// </summary>
        /// <param name="sender">Object which fired the event.</param>
        /// <param name="e">Event arguments.</param>
        private void YesButton_Click(object sender, EventArgs e)
        {
            LogClass.LogLine("ChangeLogWin: YES");
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        /// <summary>
        /// Handles click on NoButton.
        /// Closes the form with a DialogResult of "No".
        /// </summary>
        /// <param name="sender">Object which fired the event.</param>
        /// <param name="e">Event arguments.</param>
        private void NoButton_Click(object sender, EventArgs e)
        {
            LogClass.LogLine("ChangeLogWin: NO");
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        /// <summary>
        /// Handles form bei resized
        /// </summary>
        /// <param name="sender">Object which fired the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ChangeLogWin_Resize(object sender, EventArgs e)
        {
            ResizeWin();
        }

        /// <summary>
        /// Handles a click on a link in the ChangelogRTB.
        /// Opens the standart program for the link.
        /// </summary>
        /// <param name="sender">Object which fired the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ChangeLogRTB_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
