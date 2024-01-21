namespace MediaBazaarApp
{
    partial class EmployeeShiftInfo
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
            this.shiftsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.shiftIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancelShiftButton = new System.Windows.Forms.Button();
            this.changeShiftButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.shiftsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // shiftsBindingSource
            // 
            this.shiftsBindingSource.DataMember = "Shifts";
            this.shiftsBindingSource.DataSource = this.employeeBindingSource;
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataSource = typeof(BusinessLogic.Classes.Employee);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shiftIdDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.employeeIDDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.shiftsBindingSource;
            this.dataGridView.Location = new System.Drawing.Point(268, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(523, 558);
            this.dataGridView.TabIndex = 0;
            // 
            // shiftIdDataGridViewTextBoxColumn
            // 
            this.shiftIdDataGridViewTextBoxColumn.DataPropertyName = "ShiftId";
            this.shiftIdDataGridViewTextBoxColumn.HeaderText = "ShiftId";
            this.shiftIdDataGridViewTextBoxColumn.Name = "shiftIdDataGridViewTextBoxColumn";
            this.shiftIdDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.employeeIDDataGridViewTextBoxColumn.HeaderText = "EmployeeID";
            this.employeeIDDataGridViewTextBoxColumn.Name = "employeeIDDataGridViewTextBoxColumn";
            this.employeeIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cancelShiftButton
            // 
            this.cancelShiftButton.Location = new System.Drawing.Point(12, 205);
            this.cancelShiftButton.Name = "cancelShiftButton";
            this.cancelShiftButton.Size = new System.Drawing.Size(148, 57);
            this.cancelShiftButton.TabIndex = 1;
            this.cancelShiftButton.Text = "Cancel Shift";
            this.cancelShiftButton.UseVisualStyleBackColor = true;
            this.cancelShiftButton.Click += new System.EventHandler(this.cancelShiftButton_Click);
            // 
            // changeShiftButton
            // 
            this.changeShiftButton.Location = new System.Drawing.Point(12, 289);
            this.changeShiftButton.Name = "changeShiftButton";
            this.changeShiftButton.Size = new System.Drawing.Size(148, 62);
            this.changeShiftButton.TabIndex = 2;
            this.changeShiftButton.Text = "Change Shift";
            this.changeShiftButton.UseVisualStyleBackColor = true;
            this.changeShiftButton.Click += new System.EventHandler(this.changeShiftButton_Click);
            // 
            // EmployeeShiftInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ClientSize = new System.Drawing.Size(1157, 559);
            this.Controls.Add(this.changeShiftButton);
            this.Controls.Add(this.cancelShiftButton);
            this.Controls.Add(this.dataGridView);
            this.Name = "EmployeeShiftInfo";
            this.Text = "Employee\'s Shift Information";
            ((System.ComponentModel.ISupportInitialize)(this.shiftsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private BindingSource shiftsBindingSource;
        private BindingSource employeeBindingSource;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn shiftIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeIDDataGridViewTextBoxColumn;
        private Button cancelShiftButton;
        private Button changeShiftButton;
    }
}