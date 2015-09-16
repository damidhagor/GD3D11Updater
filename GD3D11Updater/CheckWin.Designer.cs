namespace GD3D11Updater
{
    partial class CheckWin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckWin));
            this.CheckLabel = new System.Windows.Forms.Label();
            this.CheckProgressBar = new System.Windows.Forms.ProgressBar();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CheckLabel
            // 
            this.CheckLabel.AutoSize = true;
            this.CheckLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckLabel.Location = new System.Drawing.Point(12, 9);
            this.CheckLabel.Name = "CheckLabel";
            this.CheckLabel.Size = new System.Drawing.Size(154, 17);
            this.CheckLabel.TabIndex = 0;
            this.CheckLabel.Text = "Checking for updates...";
            // 
            // CheckProgressBar
            // 
            this.CheckProgressBar.Location = new System.Drawing.Point(15, 41);
            this.CheckProgressBar.MarqueeAnimationSpeed = 30;
            this.CheckProgressBar.Name = "CheckProgressBar";
            this.CheckProgressBar.Size = new System.Drawing.Size(305, 23);
            this.CheckProgressBar.Step = 1;
            this.CheckProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.CheckProgressBar.TabIndex = 1;
            this.CheckProgressBar.Value = 100;
            // 
            // CancelButton
            // 
            this.CancelButton.Enabled = false;
            this.CancelButton.Location = new System.Drawing.Point(342, 41);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // CheckWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(431, 76);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CheckProgressBar);
            this.Controls.Add(this.CheckLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CheckWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "G2D3D11Updater";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label CheckLabel;
        private System.Windows.Forms.ProgressBar CheckProgressBar;
        private System.Windows.Forms.Button CancelButton;
    }
}

