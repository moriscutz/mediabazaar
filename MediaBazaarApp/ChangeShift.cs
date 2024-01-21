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
    public partial class ChangeShift : Form
    {
        private readonly Administration administration;
        private readonly Shift shift;
        ShiftType shiftType;
        public ChangeShift(Administration _administration, Shift _shift)
        {
            administration= _administration;
            shift = _shift;
            InitializeComponent();

            PopulateEverything(administration, shift);
        }

        private void PopulateEverything(Administration administration, Shift shift)
        {
            shiftIDLabel.Text = shift.ShiftId.ToString();
            employeeIDLabel.Text = shift.EmployeeID.ToString();
            typeComboBox.SelectedItem = shift.Type.ToString();

            var employee = administration.GetEmployeeById(shift.EmployeeID);

            employeeNameLabel.Text = employee.ToString();

            monthCalendar.AddBoldedDate(shift.Date);
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = monthCalendar.SelectionRange.Start;
            if(selectedDate < DateTime.Today)
            {
                MessageBox.Show("You cannot add a shift in the past", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var existingShifts = administration.GetShiftsByDateAndType(selectedDate, shift.Type);
                if (existingShifts.Any(s => s.EmployeeID == shift.EmployeeID))
                {
                    MessageBox.Show("This employee already has a shift on the selected date for this shift type.", "Shift Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to change the shift's date?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        shift.Date = selectedDate;
                        monthCalendar.RemoveAllBoldedDates();
                        monthCalendar.AddBoldedDate(shift.Date);
                        monthCalendar.UpdateBoldedDates();
                        administration.UpdateShift(shift);
                    }
                }
            } 
        }

        private void updateTypeButton_Click(object sender, EventArgs e)
        {
            string positionBox = typeComboBox.SelectedItem?.ToString();
            if(Enum.TryParse(positionBox, out shiftType))
            {
                shift.Type = shiftType;

                administration.UpdateShift(shift);

                MessageBox.Show("Type updated succesfully.");
            }
        }
    }
}
