namespace MediaBazaarApp
{
    partial class AddNewShiftForm
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
            this.monthCalendarAddShift = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.availableEmployeesListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // monthCalendarAddShift
            // 
            this.monthCalendarAddShift.Location = new System.Drawing.Point(18, 9);
            this.monthCalendarAddShift.MaxSelectionCount = 1;
            this.monthCalendarAddShift.Name = "monthCalendarAddShift";
            this.monthCalendarAddShift.TabIndex = 0;
            this.monthCalendarAddShift.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarAddShift_DateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(18, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type";
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Morning",
            "Afternoon",
            "Night"});
            this.typeComboBox.Location = new System.Drawing.Point(112, 240);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(121, 23);
            this.typeComboBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(18, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Employee Username:";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(277, 198);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(121, 23);
            this.usernameTextBox.TabIndex = 4;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(57, 300);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(159, 40);
            this.confirmButton.TabIndex = 5;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // availableEmployeesListBox
            // 
            this.availableEmployeesListBox.FormattingEnabled = true;
            this.availableEmployeesListBox.ItemHeight = 15;
            this.availableEmployeesListBox.Location = new System.Drawing.Point(445, 92);
            this.availableEmployeesListBox.Name = "availableEmployeesListBox";
            this.availableEmployeesListBox.Size = new System.Drawing.Size(278, 154);
            this.availableEmployeesListBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(445, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 42);
            this.label3.TabIndex = 7;
            this.label3.Text = "Available Employees \r\nthat are not shifted\r\n";
            // 
            // AddNewShiftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ClientSize = new System.Drawing.Size(735, 365);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.availableEmployeesListBox);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthCalendarAddShift);
            this.Name = "AddNewShiftForm";
            this.Text = "Add New Shift";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MonthCalendar monthCalendarAddShift;
        private Label label1;
        private ComboBox typeComboBox;
        private Label label2;
        private TextBox usernameTextBox;
        private Button confirmButton;
        private ListBox availableEmployeesListBox;
        private Label label3;
    }
}