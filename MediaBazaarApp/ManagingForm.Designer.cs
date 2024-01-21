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
            this.dataGridViewShifts = new System.Windows.Forms.DataGridView();
            this.shiftIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeFirstAndLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shiftBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ManagementTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobPositionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.seeEmployeeShift = new System.Windows.Forms.Button();
            this.deleteEmployeeButton = new System.Windows.Forms.Button();
            this.updateEmployeeButton = new System.Windows.Forms.Button();
            this.SearchFilterComboBox = new System.Windows.Forms.ComboBox();
            this.searchEmployeeButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.seeEmployeeNoShiftButton = new System.Windows.Forms.Button();
            this.seeAssignedEmployeeButton = new System.Windows.Forms.Button();
            this.seeAllEmployeeButton = new System.Windows.Forms.Button();
            this.addNewEmployeeButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.addNewShiftButton = new System.Windows.Forms.Button();
            this.seeAllShifts = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.automaticShiftsButton = new System.Windows.Forms.Button();
            this.editSelectedShiftButton = new System.Windows.Forms.Button();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.shiftBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShifts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftBindingSource1)).BeginInit();
            this.ManagementTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shiftBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewShifts
            // 
            this.dataGridViewShifts.AllowUserToAddRows = false;
            this.dataGridViewShifts.AllowUserToDeleteRows = false;
            this.dataGridViewShifts.AutoGenerateColumns = false;
            this.dataGridViewShifts.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dataGridViewShifts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShifts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shiftIdDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.employeeIDDataGridViewTextBoxColumn,
            this.employeeFirstAndLastName});
            this.dataGridViewShifts.DataSource = this.shiftBindingSource1;
            this.dataGridViewShifts.Location = new System.Drawing.Point(470, 6);
            this.dataGridViewShifts.MultiSelect = false;
            this.dataGridViewShifts.Name = "dataGridViewShifts";
            this.dataGridViewShifts.ReadOnly = true;
            this.dataGridViewShifts.RowHeadersWidth = 40;
            this.dataGridViewShifts.RowTemplate.Height = 25;
            this.dataGridViewShifts.Size = new System.Drawing.Size(944, 552);
            this.dataGridViewShifts.TabIndex = 1;
            // 
            // shiftIdDataGridViewTextBoxColumn
            // 
            this.shiftIdDataGridViewTextBoxColumn.DataPropertyName = "ShiftId";
            this.shiftIdDataGridViewTextBoxColumn.HeaderText = "ShiftId";
            this.shiftIdDataGridViewTextBoxColumn.Name = "shiftIdDataGridViewTextBoxColumn";
            this.shiftIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.shiftIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeIDDataGridViewTextBoxColumn
            // 
            this.employeeIDDataGridViewTextBoxColumn.DataPropertyName = "EmployeeID";
            this.employeeIDDataGridViewTextBoxColumn.HeaderText = "Employee\'s ID";
            this.employeeIDDataGridViewTextBoxColumn.Name = "employeeIDDataGridViewTextBoxColumn";
            this.employeeIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeFirstAndLastName
            // 
            this.employeeFirstAndLastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.employeeFirstAndLastName.HeaderText = "Employee\'s First Name and Last Name";
            this.employeeFirstAndLastName.Name = "employeeFirstAndLastName";
            this.employeeFirstAndLastName.ReadOnly = true;
            this.employeeFirstAndLastName.Width = 162;
            // 
            // shiftBindingSource1
            // 
            this.shiftBindingSource1.DataSource = typeof(BusinessLogic.Classes.Shift);
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
            this.tabPage1.Controls.Add(this.dataGridViewEmployees);
            this.tabPage1.Controls.Add(this.seeEmployeeShift);
            this.tabPage1.Controls.Add(this.deleteEmployeeButton);
            this.tabPage1.Controls.Add(this.updateEmployeeButton);
            this.tabPage1.Controls.Add(this.SearchFilterComboBox);
            this.tabPage1.Controls.Add(this.searchEmployeeButton);
            this.tabPage1.Controls.Add(this.searchTextBox);
            this.tabPage1.Controls.Add(this.seeEmployeeNoShiftButton);
            this.tabPage1.Controls.Add(this.seeAssignedEmployeeButton);
            this.tabPage1.Controls.Add(this.seeAllEmployeeButton);
            this.tabPage1.Controls.Add(this.addNewEmployeeButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1417, 601);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Employee Management";
            // 
            // dataGridViewEmployees
            // 
            this.dataGridViewEmployees.AllowUserToAddRows = false;
            this.dataGridViewEmployees.AllowUserToDeleteRows = false;
            this.dataGridViewEmployees.AutoGenerateColumns = false;
            this.dataGridViewEmployees.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn,
            this.lastNameDataGridViewTextBoxColumn,
            this.jobPositionDataGridViewTextBoxColumn,
            this.usernameDataGridViewTextBoxColumn});
            this.dataGridViewEmployees.DataSource = this.employeeBindingSource;
            this.dataGridViewEmployees.Location = new System.Drawing.Point(439, 6);
            this.dataGridViewEmployees.MultiSelect = false;
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.ReadOnly = true;
            this.dataGridViewEmployees.RowTemplate.Height = 25;
            this.dataGridViewEmployees.Size = new System.Drawing.Size(972, 555);
            this.dataGridViewEmployees.TabIndex = 9;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "First Name";
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            this.firstNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            this.lastNameDataGridViewTextBoxColumn.HeaderText = "Last Name";
            this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            this.lastNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // jobPositionDataGridViewTextBoxColumn
            // 
            this.jobPositionDataGridViewTextBoxColumn.DataPropertyName = "JobPosition";
            this.jobPositionDataGridViewTextBoxColumn.HeaderText = "Job Position";
            this.jobPositionDataGridViewTextBoxColumn.Name = "jobPositionDataGridViewTextBoxColumn";
            this.jobPositionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usernameDataGridViewTextBoxColumn
            // 
            this.usernameDataGridViewTextBoxColumn.DataPropertyName = "Username";
            this.usernameDataGridViewTextBoxColumn.HeaderText = "Username";
            this.usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            this.usernameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataSource = typeof(BusinessLogic.Classes.Employee);
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
            this.tabPage2.Controls.Add(this.addNewShiftButton);
            this.tabPage2.Controls.Add(this.seeAllShifts);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.dataGridViewShifts);
            this.tabPage2.Controls.Add(this.automaticShiftsButton);
            this.tabPage2.Controls.Add(this.editSelectedShiftButton);
            this.tabPage2.Controls.Add(this.monthCalendar);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1417, 601);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Shift Management";
            // 
            // addNewShiftButton
            // 
            this.addNewShiftButton.Location = new System.Drawing.Point(0, 338);
            this.addNewShiftButton.Name = "addNewShiftButton";
            this.addNewShiftButton.Size = new System.Drawing.Size(167, 51);
            this.addNewShiftButton.TabIndex = 13;
            this.addNewShiftButton.Text = "Add a new Shift";
            this.addNewShiftButton.UseVisualStyleBackColor = true;
            this.addNewShiftButton.Click += new System.EventHandler(this.addNewShiftButton_Click);
            // 
            // seeAllShifts
            // 
            this.seeAllShifts.Location = new System.Drawing.Point(200, 407);
            this.seeAllShifts.Name = "seeAllShifts";
            this.seeAllShifts.Size = new System.Drawing.Size(167, 52);
            this.seeAllShifts.TabIndex = 12;
            this.seeAllShifts.Text = "See All Shifts";
            this.seeAllShifts.UseVisualStyleBackColor = true;
            this.seeAllShifts.Click += new System.EventHandler(this.seeAllShifts_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 493);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 52);
            this.button1.TabIndex = 11;
            this.button1.Text = "Delete All Shifts";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // automaticShiftsButton
            // 
            this.automaticShiftsButton.Location = new System.Drawing.Point(200, 493);
            this.automaticShiftsButton.Name = "automaticShiftsButton";
            this.automaticShiftsButton.Size = new System.Drawing.Size(167, 52);
            this.automaticShiftsButton.TabIndex = 10;
            this.automaticShiftsButton.Text = "Automatic Shifts";
            this.automaticShiftsButton.UseVisualStyleBackColor = true;
            this.automaticShiftsButton.Click += new System.EventHandler(this.automaticShiftsButton_Click);
            // 
            // editSelectedShiftButton
            // 
            this.editSelectedShiftButton.Location = new System.Drawing.Point(0, 407);
            this.editSelectedShiftButton.Name = "editSelectedShiftButton";
            this.editSelectedShiftButton.Size = new System.Drawing.Size(167, 52);
            this.editSelectedShiftButton.TabIndex = 9;
            this.editSelectedShiftButton.Text = "Edit Selected Shift";
            this.editSelectedShiftButton.UseVisualStyleBackColor = true;
            this.editSelectedShiftButton.Click += new System.EventHandler(this.editSelectedShiftButton_Click);
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
            // ManagingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.ClientSize = new System.Drawing.Size(1449, 646);
            this.Controls.Add(this.ManagementTabControl);
            this.Name = "ManagingForm";
            this.Text = "Managing Form";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShifts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shiftBindingSource1)).EndInit();
            this.ManagementTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            this.tabPage2.ResumeLayout(false);
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
        private Button seeEmployeeNoShiftButton;
        private ComboBox SearchFilterComboBox;
        private Button searchEmployeeButton;
        private TextBox searchTextBox;
        private Button deleteEmployeeButton;
        private Button updateEmployeeButton;
        private Button seeEmployeeShift;
        private BindingSource shiftBindingSource;
        private MonthCalendar monthCalendar;
        private Button editSelectedShiftButton;
        private Button automaticShiftsButton;
        private DataGridView dataGridViewEmployees;
        private BindingSource employeeBindingSource;
        private DataGridView dataGridViewShifts;
        private BindingSource shiftBindingSource1;
        private Button button1;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn jobPositionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private Button seeAllShifts;
        private DataGridViewTextBoxColumn shiftIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeFirstAndLastName;
        private Button addNewShiftButton;
    }
}