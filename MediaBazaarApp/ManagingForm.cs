using BusinessLogic.Classes;
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

        }
    }
}
