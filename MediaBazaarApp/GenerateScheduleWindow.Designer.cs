namespace MediaBazaarApp
{
    partial class GenerateScheduleWindow
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
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.startingDateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(43, 45);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateChanged);
            // 
            // startingDateLabel
            // 
            this.startingDateLabel.AutoSize = true;
            this.startingDateLabel.Font = new System.Drawing.Font("SimSun", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startingDateLabel.Location = new System.Drawing.Point(12, 9);
            this.startingDateLabel.Name = "startingDateLabel";
            this.startingDateLabel.Size = new System.Drawing.Size(292, 27);
            this.startingDateLabel.TabIndex = 1;
            this.startingDateLabel.Text = "Choose starting date";
            // 
            // GenerateScheduleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ClientSize = new System.Drawing.Size(323, 247);
            this.Controls.Add(this.startingDateLabel);
            this.Controls.Add(this.monthCalendar);
            this.Name = "GenerateScheduleWindow";
            this.Text = "Generate Schedule";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MonthCalendar monthCalendar;
        private Label startingDateLabel;
    }
}