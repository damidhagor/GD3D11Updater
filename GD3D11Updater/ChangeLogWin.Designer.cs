namespace GD3D11Updater
{
    partial class ChangeLogWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeLogWin));
            this.ChangeLogRTB = new System.Windows.Forms.RichTextBox();
            this.YesButton = new System.Windows.Forms.Button();
            this.NoButton = new System.Windows.Forms.Button();
            this.ChangeLogLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ChangeLogRTB
            // 
            this.ChangeLogRTB.HideSelection = false;
            this.ChangeLogRTB.Location = new System.Drawing.Point(12, 12);
            this.ChangeLogRTB.Name = "ChangeLogRTB";
            this.ChangeLogRTB.ReadOnly = true;
            this.ChangeLogRTB.Size = new System.Drawing.Size(555, 394);
            this.ChangeLogRTB.TabIndex = 0;
            this.ChangeLogRTB.Text = "";
            this.ChangeLogRTB.WordWrap = false;
            this.ChangeLogRTB.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.ChangeLogRTB_LinkClicked);
            // 
            // YesButton
            // 
            this.YesButton.Location = new System.Drawing.Point(176, 444);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(75, 23);
            this.YesButton.TabIndex = 1;
            this.YesButton.Text = "Yes";
            this.YesButton.UseVisualStyleBackColor = true;
            this.YesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // NoButton
            // 
            this.NoButton.Location = new System.Drawing.Point(301, 444);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(75, 23);
            this.NoButton.TabIndex = 2;
            this.NoButton.Text = "No";
            this.NoButton.UseVisualStyleBackColor = true;
            this.NoButton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // ChangeLogLabel
            // 
            this.ChangeLogLabel.AutoSize = true;
            this.ChangeLogLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeLogLabel.Location = new System.Drawing.Point(199, 416);
            this.ChangeLogLabel.Name = "ChangeLogLabel";
            this.ChangeLogLabel.Size = new System.Drawing.Size(158, 17);
            this.ChangeLogLabel.TabIndex = 3;
            this.ChangeLogLabel.Text = "Do you want to update?";
            // 
            // ChangeLogWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(579, 477);
            this.Controls.Add(this.ChangeLogLabel);
            this.Controls.Add(this.NoButton);
            this.Controls.Add(this.YesButton);
            this.Controls.Add(this.ChangeLogRTB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ChangeLogWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Changelog";
            this.TopMost = true;
            this.Resize += new System.EventHandler(this.ChangeLogWin_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ChangeLogRTB;
        private System.Windows.Forms.Button YesButton;
        private System.Windows.Forms.Button NoButton;
        private System.Windows.Forms.Label ChangeLogLabel;
    }
}