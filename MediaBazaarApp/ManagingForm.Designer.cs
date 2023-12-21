namespace MediaBazaarApp
{
    partial class ManagingForm
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
            this.components = new System.ComponentModel.Container();
            this.ManagementTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.seeEmployeeShift = new System.Windows.Forms.Button();
            this.deleteEmployeeButton = new System.Windows.Forms.Button();
            this.updateEmployeeButton = new System.Windows.Forms.Button();
            this.SearchFilterComboBox = new System.Windows.Forms.ComboBox();
            this.searchEmployeeButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.seeEmployeeNoShiftButton = new System.Windows.Forms.Button();
            this.seeAssignedEmployeeButton = new System.Windows.Forms.Button();
            this.seeAllEmployeeButton = new System.Windows.Forms.Button();
            this.employeeListBox = new System.Windows.Forms.ListBox();
            this.addNewEmployeeButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.editSelectedShiftButton = new System.Windows.Forms.Button();
            this.labelNightShiftCount = new System.Windows.Forms.Label();
            this.labelAfternoonShiftCount = new System.Windows.Forms.Label();
            this.labelMorningShiftCount = new System.Windows.Forms.Label();
            this.nightShiftsListBox = new System.Windows.Forms.ListBox();
            this.afternoonShiftsListBox = new System.Windows.Forms.ListBox();
            this.morningShiftsListBox = new System.Windows.Forms.ListBox();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.shiftBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.automaticShiftsButton = new System.Windows.Forms.Button();
            this.ManagementTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shiftBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ManagementTabControl
            // 
            this.ManagementTabControl.Controls.Add(this.tabPage1);
            this.ManagementTabControl.Controls.Add(this.tabPage2);
            this.ManagementTabControl.Location = new System.Drawing.Point(12, 5);
            this.ManagementTabControl.Name = "ManagementTabControl";
            this.ManagementTabControl.SelectedIndex = 0;
            this.ManagementTabControl.Size = new System.Drawing.Size(1425, 629);
            this.ManagementTabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.tabPage1.Controls.Add(this.seeEmployeeShift);
            this.tabPage1.Controls.Add(this.deleteEmployeeButton);
            this.tabPage1.Controls.Add(this.updateEmployeeButton);
            this.tabPage1.Controls.Add(this.SearchFilterComboBox);
            this.tabPage1.Controls.Add(this.searchEmployeeButton);
            this.tabPage1.Controls.Add(this.searchTextBox);
            this.tabPage1.Controls.Add(this.seeEmployeeNoShiftButton);
            this.tabPage1.Controls.Add(this.seeAssignedEmployeeButton);
            this.tabPage1.Controls.Add(this.seeAllEmployeeButton);
            this.tabPage1.Controls.Add(this.employeeListBox);
            this.tabPage1.Controls.Add(this.addNewEmployeeButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1417, 601);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Employee Management";
            // 
            // seeEmployeeShift
            // 
            this.seeEmployeeShift.Location = new System.Drawing.Point(19, 177);
            this.seeEmployeeShift.Name = "seeEmployeeShift";
            this.seeEmployeeShift.Size = new System.Drawing.Size(171, 45);
            this.seeEmployeeShift.TabIndex = 1;
            this.seeEmployeeShift.Text = "See Selected Employee\'s Shift";
            this.seeEmployeeShift.UseVisualStyleBackColor = true;
            this.seeEmployeeShift.Click += new System.EventHandler(this.seeEmployeeShift_Click);
            // 
            // deleteEmployeeButton
            // 
            this.deleteEmployeeButton.Location = new System.Drawing.Point(196, 420);
            this.deleteEmployeeButton.Name = "deleteEmployeeButton";
            this.deleteEmployeeButton.Size = new System.Drawing.Size(171, 37);
            this.deleteEmployeeButton.TabIndex = 8;
            this.deleteEmployeeButton.Text = "Delete Employee";
            this.deleteEmployeeButton.UseVisualStyleBackColor = true;
            this.deleteEmployeeButton.Click += new System.EventHandler(this.deleteEmployeeButton_Click);
            // 
            // updateEmployeeButton
            // 
            this.updateEmployeeButton.Location = new System.Drawing.Point(19, 420);
            this.updateEmployeeButton.Name = "updateEmployeeButton";
            this.updateEmployeeButton.Size = new System.Drawing.Size(171, 37);
            this.updateEmployeeButton.TabIndex = 7;
            this.updateEmployeeButton.Text = "Update Employee\'s Data";
            this.updateEmployeeButton.UseVisualStyleBackColor = true;
            this.updateEmployeeButton.Click += new System.EventHandler(this.updateEmployeeButton_Click);
            // 
            // SearchFilterComboBox
            // 
            this.SearchFilterComboBox.FormattingEnabled = true;
            this.SearchFilterComboBox.Items.AddRange(new object[] {
            "By Username",
            "By Last Name"});
            this.SearchFilterComboBox.Location = new System.Drawing.Point(236, 59);
            this.SearchFilterComboBox.Name = "SearchFilterComboBox";
            this.SearchFilterComboBox.Size = new System.Drawing.Size(92, 23);
            this.SearchFilterComboBox.TabIndex = 6;
            this.SearchFilterComboBox.Text = "Filter";
            // 
            // searchEmployeeButton
            // 
            this.searchEmployeeButton.Location = new System.Drawing.Point(60, 88);
            this.searchEmployeeButton.Name = "searchEmployeeButton";
            this.searchEmployeeButton.Size = new System.Drawing.Size(170, 37);
            this.searchEmployeeButton.TabIndex = 5;
            this.searchEmployeeButton.Text = "Search for the Employee";
            this.searchEmployeeButton.UseVisualStyleBackColor = true;
            this.searchEmployeeButton.Click += new System.EventHandler(this.searchEmployeeButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(41, 59);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.PlaceholderText = "Search User";
            this.searchTextBox.Size = new System.Drawing.Size(189, 23);
            this.searchTextBox.TabIndex = 4;
            // 
            // seeEmployeeNoShiftButton
            // 
            this.seeEmployeeNoShiftButton.Location = new System.Drawing.Point(19, 306);
            this.seeEmployeeNoShiftButton.Name = "seeEmployeeNoShiftButton";
            this.seeEmployeeNoShiftButton.Size = new System.Drawing.Size(171, 37);
            this.seeEmployeeNoShiftButton.TabIndex = 1;
            this.seeEmployeeNoShiftButton.Text = "See Employees without Shifts";
            this.seeEmployeeNoShiftButton.UseVisualStyleBackColor = true;
            this.seeEmployeeNoShiftButton.Click += new System.EventHandler(this.seeEmployeeNoShiftButton_Click);
            // 
            // seeAssignedEmployeeButton
            // 
            this.seeAssignedEmployeeButton.Location = new System.Drawing.Point(196, 263);
            this.seeAssignedEmployeeButton.Name = "seeAssignedEmployeeButton";
            this.seeAssignedEmployeeButton.Size = new System.Drawing.Size(171, 37);
            this.seeAssignedEmployeeButton.TabIndex = 3;
            this.seeAssignedEmployeeButton.Text = "See assigned Employees";
            this.seeAssignedEmployeeButton.UseVisualStyleBackColor = true;
            this.seeAssignedEmployeeButton.Click += new System.EventHandler(this.seeAssignedEmployeeButton_Click);
            // 
            // seeAllEmployeeButton
            // 
            this.seeAllEmployeeButton.Location = new System.Drawing.Point(19, 263);
            this.seeAllEmployeeButton.Name = "seeAllEmployeeButton";
            this.seeAllEmployeeButton.Size = new System.Drawing.Size(171, 37);
            this.seeAllEmployeeButton.TabIndex = 2;
            this.seeAllEmployeeButton.Text = "See all Employees";
            this.seeAllEmployeeButton.UseVisualStyleBackColor = true;
            this.seeAllEmployeeButton.Click += new System.EventHandler(this.seeAllEmployeeButton_Click);
            // 
            // employeeListBox
            // 
            this.employeeListBox.FormattingEnabled = true;
            this.employeeListBox.ItemHeight = 15;
            this.employeeListBox.Location = new System.Drawing.Point(511, 6);
            this.employeeListBox.Name = "employeeListBox";
            this.employeeListBox.Size = new System.Drawing.Size(900, 589);
            this.employeeListBox.TabIndex = 1;
            // 
            // addNewEmployeeButton
            // 
            this.addNewEmployeeButton.Location = new System.Drawing.Point(20, 498);
            this.addNewEmployeeButton.Name = "addNewEmployeeButton";
            this.addNewEmployeeButton.Size = new System.Drawing.Size(170, 37);
            this.addNewEmployeeButton.TabIndex = 0;
            this.addNewEmployeeButton.Text = "Add New Employee";
            this.addNewEmployeeButton.UseVisualStyleBackColor = true;
            this.addNewEmployeeButton.Click += new System.EventHandler(this.addNewEmployeeButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.tabPage2.Controls.Add(this.automaticShiftsButton);
            this.tabPage2.Controls.Add(this.editSelectedShiftButton);
            this.tabPage2.Controls.Add(this.labelNightShiftCount);
            this.tabPage2.Controls.Add(this.labelAfternoonShiftCount);
            this.tabPage2.Controls.Add(this.labelMorningShiftCount);
            this.tabPage2.Controls.Add(this.nightShiftsListBox);
            this.tabPage2.Controls.Add(this.afternoonShiftsListBox);
            this.tabPage2.Controls.Add(this.morningShiftsListBox);
            this.tabPage2.Controls.Add(this.monthCalendar);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1417, 601);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Shift Management";
            // 
            // editSelectedShiftButton
            // 
            this.editSelectedShiftButton.Location = new System.Drawing.Point(6, 348);
            this.editSelectedShiftButton.Name = "editSelectedShiftButton";
            this.editSelectedShiftButton.Size = new System.Drawing.Size(167, 60);
            this.editSelectedShiftButton.TabIndex = 9;
            this.editSelectedShiftButton.Text = "Edit Selected Shift";
            this.editSelectedShiftButton.UseVisualStyleBackColor = true;
            this.editSelectedShiftButton.Click += new System.EventHandler(this.editSelectedShiftButton_Click);
            // 
            // labelNightShiftCount
            // 
            this.labelNightShiftCount.AutoSize = true;
            this.labelNightShiftCount.Location = new System.Drawing.Point(470, 352);
            this.labelNightShiftCount.Name = "labelNightShiftCount";
            this.labelNightShiftCount.Size = new System.Drawing.Size(38, 15);
            this.labelNightShiftCount.TabIndex = 8;
            this.labelNightShiftCount.Text = "label3";
            // 
            // labelAfternoonShiftCount
            // 
            this.labelAfternoonShiftCount.AutoSize = true;
            this.labelAfternoonShiftCount.Location = new System.Drawing.Point(470, 178);
            this.labelAfternoonShiftCount.Name = "labelAfternoonShiftCount";
            this.labelAfternoonShiftCount.Size = new System.Drawing.Size(38, 15);
            this.labelAfternoonShiftCount.TabIndex = 7;
            this.labelAfternoonShiftCount.Text = "label2";
            // 
            // labelMorningShiftCount
            // 
            this.labelMorningShiftCount.AutoSize = true;
            this.labelMorningShiftCount.Location = new System.Drawing.Point(473, 6);
            this.labelMorningShiftCount.Name = "labelMorningShiftCount";
            this.labelMorningShiftCount.Size = new System.Drawing.Size(38, 15);
            this.labelMorningShiftCount.TabIndex = 6;
            this.labelMorningShiftCount.Text = "label2";
            // 
            // nightShiftsListBox
            // 
            this.nightShiftsListBox.FormattingEnabled = true;
            this.nightShiftsListBox.ItemHeight = 15;
            this.nightShiftsListBox.Location = new System.Drawing.Point(470, 370);
            this.nightShiftsListBox.Name = "nightShiftsListBox";
            this.nightShiftsListBox.Size = new System.Drawing.Size(839, 139);
            this.nightShiftsListBox.TabIndex = 3;
            // 
            // afternoonShiftsListBox
            // 
            this.afternoonShiftsListBox.FormattingEnabled = true;
            this.afternoonShiftsListBox.ItemHeight = 15;
            this.afternoonShiftsListBox.Location = new System.Drawing.Point(473, 196);
            this.afternoonShiftsListBox.Name = "afternoonShiftsListBox";
            this.afternoonShiftsListBox.Size = new System.Drawing.Size(839, 139);
            this.afternoonShiftsListBox.TabIndex = 2;
            // 
            // morningShiftsListBox
            // 
            this.morningShiftsListBox.FormattingEnabled = true;
            this.morningShiftsListBox.ItemHeight = 15;
            this.morningShiftsListBox.Location = new System.Drawing.Point(470, 24);
            this.morningShiftsListBox.Name = "morningShiftsListBox";
            this.morningShiftsListBox.Size = new System.Drawing.Size(839, 139);
            this.morningShiftsListBox.TabIndex = 1;
            // 
            // monthCalendar
            // 
            this.monthCalendar.CalendarDimensions = new System.Drawing.Size(2, 2);
            this.monthCalendar.Location = new System.Drawing.Point(0, 0);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateChanged);
            // 
            // shiftBindingSource
            // 
            this.shiftBindingSource.DataSource = typeof(BusinessLogic.Classes.Shift);
            // 
            // automaticShiftsButton
            // 
            this.automaticShiftsButton.Location = new System.Drawing.Point(6, 444);
            this.automaticShiftsButton.Name = "automaticShiftsButton";
            this.automaticShiftsButton.Size = new System.Drawing.Size(167, 48);
            this.automaticShiftsButton.TabIndex = 10;
            this.automaticShiftsButton.Text = "Automatic Shifts";
            this.automaticShiftsButton.UseVisualStyleBackColor = true;
            this.automaticShiftsButton.Click += new System.EventHandler(this.automaticShiftsButton_Click);
            // 
            // ManagingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.ClientSize = new System.Drawing.Size(1449, 646);
            this.Controls.Add(this.ManagementTabControl);
            this.Name = "ManagingForm";
            this.Text = "Managing Form";
            this.ManagementTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shiftBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl ManagementTabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button addNewEmployeeButton;
        private Button seeAssignedEmployeeButton;
        private Button seeAllEmployeeButton;
        private ListBox employeeListBox;
        private Button seeEmployeeNoShiftButton;
        private ComboBox SearchFilterComboBox;
        private Button searchEmployeeButton;
        private TextBox searchTextBox;
        private Button deleteEmployeeButton;
        private Button updateEmployeeButton;
        private Button seeEmployeeShift;
        private BindingSource shiftBindingSource;
        private MonthCalendar monthCalendar;
        private ListBox nightShiftsListBox;
        private ListBox afternoonShiftsListBox;
        private ListBox morningShiftsListBox;
        private Label labelMorningShiftCount;
        private Label labelNightShiftCount;
        private Label labelAfternoonShiftCount;
        private Button editSelectedShiftButton;
        private Button automaticShiftsButton;
    }
}