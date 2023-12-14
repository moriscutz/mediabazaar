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
        public ManagingForm(Administration administration)
        {
            this.administration = administration;
            
            InitializeComponent();
            SearchFilterComboBox.SelectedIndex = 0;
        }

        private void addNewEmployeeButton_Click(object sender, EventArgs e)
        {
            AddNewEmployee addNewEmployeeForm = new AddNewEmployee(administration);
            addNewEmployeeForm.Show();
            
        }

        private void seeAllEmployeeButton_Click(object sender, EventArgs e)
        {
            employeeListBox.Items.Clear();
            var employees = administration.GetAllEmployees();
            
            foreach (Employee employee in employees ) 
            {
                var shifts = administration.GetShiftsForEmployeeById(employee.ID);
                int count = shifts.Count;
                EmployeeListItem listItem = new EmployeeListItem
                {
                    Employee = employee,
                    DisplayText = $"First Name: {employee.FirstName}, Last Name: {employee.LastName}, Position: {employee.JobPosition}, Username: {employee.Username}, Shifts: {count}"
                };
                employeeListBox.Items.Add(listItem);
            }
        }

        private void seeAssignedEmployeeButton_Click(object sender, EventArgs e)
        {
            employeeListBox.Items.Clear();
            var employees = administration.GetAllEmployees();

            foreach (Employee employee in employees)
            {
                var shifts = administration.GetShiftsForEmployeeById(employee.ID);
                int count = shifts.Count;
                if (count > 0)
                {
                    EmployeeListItem listItem = new EmployeeListItem
                    {
                        Employee = employee,
                        DisplayText = $"First Name: {employee.FirstName}, Last Name: {employee.LastName}, Position: {employee.JobPosition}, Username: {employee.Username}, Shifts: {count}"
                    };
                    employeeListBox.Items.Add(listItem);
                }
            }

        }

        private void seeEmployeeNoShiftButton_Click(object sender, EventArgs e)
        {
            employeeListBox.Items.Clear();
            var employees = administration.GetAllEmployees();

            foreach (Employee employee in employees)
            {
                var shifts = administration.GetShiftsForEmployeeById(employee.ID);
                int count = shifts.Count;
                if (count == 0)
                {
                    EmployeeListItem listItem = new EmployeeListItem
                    {
                        Employee = employee,
                        DisplayText = $"First Name: {employee.FirstName}, Last Name: {employee.LastName}, Position: {employee.JobPosition}, Username: {employee.Username}, Shifts: {count}"
                    };
                    employeeListBox.Items.Add(listItem);
                }
            }
        }

        private void searchEmployeeButton_Click(object sender, EventArgs e)
        {
            string toSearch = searchTextBox.Text;
            if (searchTextBox.Text != string.Empty)
            {
                employeeListBox.Items.Clear();
                if (SearchFilterComboBox.SelectedItem.ToString() == "By Username")
                {
                    var searchedUsers = administration.SearchEmployeesByUsername(toSearch);
                    foreach(Employee employee in searchedUsers)
                    {
                        var shifts = administration.GetShiftsForEmployeeById(employee.ID);
                        int count = shifts.Count;
                        EmployeeListItem listItem = new EmployeeListItem
                        {
                            Employee = employee,
                            DisplayText = $"First Name: {employee.FirstName}, Last Name: {employee.LastName}, Position: {employee.JobPosition}, Username: {employee.Username}, Shifts: {count}"
                        };
                        employeeListBox.Items.Add(listItem);
                    }
                }
                else if (SearchFilterComboBox.SelectedItem.ToString() == "By Last Name")
                {
                    var searchedUsers = administration.SearchEmployeesByLastName(toSearch);
                    foreach (Employee employee in searchedUsers)
                    {
                        var shifts = administration.GetShiftsForEmployeeById(employee.ID);
                        int count = shifts.Count;
                        EmployeeListItem listItem = new EmployeeListItem
                        {
                            Employee = employee,
                            DisplayText = $"First Name: {employee.FirstName}, Last Name: {employee.LastName}, Position: {employee.JobPosition}, Username: {employee.Username}, Shifts: {count}"
                        };
                        employeeListBox.Items.Add(listItem);
                    }
                }
                else MessageBox.Show("Please select a filter first!");
            }
            else
                MessageBox.Show("Please input the text first!");
        }

        private void deleteEmployeeButton_Click(object sender, EventArgs e)
        {
            if (employeeListBox.SelectedItems.Count == 1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the user from the database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
               
                        Employee selectedEmployee = ((EmployeeListItem)employeeListBox.SelectedItem).Employee;
                        administration.DeleteEmployee(selectedEmployee);
                        MessageBox.Show("User has been deleted succesfully");
                        employeeListBox.SelectedItems.Clear();
                }
            }
            else MessageBox.Show("Please select one employee to delete.");
        }

        private void updateEmployeeButton_Click(object sender, EventArgs e)
        {
            if (employeeListBox.SelectedItems.Count == 1)
            {
                Employee selectedEmployee = ((EmployeeListItem)employeeListBox.SelectedItem).Employee;
                UpdateEmployee updateEmployee = new UpdateEmployee(administration, selectedEmployee);
                updateEmployee.Show();
            }
            else MessageBox.Show("Please select one employee to update.");
        }

        private void seeEmployeeShift_Click(object sender, EventArgs e)
        {
            if (employeeListBox.SelectedItems.Count == 1)
            {
                Employee selectedEmployee = ((EmployeeListItem)employeeListBox.SelectedItem).Employee;
                var shifts = administration.GetShiftsForEmployeeById(selectedEmployee.ID);

                int count = shifts.Count;

                if(count == 0) { MessageBox.Show("Employee has no shifts."); }
                else
                {
                    EmployeeShiftInfo employeeShiftInfo = new EmployeeShiftInfo(administration, selectedEmployee);
                    employeeShiftInfo.Show();
                }
            }
            else MessageBox.Show("Please select one employee to see the shifts for.");
        }
    }
}
