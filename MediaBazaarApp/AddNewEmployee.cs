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
    public partial class AddNewEmployee : Form
    {
        private readonly Administration administration;
        Position positionEnum;
        ShiftType shiftTypeEnum;
        public AddNewEmployee(Administration administration)
        {
            this.administration = administration;
            InitializeComponent();
        }

        private void createEmployeeButton_Click(object sender, EventArgs e)
        {
            if (firstNameTextBox.Text != string.Empty && lastNameTextBox.Text != string.Empty && usernameTextBox.Text != string.Empty && passwordTextBox.Text != string.Empty)
            {
                Employee newEmployee = new Employee();
                newEmployee.ID = Guid.NewGuid();
                newEmployee.FirstName = firstNameTextBox.Text;
                newEmployee.LastName = lastNameTextBox.Text;
                newEmployee.Username = usernameTextBox.Text;
                newEmployee.Password = passwordTextBox.Text;
                //newEmployee.Email = emailTextBox.Text;
                string selectedPosition = RoleComboBox.SelectedItem?.ToString();

                if (!string.IsNullOrEmpty(selectedPosition))
                {
                    if (Enum.TryParse(selectedPosition, out positionEnum))
                    {
                        newEmployee.JobPosition = positionEnum;
                    }
                    else
                    {
                        MessageBox.Show("Invalid selection for the Role");
                    }
                }

                newEmployee.Preferences = new List<Preference>();

                SetPreference(newEmployee, DayOfWeek.Monday, MondayPreference.SelectedItem?.ToString());
                SetPreference(newEmployee, DayOfWeek.Tuesday, TuesdayPreference.SelectedItem?.ToString());
                SetPreference(newEmployee, DayOfWeek.Wednesday, WednesdayPreference.SelectedItem?.ToString());
                SetPreference(newEmployee, DayOfWeek.Thursday, ThursdayPreference.SelectedItem?.ToString());
                SetPreference(newEmployee, DayOfWeek.Friday, FridayPreference.SelectedItem?.ToString());
                SetPreference(newEmployee, DayOfWeek.Saturday, SaturdayPreference.SelectedItem?.ToString());
                SetPreference(newEmployee, DayOfWeek.Sunday, SundayPreference.SelectedItem?.ToString());

                administration.AddEmployee(newEmployee);
                
                MessageBox.Show("Employee created succesfully");

                this.Close();
            }
            else { MessageBox.Show("Please fill each box in the form!"); }
        }
        private void SetPreference(Employee employee, DayOfWeek dayOfWeek, string selectedShiftType)
        {
            if (!string.IsNullOrEmpty(selectedShiftType))
            {
                if (Enum.TryParse(selectedShiftType, out shiftTypeEnum))
                {
                    var preference = new Preference
                    {
                        PreferenceId = Guid.NewGuid(),
                        DayOfWeek = (int)dayOfWeek,
                        ShiftType = shiftTypeEnum,
                        EmployeeId = employee.ID
                    };

                    employee.Preferences.Add(preference);
                }
                else
                {
                    MessageBox.Show($"Invalid selection for {dayOfWeek} preference");
                }
            }
        }
    }
}
