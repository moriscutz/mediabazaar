//using BusinessLogic.Algorithm;
using BusinessLogic.Classes;
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
        //private readonly AutomaticScheduling automaticScheduling;
        private List<Employee> employees = new List<Employee>();
        private List<Shift> shifts = new List<Shift>();
        public ManagingForm(Administration _administration)
        {
            this.administration = _administration;
            //automaticScheduling = new AutomaticScheduling(administration);

            InitializeComponent();

            SearchFilterComboBox.SelectedIndex = 0;

            RefreshEmployees(administration);
            RefreshShifts(administration);

            //PopulateShiftBoxesAndLabel(administration);
        }

        private void RefreshEmployees(Administration administration)
        {
            employees.Clear();
            employees = administration.GetAllEmployees();
            dataGridViewEmployees.DataSource = employees;
        }
        private void RefreshShifts(Administration administration)
        {
            shifts.Clear();
            shifts = administration.GetAllShifts();
            dataGridViewShifts.DataSource = shifts;
        }
       

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
           
        }
        

        private void addNewEmployeeButton_Click(object sender, EventArgs e)
        {
            AddNewEmployee addNewEmployeeForm = new AddNewEmployee(administration);
            addNewEmployeeForm.Show();
            
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
                    RefreshEmployees(administration); // To refresh the DataGridView list
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
            // HAS TO BE IMPLEMENTED
            MessageBox.Show("Has to be implemented.");
        }

        private void automaticShiftsButton_Click(object sender, EventArgs e)
        {
            //List<Shift> shifts = automaticScheduling.ScheduleShifts();
            //System.Diagnostics.Debug.WriteLine($"{shifts.Count()}");
            //administration.UpdateDatabaseWithNewSchedule(shifts);
            //MessageBox.Show("Schedule generated and updated in database.");
        }
    }
}
