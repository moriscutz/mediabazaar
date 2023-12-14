namespace MediaBazaarApp
{
    partial class ChangeShift
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
            this.label1 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.employeeIDLabel = new System.Windows.Forms.Label();
            this.shiftIDLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.employeeNameLabel = new System.Windows.Forms.Label();
            this.updateTypeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shift Information";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Font = new System.Drawing.Font("SimSun", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label69.Location = new System.Drawing.Point(12, 67);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(107, 17);
            this.label69.TabIndex = 1;
            this.label69.Text = "Shift\'s ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Employee\'s ID:";
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(149, 247);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 3;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Shift\'s Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Type";
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Morning",
            "Afternoon",
            "Night"});
            this.typeComboBox.Location = new System.Drawing.Point(127, 185);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(148, 23);
            this.typeComboBox.TabIndex = 6;
            // 
            // employeeIDLabel
            // 
            this.employeeIDLabel.AutoSize = true;
            this.employeeIDLabel.Font = new System.Drawing.Font("SimSun", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.employeeIDLabel.Location = new System.Drawing.Point(152, 102);
            this.employeeIDLabel.Name = "employeeIDLabel";
            this.employeeIDLabel.Size = new System.Drawing.Size(62, 17);
            this.employeeIDLabel.TabIndex = 7;
            this.employeeIDLabel.Text = "label5";
            // 
            // shiftIDLabel
            // 
            this.shiftIDLabel.AutoSize = true;
            this.shiftIDLabel.Font = new System.Drawing.Font("SimSun", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.shiftIDLabel.Location = new System.Drawing.Point(149, 67);
            this.shiftIDLabel.Name = "shiftIDLabel";
            this.shiftIDLabel.Size = new System.Drawing.Size(62, 17);
            this.shiftIDLabel.TabIndex = 8;
            this.shiftIDLabel.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SimSun", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(12, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(287, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Employee\'s First and Last Name:";
            // 
            // employeeNameLabel
            // 
            this.employeeNameLabel.AutoSize = true;
            this.employeeNameLabel.Font = new System.Drawing.Font("SimSun", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.employeeNameLabel.Location = new System.Drawing.Point(305, 138);
            this.employeeNameLabel.Name = "employeeNameLabel";
            this.employeeNameLabel.Size = new System.Drawing.Size(62, 17);
            this.employeeNameLabel.TabIndex = 10;
            this.employeeNameLabel.Text = "label6";
            // 
            // updateTypeButton
            // 
            this.updateTypeButton.Location = new System.Drawing.Point(305, 185);
            this.updateTypeButton.Name = "updateTypeButton";
            this.updateTypeButton.Size = new System.Drawing.Size(114, 23);
            this.updateTypeButton.TabIndex = 11;
            this.updateTypeButton.Text = "Update Type";
            this.updateTypeButton.UseVisualStyleBackColor = true;
            this.updateTypeButton.Click += new System.EventHandler(this.updateTypeButton_Click);
            // 
            // ChangeShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ClientSize = new System.Drawing.Size(489, 479);
            this.Controls.Add(this.updateTypeButton);
            this.Controls.Add(this.employeeNameLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.shiftIDLabel);
            this.Controls.Add(this.employeeIDLabel);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label69);
            this.Controls.Add(this.label1);
            this.Name = "ChangeShift";
            this.Text = "Change Shift Window";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label69;
        private Label label3;
        private MonthCalendar monthCalendar;
        private Label label2;
        private Label label4;
        private ComboBox typeComboBox;
        private Label employeeIDLabel;
        private Label shiftIDLabel;
        private Label label5;
        private Label employeeNameLabel;
        private Button updateTypeButton;
    }
}