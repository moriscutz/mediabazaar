﻿namespace MediaBazaarApp
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
            this.ManagementTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.seeEmployeeNoShiftButton = new System.Windows.Forms.Button();
            this.seeAssignedEmployeeButton = new System.Windows.Forms.Button();
            this.seeAllEmployeeButton = new System.Windows.Forms.Button();
            this.employeeListBox = new System.Windows.Forms.ListBox();
            this.addNewEmployeeButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchEmployeeButton = new System.Windows.Forms.Button();
            this.SearchFilterComboBox = new System.Windows.Forms.ComboBox();
            this.ManagementTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            // seeEmployeeNoShiftButton
            // 
            this.seeEmployeeNoShiftButton.Location = new System.Drawing.Point(3, 419);
            this.seeEmployeeNoShiftButton.Name = "seeEmployeeNoShiftButton";
            this.seeEmployeeNoShiftButton.Size = new System.Drawing.Size(150, 62);
            this.seeEmployeeNoShiftButton.TabIndex = 1;
            this.seeEmployeeNoShiftButton.Text = "See Employees without Shifts";
            this.seeEmployeeNoShiftButton.UseVisualStyleBackColor = true;
            this.seeEmployeeNoShiftButton.Click += new System.EventHandler(this.seeEmployeeNoShiftButton_Click);
            // 
            // seeAssignedEmployeeButton
            // 
            this.seeAssignedEmployeeButton.Location = new System.Drawing.Point(6, 351);
            this.seeAssignedEmployeeButton.Name = "seeAssignedEmployeeButton";
            this.seeAssignedEmployeeButton.Size = new System.Drawing.Size(150, 62);
            this.seeAssignedEmployeeButton.TabIndex = 3;
            this.seeAssignedEmployeeButton.Text = "See assigned Employees";
            this.seeAssignedEmployeeButton.UseVisualStyleBackColor = true;
            this.seeAssignedEmployeeButton.Click += new System.EventHandler(this.seeAssignedEmployeeButton_Click);
            // 
            // seeAllEmployeeButton
            // 
            this.seeAllEmployeeButton.Location = new System.Drawing.Point(6, 283);
            this.seeAllEmployeeButton.Name = "seeAllEmployeeButton";
            this.seeAllEmployeeButton.Size = new System.Drawing.Size(150, 62);
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
            this.addNewEmployeeButton.Location = new System.Drawing.Point(3, 487);
            this.addNewEmployeeButton.Name = "addNewEmployeeButton";
            this.addNewEmployeeButton.Size = new System.Drawing.Size(150, 62);
            this.addNewEmployeeButton.TabIndex = 0;
            this.addNewEmployeeButton.Text = "Add New Employee";
            this.addNewEmployeeButton.UseVisualStyleBackColor = true;
            this.addNewEmployeeButton.Click += new System.EventHandler(this.addNewEmployeeButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1417, 601);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Shift Management";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(6, 111);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.PlaceholderText = "Search User";
            this.searchTextBox.Size = new System.Drawing.Size(189, 23);
            this.searchTextBox.TabIndex = 4;
            // 
            // searchEmployeeButton
            // 
            this.searchEmployeeButton.Location = new System.Drawing.Point(25, 151);
            this.searchEmployeeButton.Name = "searchEmployeeButton";
            this.searchEmployeeButton.Size = new System.Drawing.Size(170, 23);
            this.searchEmployeeButton.TabIndex = 5;
            this.searchEmployeeButton.Text = "Search for the Employee";
            this.searchEmployeeButton.UseVisualStyleBackColor = true;
            this.searchEmployeeButton.Click += new System.EventHandler(this.searchEmployeeButton_Click);
            // 
            // SearchFilterComboBox
            // 
            this.SearchFilterComboBox.FormattingEnabled = true;
            this.SearchFilterComboBox.Items.AddRange(new object[] {
            "By Username",
            "By Last Name"});
            this.SearchFilterComboBox.Location = new System.Drawing.Point(201, 111);
            this.SearchFilterComboBox.Name = "SearchFilterComboBox";
            this.SearchFilterComboBox.Size = new System.Drawing.Size(92, 23);
            this.SearchFilterComboBox.TabIndex = 6;
            this.SearchFilterComboBox.Text = "Filter";
            // 
            // ManagingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.ClientSize = new System.Drawing.Size(1449, 646);
            this.Controls.Add(this.ManagementTabControl);
            this.Name = "ManagingForm";
            this.Text = "ManagingForm";
            this.ManagementTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
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
    }
}