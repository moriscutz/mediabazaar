
using BusinessLogic.Algorithm;
using BusinessLogic.Classes;
using BusinessLogic.Enums;
using DataAccess;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class ManagingForm : Form
    {
        private readonly Administration administration;
        private List<Employee> employees = new List<Employee>();
        private List<Shift> shifts = new List<Shift>();
        public ManagingForm(Administration _administration)
        {
            this.administration = _administration;
            InitializeComponent();

            SearchFilterComboBox.SelectedIndex = 0;
            shifts = administration.GetShiftsByDate(DateTime.Today);

            RefreshEmployees(administration);
            RefreshShifts(administration,shifts);
            RefreshBoldedDates();
        }
        
        private void RefreshEmployees(Administration administration)
        {
            employees.Clear();
            employees = administration.GetAllEmployees();
            dataGridViewEmployees.DataSource = employees;
            PopulateEmployeeNames();
        }
        private void RefreshShifts(Administration administration)
        {
            shifts.Clear();
            shifts = administration.GetAllShifts();
            dataGridViewShifts.DataSource = shifts;
            PopulateEmployeeNames();
            RefreshBoldedDates();
        }
        private void PopulateEmployeeNames()
        {
            foreach (DataGridViewRow row in dataGridViewShifts.Rows)
            {
                if (row.DataBoundItem is Shift shift)
                {
                    var employee = administration.GetEmployeeById(shift.EmployeeID);
                    if (employee != null)
                    {
                        row.Cells["employeeFirstAndLastName"].Value = $"{employee.FirstName} {employee.LastName}";
                    }
                }
            }
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = monthCalendar.SelectionStart;

            shifts.Clear();

            foreach (ShiftType shiftType in Enum.GetValues(typeof(ShiftType)))
            {
                var shiftsForType = administration.GetShiftsByDateAndType(selectedDate, shiftType);
                if (shiftsForType != null)
                {
                    shifts.AddRange(shiftsForType);
                }
            }

            RefreshShifts(administration, shifts);
        }

        private void RefreshShifts(Administration administration, List<Shift> shifts)
        {
            var bindingList = new BindingList<Shift>(shifts);
            var source = new BindingSource(bindingList, null);
            dataGridViewShifts.DataSource = source;
            PopulateEmployeeNames();
        }

        private void addNewEmployeeButton_Click(object sender, EventArgs e)
        {
            AddNewEmployee addNewEmployeeForm = new AddNewEmployee(administration);
            addNewEmployeeForm.ShowDialog(); 

            RefreshEmployees(administration); 
        }


        private void seeAllEmployeeButton_Click(object sender, EventArgs e)
        {
            var employees = administration.GetAllEmployees();
            dataGridViewEmployees.DataSource = employees;
        }


        private void seeAssignedEmployeeButton_Click(object sender, EventArgs e)
        {
            var assignedEmployees = administration.GetAllEmployees()
                .Where(emp => administration.GetShiftsForEmployeeById(emp.ID).Count > 0)
                .ToList();

            dataGridViewEmployees.DataSource = assignedEmployees;
        }


        private void seeEmployeeNoShiftButton_Click(object sender, EventArgs e)
        {
            var noShiftEmployees = administration.GetAllEmployees()
                .Where(emp => administration.GetShiftsForEmployeeById(emp.ID).Count == 0)
                .ToList();

            dataGridViewEmployees.DataSource = noShiftEmployees;
        }


        private void searchEmployeeButton_Click(object sender, EventArgs e)
        {
            string toSearch = searchTextBox.Text;
            if (!string.IsNullOrEmpty(toSearch))
            {
                List<Employee> searchedEmployees = null;
                if (SearchFilterComboBox.SelectedItem.ToString() == "By Username")
                {
                    searchedEmployees = administration.SearchEmployeesByUsername(toSearch);
                }
                else if (SearchFilterComboBox.SelectedItem.ToString() == "By Last Name")
                {
                    searchedEmployees = administration.SearchEmployeesByLastName(toSearch);
                }
                else
                {
                    MessageBox.Show("Please select a filter first!");
                    return;
                }

                dataGridViewEmployees.DataSource = searchedEmployees;
            }
            else
            {
                MessageBox.Show("Please input the text first!");
            }
        }


        private void deleteEmployeeButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.SelectedRows.Count == 1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the user from the database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int index = dataGridViewEmployees.SelectedRows[0].Index;
                    Employee selectedEmployee = employees[index];
                    administration.DeleteEmployee(selectedEmployee);
                    MessageBox.Show("User has been deleted successfully");
                    RefreshEmployees(administration); 
                }
            }
            else MessageBox.Show("Please select one employee to delete.");
        }


        private void updateEmployeeButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.SelectedRows.Count == 1)
            {
                int index = dataGridViewEmployees.SelectedRows[0].Index;
                Employee selectedEmployee = employees[index];
                UpdateEmployee updateEmployee = new UpdateEmployee(administration, selectedEmployee);
                updateEmployee.Show();
            }
            else MessageBox.Show("Please select one employee to update.");
        }


        private void seeEmployeeShift_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.SelectedRows.Count == 1)
            {
                int index = dataGridViewEmployees.SelectedRows[0].Index;
                Employee selectedEmployee = employees[index];
                var shifts = administration.GetShiftsForEmployeeById(selectedEmployee.ID);

                if (shifts.Count == 0)
                {
                    MessageBox.Show("Employee has no shifts.");
                }
                else
                {
                    EmployeeShiftInfo employeeShiftInfo = new EmployeeShiftInfo(administration, selectedEmployee);
                    employeeShiftInfo.Show();
                }
            }
            else MessageBox.Show("Please select one employee to see the shifts for.");
        }


        private void editSelectedShiftButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewShifts.SelectedRows.Count == 1)
            {
                int index = dataGridViewShifts.SelectedRows[0].Index;
                Shift selectedShift = shifts[index];
                EditShiftForm editShiftForm = new EditShiftForm(administration, selectedShift);

                editShiftForm.ShowDialog();

                RefreshShifts(administration);
            }
            else
            {
                MessageBox.Show("Please choose the designed shift first.");
            }
        }

        private void automaticShiftsButton_Click(object sender, EventArgs e)
        {
            GenerateScheduleWindow scheduleForm = new GenerateScheduleWindow(administration);
            scheduleForm.ShowDialog();
            RefreshShifts(administration);
        }


        private void RefreshBoldedDates()
        {
            monthCalendar.RemoveAllBoldedDates();

            var startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            var endOfWeek = startOfWeek.AddMonths(1);

            for (var date = startOfWeek; date <= endOfWeek; date = date.AddDays(1))
            {
                bool shouldBoldDate = false;

                foreach (ShiftType shiftType in Enum.GetValues(typeof(ShiftType)))
                {
                    var shiftsForType = administration.GetShiftsByDateAndType(date, shiftType);
                    if (shiftsForType.Count < 3) 
                    {
                        shouldBoldDate = true;
                        break;
                    }
                }

                if (shouldBoldDate)
                {
                    monthCalendar.AddBoldedDate(date);
                }
            }

            monthCalendar.UpdateBoldedDates();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete all of the shifts from the database? This action cannot be undone.", "Deleting shifts", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dialogResult == DialogResult.Yes)
            {
                administration.DeleteAllShifts();
                RefreshShifts(administration);
            }

        }

        private void seeAllShifts_Click(object sender, EventArgs e)
        {
            RefreshShifts(administration);
        }

        private void addNewShiftButton_Click(object sender, EventArgs e)
        {
            AddNewShiftForm addNewShiftForm = new AddNewShiftForm(administration);
            addNewShiftForm.ShowDialog();

            RefreshShifts(administration);
        }
    }
}
