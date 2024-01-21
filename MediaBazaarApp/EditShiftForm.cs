using BusinessLogic.Classes;
using BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaarApp
{
    public partial class EditShiftForm : Form
    {
        private readonly Administration administration;
        private readonly Shift shift;

        public EditShiftForm(Administration _administration, Shift _shift)
        {
            administration = _administration;
            shift = _shift;

            InitializeComponent();

            PopulateLabels(administration, shift);
        }

        private void PopulateLabels(Administration administration, Shift shift)
        {
            var employee = administration.GetEmployeeById(shift.EmployeeID);
            IDLabel.Text = shift.ShiftId.ToString();
            dateLabel.Text = shift.Date.ToString("yyyy-MM-dd"); 
            usernameLabel.Text = employee.Username;
            firstAndLastNameLabel.Text = $"{employee.FirstName} {employee.LastName}";

            PopulateComboBox(shift);
        }

        private void PopulateComboBox(Shift shift)
        { 
            typeComboBox.SelectedItem = shift.Type.ToString();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (Enum.TryParse<ShiftType>(typeComboBox.SelectedItem.ToString(), out ShiftType newShiftType))
            {
                shift.Type = newShiftType;
                administration.UpdateShift(shift);
                MessageBox.Show("Shift updated successfully.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid shift type selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this shift?", "Delete Shift", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                administration.DeleteShift(shift);
                MessageBox.Show("Shift deleted successfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }

}
