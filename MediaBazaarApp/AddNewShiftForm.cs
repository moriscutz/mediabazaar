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
    public partial class AddNewShiftForm : Form
    {
        private readonly Administration administration;
        public AddNewShiftForm(Administration administration)
        {
            this.administration = administration;
            InitializeComponent();
            availableEmployeesListBox.Items.Clear();
        }
        private void confirmButton_Click(object sender, EventArgs e)
        {
            if(usernameTextBox.Text == String.Empty)
            {
                MessageBox.Show("Please input the Employee's username first.");
                return;
            }
            DateTime selectedDate = monthCalendarAddShift.SelectionStart;
            DateTime endDate = monthCalendarAddShift.SelectionEnd;
            DateTime today = DateTime.Now;
            if(typeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Shift Type first.");
                return;
            }
            if (selectedDate < today)
            {
                MessageBox.Show("You cannot create a shift in the past.");
                return;
            }
            if (selectedDate > endDate)
            {
                MessageBox.Show("Please select a correct date.");
                return;
            }

            if (!Enum.TryParse(typeComboBox.SelectedItem.ToString(), out ShiftType shiftType))
            {
                MessageBox.Show("Invalid Shift Type selected.");
                return;
            }

            var employee = administration.GetEmployeeByUsername(usernameTextBox.Text);
            if (employee == null)
            {
                MessageBox.Show("Employee not found.");
                return;
            }

            bool alreadyShifted = false;
            for (DateTime date = selectedDate; date <= endDate; date = date.AddDays(1))
            {
                var existingShifts = administration.GetShiftsByDateAndType(date, shiftType);
                if (existingShifts == null || !existingShifts.Any(s => s.EmployeeID == employee.ID))
                {
                    var shift = new Shift(Guid.NewGuid(), date, shiftType, employee.ID);
                    administration.AddShift(shift);
                }
                else
                {
                    alreadyShifted= true;
                    MessageBox.Show($"A shift for {employee.Username} already exists on {date.ToShortDateString()} for {shiftType}.");
                }
            }
            if(!alreadyShifted)
            MessageBox.Show("Shift(s) added successfully.");
            this.Close();
        }

        private void monthCalendarAddShift_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedStartDate = monthCalendarAddShift.SelectionRange.Start;
            UpdateAvailableEmployeesListBox(selectedStartDate);
        }


        private void UpdateAvailableEmployeesListBox(DateTime selectedDate)
        {
            var availableEmployees = administration.GetAvailableEmployeesNotShifted(selectedDate);

            availableEmployeesListBox.Items.Clear();
            foreach (var employee in availableEmployees)
            {
                availableEmployeesListBox.Items.Add($"{employee.FirstName} {employee.LastName} {employee.Username}");
            }
        }


    }
}
